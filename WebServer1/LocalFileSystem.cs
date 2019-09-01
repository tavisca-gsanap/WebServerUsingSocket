using System.IO;

namespace WebServerUsingSocket
{
    public class LocalFileSystem : IFileSystem
    {
        public bool TryGetFile(string physicalPath, out FileInfo fileInfo)
        {
            fileInfo = new FileInfo(physicalPath);
            return fileInfo.Exists;
        }

        public byte[] ReadFile(FileInfo fileInfo)
        {
            FileStream fileStream = fileInfo.OpenRead();
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, buffer.Length);
            return buffer;
        }
    }
}
