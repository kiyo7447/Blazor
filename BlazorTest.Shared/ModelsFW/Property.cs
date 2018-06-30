using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public abstract class Property
    {
        public Property(string value)
        {
            InputValue = value;
        }

        public string InputValue { get; set; } = "";

        public abstract void Validate();

        public override string ToString() { return base.ToString(); }


        public bool IsRequired { get; set; }

        public string Name { get; set; }
    }
}
