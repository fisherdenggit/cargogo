using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using CargoGo.Models;

namespace CargoGo.Util
{
    public class WeChatTool
    {
        private string nickName;
        private string openID;
        private int permission;//用户操作权限，默认为0，只能浏览最基本的发货信息
        //private string sessionKey;
        public string OpenID { get { return openID; } }

        public string NickName { get { return nickName; } }

        public int Permission { get { return permission; } }
        
        public string TencentWeChatAPIUrlForCheckLogin { get; set; }

        protected string WeChatAPPID { get; set; }

        protected string WeChatSecretString { get; set; }

        public string WeChatLoginCode { get; set; }

        public string WeChatGrantType { get; set; }

        public WeChatTool()
        {
            nickName = "-1";
            openID = "-1";
            permission = 0;
            this.WeChatGrantType = "authorization_code";//此处假定微信小程序平台的登录服务器对换取登录令牌的此参数值长期不变
        }

        public WeChatTool(String weChatAPPID,String weChatSecretString)
        {
            openID = "-1";
            this.WeChatAPPID = weChatAPPID;
            this.WeChatSecretString = weChatSecretString;
            this.WeChatGrantType = "authorization_code";//此处假定微信小程序平台的登录服务器对换取登录令牌的此参数值长期不变
        }

        public bool LoadOpenID()
        {
            Boolean result = false;
            try
            {
                //组成向微信小程序登录服务器页面发出请求的地址并附上对应的参数
                String fullUrl = this.TencentWeChatAPIUrlForCheckLogin + "?appid=" + this.WeChatAPPID;
                fullUrl += "&secret=" + this.WeChatSecretString + "&js_code=" + this.WeChatLoginCode;
                fullUrl += "&grant_type=" + this.WeChatGrantType;
                //System.IO.File.AppendAllText("d:/log.txt","this is the fullURL:" + fullUrl);
                Console.WriteLine("this is the fullURL:" + fullUrl);
                
                //发起一个HttepWebRequest，获取返回的HttpWebResponse
                HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create(fullUrl);
                hwr.Method = "GET";
                HttpWebResponse hwre = (HttpWebResponse)hwr.GetResponse();

                //从HttpWebResponse中获取含Stream,用StreamReader读取出所有的返回内容
                System.IO.Stream ioStream = hwre.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(ioStream, System.Text.Encoding.UTF8);
                String strResponse = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
                ioStream.Close();
                ioStream.Dispose();
                hwre.Close();
                hwre.Dispose();

                //从返回结果的字符串中搜索"openid:"关键字，并将对应值取出
                String key = "\"openid\":\"";
                int startIndex = strResponse.IndexOf(key);
                if(startIndex!=-1)
                {
                    int endIndex = strResponse.IndexOf("\"}", startIndex);
                    openID = strResponse.Substring(startIndex + key.Length, endIndex - startIndex - key.Length);
                    //System.IO.File.AppendAllText("d:/log.txt", "this is the openid:" + openID);
                    Console.WriteLine("this is the openid:" + openID);
                    if(!openID.Equals("-1"))
                    {
                        result = true;
                    }
                }
            }
            catch(Exception e)
            {
                //System.IO.File.AppendAllText("d:/log.txt", e.Message);
                Console.WriteLine(e.Message);
            }
            return result;
            
        }

        public bool LoadNickName(String queryStringNickName)
        {
            Boolean result = false;
            if(!this.openID.Equals("-1"))
            {
                this.nickName = queryStringNickName;
                result = true;
            }
            return result;
        }

        public bool SaveOpenIDandNickName(String openId,String nickName)
        {
            Boolean result = false;
            try
            {
                MyDBContext conn = new MyDBContext();
                MyUser tempUser = new MyUser();
                tempUser.MyWeChatUserOpenID = openId;
                tempUser.MyWeChatUserNickName = nickName;
                tempUser.Permission = 0;
                List<MyUser> myUsers = conn.MyUsers.ToList();
                Boolean openIDExist = false;
                for (int i=0;i<myUsers.Count();i++)
                {
                    if(tempUser.MyWeChatUserOpenID.Equals(myUsers[i].MyWeChatUserOpenID))
                    {
                        this.permission = myUsers[i].Permission;
                        openIDExist = true;
                        break;
                    }
                }
                if (!openIDExist)
                {
                    conn.MyUsers.Add(tempUser);
                    conn.SaveChanges();
                    result = true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
    }
}