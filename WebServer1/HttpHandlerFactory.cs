using System;
using System.Collections.Generic;
using System.Text;

namespace WebServerUsingSocket
{
    public static class HttpHandlerFactory
    {
        public static IHttpHandler GetHttpHandler(string typeOfWebApp)
        {
            switch (typeOfWebApp.ToLower())
            {
                case "static":
                    return new StaticFileHandler();
                case "api":
                    return new RESTApiHandler();
                default:
                    throw new InvalidFileSystemException();
            }
        }
    }
}
