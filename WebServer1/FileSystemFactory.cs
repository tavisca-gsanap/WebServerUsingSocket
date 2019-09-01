namespace WebServerUsingSocket
{
    public static class FileSystemFactory
    {
        public static IFileSystem GetFileSystem(string fileSystem)
        {
            switch (fileSystem.ToLower())
            {
                case "local":
                    return new LocalFileSystem();
                default:
                    throw new InvalidFileSystemException();
            }
        }
    }
}
