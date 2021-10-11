using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Útils
{
    public static class EnumExtension
    {
        public static int EvaluateEnum(this Enum @enum, Enum enumRequired)
        {
            if (Convert.ToInt32(@enum) == default)
            {
                return 0;
            }
            else if (@enum.HasFlag(enumRequired))
            {
                return 2;
            }
            if (@enum.HasFlag(enumRequired) && Convert.ToInt32(@enum) > Convert.ToInt32(enumRequired))
            {
                return 3;
            }
            else
            {
                return 1;
            }
        }
    }
}
