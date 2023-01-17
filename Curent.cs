using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_revix
{
   public class Curent
    {
        static int toateID = 0;   //sa tin minte la ce film/serial adaug recenzia 
        static string previousWindow = "";
        public static void SetToateID(int ID)
        {
            toateID = ID;
        }
        public static int GetToateID()
        {
            return toateID;
        }

        public static void SetWindow(string window)
        {
            previousWindow = window;
        }
        public static string GetWindow()
        {
            return previousWindow;
        }
    }
}




  
