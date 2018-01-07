using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceBookAutoLike.FaceBookFuncs;

namespace FaceBookAutoLike
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Common.Version = "v2.11";
            Common.Token = "EAAAAUaZA8jlABABEm7uVeQlyDoF7M7lJxj08WwO4oROL4MN1QY3Lh0CyZCWg3g1ORUWnsBPQohviY3kIBTQUwKxxbqzQwdmhPuENR4CbS5MNZCNWhCYoWIW2eTgQTGIIHdnYe8PfAGNhKIJQrhk8LIxcuG3vZAEZD";
            var feed = FaceBook.GetHome(FaceBook.GetFriends("me","1000"),"200");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
