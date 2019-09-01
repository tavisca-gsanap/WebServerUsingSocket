using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace WebServerUsingSocket
{
    public class StaticFileHandler : IHttpHandler
    {
        public void Handle(WebApp webApp, HTTPListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;
            
            Console.WriteLine("WebApp {0} Got request for url {1}", webApp.Name, request.Url.OriginalString);
            string absolutePath = ParseRequest(webApp, request);
            byte[] buffer;
            try
            {
                buffer = FileReader(webApp, absolutePath);
            }
            catch(FileNotFoundException exception)
            {
                string responseString = "<HTML><BODY><hr><br><h1>Error 404 file not found</h1><br><hr></BODY></HTML>";
                buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            
            response.ContentType = request.ContentType ?? MIMEAssistant.GetMIMEType(absolutePath);

            response.Write(buffer);
            context.Socket.Close();
        }

        private string ParseRequest(WebApp webApp, HTTPListenerRequest request)
        {
            Uri url = request.Url;
            string filePath = url.AbsolutePath.Remove(0,1);
            if (filePath.Equals("") || filePath.EndsWith('/'))
                return filePath + "index.html";
            return filePath;
        }

        private byte[] FileReader(WebApp webApp, string absolutePath)
        {
            string filePath = webApp.RootDirectory + absolutePath;
            IFileSystem fileSystem = webApp.FileSystem;
            FileInfo fileInfo;

            if (fileSystem.TryGetFile(filePath, out fileInfo))
            {
                return fileSystem.ReadFile(fileInfo);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
