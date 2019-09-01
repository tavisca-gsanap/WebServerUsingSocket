using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WebServerUsingSocket
{
    public class RESTApiHandler : IHttpHandler
    {
        public void Handle(WebApp webApp, HTTPListenerContext context)
        {
            HTTPListenerRequest request = context.Request;
            HTTPListenerResponse response = context.Response;

            //Console.WriteLine(request.Url);
            Console.WriteLine("WebApp {0} Got request for url {1}", webApp.Name, request.Url.OriginalString);
            string absolutePath = ParseRequest(webApp, request);
            byte[] buffer;
            try
            {
                buffer = FileReader(webApp, absolutePath);
            }
            catch (FileNotFoundException exception)
            {
                string responseString = "<HTML><BODY><hr><br><h1>Error 404 file not found</h1><br><hr></BODY></HTML>";
                buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.StatusCode = (int)HttpStatusCode.NotFound;
            }

            response.ContentType = request.ContentType ?? MIMEAssistant.GetMIMEType(absolutePath);

            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            //if(buffer.Length>)
            //here it gives exception for large files
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
        }

        private string ParseRequest(WebApp webApp, HTTPListenerRequest request)
        {
            Uri url = request.Url;
            string filePath = url.AbsolutePath.Remove(0, 1);
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
