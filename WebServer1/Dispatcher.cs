using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace WebServerUsingSocket
{
    public class Dispatcher
    {
        public void Dispatch(Server server, HTTPListenerContext HTTPListenerContext)
        {
            var url = HTTPListenerContext.Request.Url;
            try
            {
                Debug.WriteLine("Site name we got : "+ url.GetLeftPart(new UriPartial()) + url.Host + "/");
                WebApp webApp = server.WebAppList.GetWebApp(url.GetLeftPart(new UriPartial()) + url.Host + "/");
                webApp.Handler.Handle(webApp, HTTPListenerContext);
            }
            catch(WebAppNotFoundException exception)
            {
                var response = HTTPListenerContext.Response;
                
                byte[] buffer;
                string responseString = "<HTML><BODY><hr><br><h1>Error Website Not Found!<br> Register your Website with server.</h1><br><hr></BODY></HTML>";
                buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.Write(buffer);

                Console.WriteLine(exception);
            }
        }
    }
}
