using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoGo.Models
{
    public class MyUser
    {
        public static bool IsLogin(string inputKey)
        {
            return false;
        }
        private static bool Check3rdSessionKey(string input3rdSessionKey)
        {
            return false;
        }

        public int ID { get; set; }

        public string MyWeChatUserOpenID { get; set; }

        public string MyWeChatUserNickName { get; set; }    
        public string MobileNumber { get; set; }
    }
}