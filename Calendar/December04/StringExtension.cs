﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions
{
    static class StringExtension
    {
        public static string IncrementPassword(this string str)
        {
            return (int.Parse(str) + 1).ToString();
        }
        public static string SetConsecutive(this string str)
        {
            char[] newPassword = str.ToCharArray();
            
            for (int i = 1; i < str.Length; i++)
            {
                var a = str[i];
                var b = newPassword[i - 1];
                if (char.GetNumericValue(str[i]) < char.GetNumericValue(newPassword[i-1]))
                {
                    newPassword = ReplaceRemaining(i, newPassword[i - 1], newPassword);
                    break;
                }
            }
            return new string(newPassword.ToArray());
        }

        private static char[] ReplaceRemaining(int start, char c, char[] CharArray)
        {
            for (int i = start; i < CharArray.Length; i++)
            {
                CharArray[i] = c;       
            }
            return CharArray;
        }
    }
}
