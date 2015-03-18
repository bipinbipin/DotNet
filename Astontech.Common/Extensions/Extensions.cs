using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astontech.Common.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// This trys to convert a string to datetime if its valid it returs otherwise it returns DateTime.MinValue
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime ToDate(this string s)
        {
            DateTime dateTime;

            if (DateTime.TryParse(s, out dateTime))
                return dateTime;
            else
                return DateTime.MinValue;
        }

        /// <summary>
        /// Attemps to convert string to valid integer. if failed returns 0
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(this string s)
        {
            int intValue = 0;

            if (int.TryParse(s, out intValue))
                return intValue;
            else
                return 0;
        }
    }
}
