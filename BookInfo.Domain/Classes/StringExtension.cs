using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Domain.Classes
{
    public static class StringExtension
    {
         public static string CombineWith(this string[] array, char character)
        {
            string newString = "";
            foreach (var item in array)
            {
                if (newString == "")
                    newString = item;
                else
                    newString = newString + character + item;
            }
            return newString;
        }

        public static int GetNumOfWeek(this string week)
        {
            string[] weekArray = { "شنبه", "یکشنبه", "دوشنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه" };
            return Array.IndexOf(weekArray, week);
        }

        public static string[] GetMonth()
        {
            string[] month = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
            return month;
        }
    }
}
