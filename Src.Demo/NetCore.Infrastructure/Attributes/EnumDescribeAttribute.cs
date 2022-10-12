using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDescribeAttribute : Attribute
    {
        public EnumDescribeAttribute(string label)
        {
            this.Label = label;
        }
        public string Label
        {
            get;
            set;
        }
    }
}
