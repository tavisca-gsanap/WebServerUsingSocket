using System.Net;
using System.Net.Sockets;

namespace WebServerUsingSocket
{
    public class WebApp
    {
        //Socket _socket;
        //string rootDirecory;
        public string Name { get; }
        public IHttpHandler Handler { get; }
        public string RootDirectory { get; set; }
        public IFileSystem FileSystem { get; set; }
        //public bool HasErrorPage { get; set; }
        //public bool ErrorPagePath { get; set; }
        public WebApp(string name, string rootDirectory, string typeOfWebApp, string fileSystemType)
        {
            Name = name;
            RootDirectory = rootDirectory;
            Handler = HttpHandlerFactory.GetHttpHandler(typeOfWebApp);
            FileSystem = FileSystemFactory.GetFileSystem(fileSystemType);
        }

    }
}