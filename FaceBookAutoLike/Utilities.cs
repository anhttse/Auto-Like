using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FaceBookAutoLike
{
    public static class Utilities
    {
        public static  string ConnectionString { get; set; }
        public static Dictionary<int, string> RBReactions = new Dictionary<int, string>()
        {
            {1,"rbLike" },
            {2,"rbLove" },
            {3,"rbHaha" },
            {4,"rbWow" },
            {5,"rbSad" },
            {6,"rbAngry" }
        };

        public static Dictionary<int, string> Reactions { get; set; } = new Dictionary<int, string>()
        {
            {1, "LIKE"},
            {2, "LOVE"},
            {3, "HAHA"},
            {4, "WOW"},
            {5, "SAD"},
            {6, "ANGRY"}
        };

        public static void WriteLog(string msg)
        {
            using (var swr = File.AppendText("log.txt"))
            {
                swr.WriteLineAsync(DateTime.Now+": "+msg);
            }
        }

        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').ToLowerInvariant();
        }
    }
}
