using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_revix
{
    public class Users
    {
        static string userEmail="";
        static int userID = 0;

        public static void SetUserEmail(string email)
        {
            userEmail = email;
        }
        public static string GetUserEmail()
        {
            return userEmail;
        }


        public static void SetUserID(int ID)
        {
            userID=ID;
        }
        public static int GetUserID()
        {
            return userID;
        }
    }

    
}

