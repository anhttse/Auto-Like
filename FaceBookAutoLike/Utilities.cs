using System;
using System.Collections.Generic;

namespace FaceBookAutoLike
{
    public static class Utilities
    {
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
    }
}
