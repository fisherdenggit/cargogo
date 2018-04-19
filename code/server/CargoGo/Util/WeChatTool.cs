using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace CargoGo.Util
{
    public class WeChatTool
    {

        private string openID;
        private string SessionKey;
        public string OpenID { get { return openID; } }
        
        public string TencentWeChatAPIUrlForCheckLogin { get; set; }

        public string WeChatLoginCode { get; set; }

        public bool LoadOpenID()
        {
            try
            {
                HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create(TencentWeChatAPIUrlForCheckLogin);
                hwr.Method = "GET";
                HttpWebResponse wr = (HttpWebResponse)hwr.GetResponse();
                openID = wr.Headers["openid"];
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }
    }
}