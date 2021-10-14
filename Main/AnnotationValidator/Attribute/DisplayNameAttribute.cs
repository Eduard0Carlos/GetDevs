using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnotationValidator.Attribute
{
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class DisplayNameAttribute : System.Attribute
    {
        public string DisplayName { get; set; }
        public DisplayNameAttribute(string displayName)
        {
            this.DisplayName = displayName;
        }

    }
}
