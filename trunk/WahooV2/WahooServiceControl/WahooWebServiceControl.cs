using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using WahooConfiguration;

namespace WahooServiceControl
{
    public class WahooWebServiceControl
    {
        #region variable

        private const int MAX_RETRIES = 3;
        //Web service
        private WebService.Service _WahooService = null;
        private WebService.AuthSoapHd objAuthSoapHeader = new WahooServiceControl.WebService.AuthSoapHd();
        //Folder in server
        private string _mServerFolder;
        private const string USERNAME = "980@Cuong!@#$%678";
        private const string PASSWORD = "78$>@!(C%7";


        public string ServerFolder
        {
            get { return _mServerFolder; }
            set { _mServerFolder = value; }
        }

        #endregion variable

        #region constructor

        public WahooWebServiceControl(string url)
        {
            _WahooService = new WahooServiceControl.WebService.Service();
            _WahooService.Url = url;
            objAuthSoapHeader.strPassword = PASSWORD;
            objAuthSoapHeader.strUserName = USERNAME;
            _WahooService.AuthSoapHdValue = objAuthSoapHeader;
        }

        #endregion constructor

        #region function

        /// <summary>
        /// getBinaryFileFReturn array of byte which you specified.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private byte[] ReadBinaryFile(string path, Boolean storeFile)
        {
            if (File.Exists(path))
            {
                try
                {
                    ///Open and read a file.
                    FileStream fileStream = File.OpenRead(path);
                    byte[] kq = ConvertStreamToByteBuffer(fileStream);
                    if (fileStream != null)
                    {
                        fileStream.Close();
                        fileStream = null;
                    }
                    //If store file when download or upload
                    if (storeFile)
                    {
                        //Store file in backup folder
                        string pathDirectory = Path.GetDirectoryName(path);
                        pathDirectory += "\\Backup";
                        if (!Directory.Exists(pathDirectory))
                        {
                            Directory.CreateDirectory(pathDirectory);
                        }
                        //Store file in backup foleder-> folder yyyyMMdd
                        pathDirectory += "\\" + DateTime.Now.ToString("yyyyMMdd");
                        if (!Directory.Exists(pathDirectory))
                        {
                            Directory.CreateDirectory(pathDirectory);
                        }
                        //Store file
                        pathDirectory += "\\" + Path.GetFileName(path);
                        if (File.Exists(pathDirectory))
                        {
                            File.Delete(pathDirectory);
                        }
                        File.Move(path, pathDirectory);
                    }
                    //If not store file,delete file
                    else
                    {
                        File.Delete(path);
                    }
                    return kq;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return new byte[0];
            }
        }

        /// <summary>
        /// ConvertStreamToByteBufferFConvert Stream To ByteBuffer.
        /// </summary>
        /// <param name="theStream"></param>
        /// <returns></returns>
        public byte[] ConvertStreamToByteBuffer(System.IO.Stream theStream)
        {
            int b1;
            System.IO.MemoryStream tempStream = new System.IO.MemoryStream();
            while ((b1 = theStream.ReadByte()) != -1)
            {
                tempStream.WriteByte(((byte)b1));
            }
            return tempStream.ToArray();
        }
        /// <summary>
        /// Upload file to web service
        /// </summary>
        /// <param name="fileUpload"></param>
        /// <param name="storeFile"></param>
        /// <param name="transferSpeed"></param>
        /// <returns></returns>
        public WahooServiceLog Upload(string fileUpload, Boolean storeFile, double transferSpeed)
        {
            WahooServiceLog result = new WahooServiceLog();
            //Programaticly enable client to send MTOM encoded messages
            //hl7Service.RequireMtom = true;
            try
            {
                string fileName = Path.GetFileName(fileUpload);
                int NumRetries = 0;
                long offset = 0;
                int ChunkSize = Convert.ToInt32(transferSpeed * 1024);
                byte[] buffer = new byte[ChunkSize];
                // read the file and return the byte[]
                using (FileStream fs = new FileStream(fileUpload, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    fs.Position = offset;
                    int BytesRead;	// = fs.Read(Buffer, 0, ChunkSize);	// read the first chunk in the buffer
                    // send the chunks to the web service one by one, until FileStream.Read() returns 0, meaning the entire file has been read.
                    do
                    {
                        Boolean endOfFile = false;
                        BytesRead = fs.Read(buffer, 0, ChunkSize);	// read the next chunk (if it exists) into the buffer.  the while loop will terminate if there is nothing left to read

                        // check if this is the last chunk and resize the bufer as needed to avoid sending a mostly empty buffer (could be 10Mb of 000000000000s in a large chunk)
                        if (BytesRead != buffer.Length)
                        {
                            endOfFile = true;
                            ChunkSize = BytesRead;
                            byte[] TrimmedBuffer = new byte[BytesRead];
                            Array.Copy(buffer, TrimmedBuffer, BytesRead);
                            buffer = TrimmedBuffer;	// the trimmed buffer should become the new 'buffer'
                            fs.Close();
                            BytesRead = 0;
                            if (storeFile)
                            {
                                string pathDirectory = Path.GetDirectoryName(fileUpload);
                                pathDirectory += "\\Backup";
                                if (!Directory.Exists(pathDirectory))
                                {
                                    Directory.CreateDirectory(pathDirectory);
                                }
                                pathDirectory += "\\" + DateTime.Now.ToString("yyyyMMdd");
                                if (!Directory.Exists(pathDirectory))
                                {
                                    Directory.CreateDirectory(pathDirectory);
                                }
                                pathDirectory += "\\" + Path.GetFileName(fileUpload);
                                if (File.Exists(pathDirectory))
                                {
                                    File.Delete(pathDirectory);
                                }
                                File.Move(fileUpload, pathDirectory);
                            }
                            else
                            {
                                File.Delete(fileUpload);
                            }
                            result.ErrorStatus = AliasMessage.SUCCESSED_STATUS;
                            result.Description = "Upload file " + fileUpload + " to server success at " + DateTime.Now.ToString("HH:mm:ss") + "," + DateTime.Now.ToString("dd/MM/yyyy") + ".";

                        }
                        if (buffer.Length == 0)
                        {
                            _WahooService.UploadFile(buffer, offset, this._mServerFolder, fileName, storeFile, endOfFile);
                            break;	// nothing more to send
                        }
                        try
                        {
                            // send this chunk to the server.  it is sent as a byte[] parameter, but the client and server have been configured to encode byte[] using MTOM. 
                            if (_WahooService.UploadFile(buffer, offset, this._mServerFolder, fileName, storeFile, endOfFile))
                            {
                                // Offset is only updated AFTER a successful send of the bytes. this helps the 'retry' feature to resume the upload from the current Offset position if AppendChunk fails.
                                offset += BytesRead;	// save the offset position for resume
                            }
                            else
                            {
                                // rewind the filestream and keep trying
                                fs.Position -= BytesRead;

                                if (NumRetries++ >= MAX_RETRIES) // too many retries, bail out
                                {
                                    result.ErrorStatus = AliasMessage.FAILED_STATUS;
                                    result.Description = "Upload file " + fileUpload + " have error.";
                                    fs.Close();
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Exception: " + ex.ToString());

                            // rewind the filestream and keep trying
                            fs.Position -= BytesRead;

                            if (NumRetries++ >= MAX_RETRIES) // too many retries, bail out
                            {
                                result.ErrorStatus = AliasMessage.FAILED_STATUS;
                                result.Description = "Upload file " + fileUpload + " have error." + ex.Message + ".";
                                fs.Close();
                                break;
                            }
                        }
                    } while (BytesRead > 0);
                }
            }
            catch (Exception ex)
            {
                result.ErrorStatus = AliasMessage.FAILED_STATUS;
                result.Description = "Upload file " + fileUpload + " have error." + ex.Message + ".";
            }
            result.FileName = fileUpload;
            return result;
        }

        /// <summary>
        /// Upload file to server
        /// </summary>
        /// <param name="fileUpload"></param>
        /// <param name="storeFile"></param>
        /// <param name="transferSpeed"></param>
        /// <returns></returns>
        public ArrayList UploadFile(string fileUpload, Boolean storeFile, double transferSpeed)
        {
            try
            {
                ArrayList arrResult = new ArrayList();
                arrResult.Add(Upload(fileUpload, storeFile, transferSpeed));
                return arrResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Upload folder
        /// </summary>
        /// <param name="fileUpload"></param>
        /// <param name="storeFile"></param>
        /// <param name="transferSpeed"></param>
        /// <returns></returns>
        public ArrayList UploadFolder(string fileUpload, Boolean storeFile, double transferSpeed)
        {
            ArrayList arrResult = new ArrayList();
            try
            {
                string[] files = Directory.GetFiles(fileUpload);
                foreach (string file in files)
                {
                    if (file != "")
                    {
                        arrResult.Add(Upload(file, storeFile, transferSpeed));
                    }
                }
                return arrResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Write file when download
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public Boolean WriteBinarFile(byte[] fs, string path)
        {
            try
            {
                if (fs.Length == 0)
                {
                    return false;
                }
                MemoryStream memoryStream = new MemoryStream(fs);
                FileStream fileStream = new FileStream(path, FileMode.Create);
                memoryStream.WriteTo(fileStream);
                memoryStream.Close();
                fileStream.Close();
                fileStream = null;
                memoryStream = null;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Download file
        /// </summary>
        /// <param name="fileDownload"></param>
        /// <param name="storeFile"></param>
        /// <param name="transferSpeed"></param>
        /// <returns></returns>
        public ArrayList DownloadFolder(string localFolder, Boolean storeFile, double transferSpeed)
        {
            try
            {
                ArrayList arrResult = new ArrayList();
                object[] filesToDownload = _WahooService.GetDownloadFiles(this._mServerFolder);
                foreach (string file in filesToDownload)
                {
                    WahooServiceLog log = this.DownloadFile(localFolder, file, storeFile, transferSpeed);
                    if (log != null)
                    {
                        arrResult.Add(log);
                    }
                }
                return arrResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Download file
        /// </summary>
        /// <param name="fileDownload"></param>
        /// <param name="storeFile"></param>
        /// <param name="transferSpeed"></param>
        /// <returns></returns>
        public WahooServiceLog DownloadFile(string localFolder, string file, Boolean storeFile, double transferSpeed)
        {
            try
            {
                WahooServiceLog log = null;
                if (!file.Contains(".part"))
                {
                    log = new WahooServiceLog();
                    try
                    {
                        //Programaticly enable client to send MTOM encoded messages
                        //hl7Service.RequireMtom = true;
                        int Offset = 0;
                        int ChunkSize = Convert.ToInt32(transferSpeed * 1024);
                        int NumRetries = 0;
                        string LocalFilePath = localFolder + "\\" + Path.GetFileName(file);
                        if (Offset == 0 && File.Exists(LocalFilePath))   // create a new empty file
                            File.Create(LocalFilePath).Close();

                        long FileSize = _WahooService.GetFileSize(this._mServerFolder, Path.GetFileName(file));   // the file is on the server and we need to know how big it is before we start downloading, in order to give accurate feedback to the user.                

                        // open a file stream for the file we will write to in the start-up folder
                        using (FileStream fs = new FileStream(LocalFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            fs.Seek(Offset, SeekOrigin.Begin);

                            // download the chunks from the web service one by one, until all the bytes have been read, meaning the entire file has been downloaded.
                            while (Offset < FileSize)
                            {
                                try
                                {
                                    // although the DownloadChunk returns a byte[], it is actually sent using MTOM because of the configuration settings. 
                                    byte[] Buffer = _WahooService.DownloadFile(this._mServerFolder, Path.GetFileName(file), Offset, ChunkSize, storeFile);
                                    fs.Write(Buffer, 0, Buffer.Length);
                                    Offset += Buffer.Length;	// save the offset position for resume
                                }
                                catch (Exception ex)
                                {
                                    // swallow the exception and try again
                                    Debug.WriteLine("Exception: " + ex.ToString());

                                    if (NumRetries++ >= MAX_RETRIES)	// too many retries, bail out
                                    {
                                        fs.Close();
                                        log.ErrorStatus = AliasMessage.FAILED_STATUS;
                                        log.Description = "Download file " + Path.GetFileName(file) + " from server have error.";
                                        break;
                                    }
                                }
                            }
                            log.ErrorStatus = AliasMessage.SUCCESSED_STATUS;
                            log.Description = "Download file from server to " + Path.GetFileName(file) + " success at " + DateTime.Now.ToString("HH:mm:ss") + "," + DateTime.Now.ToString("dd/MM/yyyy") + ".";
                        }
                    }
                    catch (Exception ex)
                    {
                        log.ErrorStatus = AliasMessage.FAILED_STATUS;
                        log.Description = "Download file " + Path.GetFileName(file) + " from server have error. File in server is not exists.";
                    }
                    log.FileName = Path.GetFileName(file);
                }
                return log;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object[] GetDownloadFiles()
        {
            return _WahooService.GetDownloadFiles(this._mServerFolder);
        }
        /// <summary>
        /// Check web service is connected
        /// </summary>
        /// <returns></returns>
        public Boolean CheckConnect()
        {
            try
            {
                _WahooService.GetDownloadFiles(@"\Incomming");
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Create directory in server
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Boolean CreateDirectory(string path)
        {
            return this._WahooService.CreateDirectory(path);
        }

        public Boolean UploadBlowfishKey(string blowfishKey)
        {
            return this._WahooService.UploadBlowfishKey(blowfishKey);
        }
        #endregion function
    }
    public class TrustAllCertificatePolicy : System.Net.ICertificatePolicy
    {
        public TrustAllCertificatePolicy()
        {

        }
        public bool CheckValidationResult(ServicePoint sp, X509Certificate cert, WebRequest req, int problem)
        {
            return true;
        }
    }
}
