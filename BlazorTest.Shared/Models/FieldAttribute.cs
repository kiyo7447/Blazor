using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{

    [AttributeUsage(AttributeTargets.Property)]
    public class FieldAttribute : Attribute
    {
        private Type _type;       // 作者名
        public string Affiliation; // 作者所属

        public bool IsRequire { get; set; } = false;
        

        public FieldAttribute(Type type) { _type = type; }

        public Type Type {get { return _type; } }
    }

}
