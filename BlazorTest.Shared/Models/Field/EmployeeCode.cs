using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public class EmployeeCode : CodeProperty
    {
        public EmployeeCode(string value, string name = null, bool isRequired = false) : base(value, name, isRequired)
        {
            MaxLength = 6;
        }
    }
}
