using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections;

/// <summary>
/// Summary description for TransferFile
/// </summary>
public class TransferFile
{
    public TransferFile()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Boolean WriteBinarFile(byte[] buffer, long Offset, string FilePath, Boolean endOfFile)
    {
        string tempName = FilePath + ".part";
        FileStream fs = null;
        try
        {
            if (Offset == 0)	// new file, create an empty file
            {
                if (File.Exists(tempName))
                {
                    File.Delete(tempName);
                }
                File.Create(tempName).Close();
            }
            using (fs = new FileStream(tempName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
            {
                fs.Seek(Offset, SeekOrigin.Begin);
                fs.Write(buffer, 0, buffer.Length);
                if (fs != null)
                {
                    fs.Close();
                }
            }
            if (endOfFile)
            {
                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }
                File.Move(tempName, FilePath);
            }
            return true;
        }
        catch 
        {
            if (fs != null)
            {
                fs.Close();
            }
            return false;
        }
    }

    /// <summary>
    /// Download file from offset
    /// </summary>
    /// <param name="FilePath"></param>
    /// <param name="Offset"></param>
    /// <param name="BufferSize"></param>
    /// <param name="storeFile"></param>
    /// <returns></returns>
    public byte[] ReadBinaryFile(string FilePath, long Offset, int BufferSize, Boolean storeFile)
    {
        if (File.Exists(FilePath))
        {
            try
            {
                byte[] result = null;
                long FileSize = new FileInfo(FilePath).Length;
                // if the requested Offset is larger than the file, quit.
                if (Offset > FileSize)
                {
                    return new byte[0];
                }
                // open the file to return the requested chunk as a byte[]
                byte[] TmpBuffer;
                int BytesRead;
                try
                {
                    using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        fs.Seek(Offset, SeekOrigin.Begin);	// this is relevent during a retry. otherwise, it just seeks to the start
                        TmpBuffer = new byte[BufferSize];
                        BytesRead = fs.Read(TmpBuffer, 0, BufferSize);	// read the first chunk in the buffer (which is re-used for every chunk)
                    }
                    long temp = Offset + BufferSize;
                    if (BytesRead != BufferSize || temp == FileSize)
                    {
                        // the last chunk will almost certainly not fill the buffer, so it must be trimmed before returning
                        byte[] TrimmedBuffer = new byte[BytesRead];
                        Array.Copy(TmpBuffer, TrimmedBuffer, BytesRead);
                        result = TrimmedBuffer;
                        if (Path.GetFileName(FilePath).ToUpper() != "BLOWFISHKEY.TXT")
                        {
                            //Not store file
                            if (!storeFile)
                            {
                                File.Delete(FilePath);
                            }
                            //Store file to backup folder
                            else
                            {
                                string date = DateTime.Now.ToString("yyyyMMdd");
                                string pathDirectory = Path.GetDirectoryName(FilePath);
                                pathDirectory += "\\Backup";
                                if (!Directory.Exists(pathDirectory))
                                {
                                    Directory.CreateDirectory(pathDirectory);
                                }
                                pathDirectory += "\\" + date;
                                if (!Directory.Exists(pathDirectory))
                                {
                                    Directory.CreateDirectory(pathDirectory);
                                }
                                string fileNameReplace = pathDirectory + "\\" + Path.GetFileName(FilePath);
                                if (File.Exists(fileNameReplace))
                                {
                                    File.Delete(fileNameReplace);
                                }
                                File.Move(FilePath, fileNameReplace);
                            }
                        }
                    }
                    else
                        result = TmpBuffer;
                    return result;
                }
                catch
                {
                    return new byte[0];
                }
            }
            catch
            {
                return new byte[0];
            }
        }
        else
        {
            return new byte[0];
        }
    }

    /// <summary>
    /// Get files from server
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public ArrayList GetFiles(string path)
    {
        ArrayList kq = new ArrayList();
        if (Directory.Exists(path))
        {
            string[] files = Directory.GetFiles(path);
            foreach (string s in files)
            {
                kq.Add(Path.GetFileName(s));
            }
        }
        return kq;
    }

    /// <summary>
    /// ConvertStreamToByteBufferFConvert Stream To ByteBufferB
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
    /// Create directory in server
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public Boolean CreateDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Check exists directory on server
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public Boolean CheckExistsDirectory(string path)
    {
        return Directory.Exists(path);
    }
    /// <summary>
    /// Get blowfish key
    /// </summary>
    /// <param name="blowfishKeyFile"></param>
    /// <returns></returns>
    public string GetBlowfishKey(string blowfishKeyFile)
    {
        StreamReader sr = new StreamReader(blowfishKeyFile);
        string result = "";
        try
        {
            result = sr.ReadLine();
            sr.Close();
        }
        catch
        {
            sr.Close();
        }
        return result;
    }
    /// <summary>
    /// Upload Blowfish key
    /// </summary>
    /// <param name="blowfishKeyFile"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public Boolean UploadBlowfishKey(string blowfishKeyFile, string key)
    {
        if (File.Exists(blowfishKeyFile))
        {
            File.Delete(blowfishKeyFile);
        }
        StreamWriter sw = File.AppendText(blowfishKeyFile);
        Boolean result = false;
        try
        {
            sw.WriteLine(key);
            sw.Close();
            result = true;
        }
        catch
        {
            sw.Close();
        }
        return result;
    }
}
