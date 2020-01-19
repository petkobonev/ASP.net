using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsAplication.Helpers
{
    public class LoginSession
    {

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }

        public bool IsAuthenticated { get; set; }
       

        private LoginSession()
        {
            IsAuthenticated = false;
        }

        public static LoginSession Current
        {
            get
            {
                LoginSession loginUserSession = (LoginSession)HttpContext.Current.Session["LoginUser"];
                if (loginUserSession == null)
                {
                    loginUserSession = new LoginSession();
                    HttpContext.Current.Session["LoginUser"] = loginUserSession;
                }
                return loginUserSession;
            }
        }

        public void SetCurrentUser(int userID, string username, string name)
        {
            this.IsAuthenticated = true;
            this.Name = name;
            this.UserID = userID;
            this.Username = username;
        }

        public void Logout()
        {
            this.IsAuthenticated = false;      
            this.UserID = -1;
            this.Username = string.Empty;
        }


    }
}