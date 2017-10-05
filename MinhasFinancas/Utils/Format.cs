using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinhasFinancas.Utils
{
    public class Format
    {
        public static string GetFormattedDateNow(string format)
        {
            DateTime dateTime = DateTime.Now;
            string fmt = dateTime.ToString(format);

            return fmt;
        }
    }
}