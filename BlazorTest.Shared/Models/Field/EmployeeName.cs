using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    class EmployeeName : TextProperty
    {
        public EmployeeName(string value) : base(value)
        {
            MaxLength = 12;//許されるのは"Kiyotaka Abe"
        }
    }
}
