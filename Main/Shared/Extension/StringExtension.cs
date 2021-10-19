using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Extension
{
    public static class StringExtension
    {
        public static TEnum ConvertToEnum<TEnum>(this string str)
        {
            if (str == null)
                return default(TEnum);

            return (TEnum)Enum.Parse(typeof(TEnum), str);
        }
    }
}
