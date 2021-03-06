using System;
using System.Collections.Generic;

namespace QuizGame
{
    // class for misc code
    static class Misc
    {
        private static Random rng = new Random();  

        // shuffles elements in list
        public static void Shuffle<T>(this List<T> list)  
        {  
            int n = list.Count;  
            while (n > 1) 
            {  
                n--;  
                int k = rng.Next(n + 1);  
                T value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }  
        }
    }
}