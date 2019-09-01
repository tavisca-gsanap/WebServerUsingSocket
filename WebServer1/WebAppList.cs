using System;
using System.Collections.Generic;
using System.Text;

namespace WebServerUsingSocket
{
    public class WebAppList
    {
        public Dictionary<string, WebApp> _webAppList = new Dictionary<string, WebApp>();
        public WebApp GetWebApp(string prefix)
        {
            if (prefix.Length > 0 &&
                _webAppList.ContainsKey(prefix))
            {
                return _webAppList[prefix];
            }
            throw new WebAppNotFoundException();
        }
        public void AddWebApp(string prefix, WebApp webApp)
        {
            if(!_webAppList.ContainsKey(prefix))
                _webAppList.Add(prefix, webApp);
            else
            {
                //throw error that two webapps can't have same prefix
            }
        }
        public void RemoveWebApp(string prefix)
        {
            if (_webAppList.ContainsKey(prefix))
                _webAppList.Remove(prefix);
            else
            {
                //throw error that two webapps can't have same prefix
            }
        }
    }
    
}
