using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{

    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInfoAttribute : Attribute
    {
        Type _type;       //
        string _name;

        public bool IsRequired { get; set; } = false;
        
        public PropertyInfoAttribute(string name, Type type) { _name = name; _type = type; }

        public Type Type {get { return _type; } }

        public string Name { get { return _name; } }
    }

}
