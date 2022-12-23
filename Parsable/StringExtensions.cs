using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsable
{
    public static class StringExtensions
    {
        public static int CountWords(this string s) 
        {
            return s.Split(',').Length; 
        } 

        public static T Parse<T>(this string s) where T : IParsable<T>
        {
            return T.Parse(s,null);
        }

    }
}
