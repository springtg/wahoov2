using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using HL7Source.WebService;
using System.Diagnostics;
using System.Net;

namespace HL7Source
{
    public class HL7Service
    {
        #region variable

        private const int MAX_RETRIES = 3;
        //Web service
        private WebService.Service _WahooService = null;
        private WebService.AuthSoapHd objAuthSoapHeader = new WebService.AuthSoapHd();
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

        public HL7Service(string url)
        {
            _WahooService = new WebService.Service();
            _WahooService.Url = url;
            objAuthSoapHeader.strPassword = PASSWORD;
            objAuthSoapHeader.strUserName = USERNAME;
            _WahooService.AuthSoapHdValue = objAuthSoapHeader;
        }

        #endregion constructor

        #region function

        /// <summary>
        /// getBinaryFileÅFReturn array of byte which you specified.
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
        /// ConvertStreamToByteBufferÅFConvert Stream To ByteBuffer.
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
        /// Upload file 
        /// </summary>
        /// <param name="fileUpload"></param>
        /// <returns></returns>
        public HL7Log Upload(string fileUpload, Boolean storeFile, double transferSpeed)
        {
            HL7Log result = new HL7Log();
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
                            result.ErrorStatus = Alias.SUCCESSED_STATUS;
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
                                    result.ErrorStatus = Alias.FAILED_STATUS;
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
                                result.ErrorStatus = Alias.FAILED_STATUS;
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
                result.ErrorStatus = Alias.FAILED_STATUS;
                result.Description = "Upload file " + fileUpload + " have error." + ex.Message + ".";
            }
            result.FileName = fileUpload;
            return result;
        }

        /// <summary>
        /// Upload folder
        /// </summary>
        /// <param name="fileUpload"></param>
        /// <returns></returns>
        public ArrayList UploadFolder(string fileUpload, Boolean storeFile, double transferSpeed)
        {
            ArrayList arrResult = new ArrayList();
            try
            {
                string[] files = Directory.GetFiles(fileUpload);
                foreach (string file in files)
                {
                    if (CheckFileToUpload(file))
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
        /// Check file to upload
        /// </summary>
        /// <param name="fileUpload"></param>
        /// <returns></returns>
        private Boolean CheckFileToUpload(string fileUpload)
        {
            if (fileUpload == "")
            {
                return false;
            }
            if (!File.Exists(fileUpload))
            {
                return false;
            }
            return true;
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

        /// <summary>
        /// Check exists directory in server
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Boolean CheckExistsDirectory(string path)
        {
            return this._WahooService.CheckExistsDirectory(path);
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
        /// <returns></returns>
        public HL7Log DownloadFile(string localFolder, string file, Boolean storeFile)
        {
            try
            {
                HL7Log log = new HL7Log();
                if (!file.Contains(".part"))
                {
                    try
                    {
                        //Programaticly enable client to send MTOM encoded messages
                        //_mHL7WebService.RequireMtom = true;
                        int Offset = 0;
                        int ChunkSize = 16 * 1024;
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
                                        log.ErrorStatus = Alias.FAILED_STATUS;
                                        log.Description = string.Format(HL7Source.Message.GetMessageById("LOG006"), Path.GetFileName(file));
                                        break;
                                    }
                                }
                            }
                            log.ErrorStatus = Alias.SUCCESSED_STATUS;
                            log.Description = string.Format(HL7Source.Message.GetMessageById("LOG007"), Path.GetFileName(file), DateTime.Now.ToString("HH:mm:ss") + "," + DateTime.Now.ToString("dd/MM/yyyy"));
                        }
                    }
                    catch (Exception ex)
                    {
                        log.ErrorStatus = Alias.FAILED_STATUS;
                        log.Description = string.Format(HL7Source.Message.GetMessageById("LOG008"), Path.GetFileName(file));
                    }
                    log.FileName = Path.GetFileName(file);
                    log.TimeDownloaded = DateTime.Now.ToString("yyyyMMddHHmmss");
                    log.IpAddress = _WahooService.GetIpAddress();
                    if (log.ErrorStatus == Alias.SUCCESSED_STATUS)
                    {
                        log.IsDownloaded = true;
                    }
                    else
                    {
                        log.IsDownloaded = false;
                    }
                }
                return log;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long GetFileSizeToDownload(string fileName)
        {
            //Programaticly enable client to send MTOM encoded messages
            //_mHL7WebService.RequireMtom = true;
            try
            {
                return _WahooService.GetFileSize(this._mServerFolder, Path.GetFileName(fileName));
            }
            catch (Exception)
            {
                return 0;
            }

        }
        /// <summary>
        /// Get file to download
        /// </summary>
        /// <returns></returns>
        public object[] GetDownloadFiles()
        {
            return _WahooService.GetDownloadFiles(this._mServerFolder);
        }

        public string GetBlowfishKey()
        {
            return _WahooService.GetBlowfishKey();
        }

        

        #endregion function
        
    }
    public class HL7Log
    {
        public string ErrorStatus = "";
        public string Description = "";
        public string FileName = "";
        public Boolean IsDownloaded = false;
        public string TimeDownloaded = "";
        public Boolean IsSentToPrint = false;
        public string TimeSentToPrint = "";
        public string IpAddress = "";
    }
}
