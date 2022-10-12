using System;

namespace Core.Jwt.Demo.Attributes
{
    [AttributeUsage(AttributeTargets.Method|AttributeTargets.Class)]
    public class IgnoreActionAttribute: Attribute
    {

    }
}
