using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public abstract class BaseProperty
    {
        public BaseProperty(string value)
        {
            InputValue = value == null ? String.Empty: value;
        }

        public string InputValue { get; set; } = "";

        public abstract string Validate();

        public override string ToString() { return base.ToString(); }


        public bool IsRequired { get; set; }

        public string Name { get; set; }
    }
}
