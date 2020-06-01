using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace WeatherForecast.Application.Helpers
{
    public static class StringHelpers
    {
        public static string ToTitleCase(this string title)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
        }
    }
}