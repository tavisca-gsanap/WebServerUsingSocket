using System.IO;

namespace WebServer1
{
    public static class FileReader
    {
        public static byte[] GetFileStream(FileInfo fileInfo)
        {
            FileStream fileStream = fileInfo.OpenRead();
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, buffer.Length);
            return buffer;
        }
    }
}