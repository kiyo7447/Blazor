using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class AuthorAttribute : Attribute
    {
        private string _name;       // 作者名
        public string Affiliation; // 作者所属
        public AuthorAttribute(string name) { _name = name; }

        public string Name {get { return _name; } }
    }

}
