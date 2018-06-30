using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public class EmployeeCode : CodeProperty
    {
        public EmployeeCode(string value) : base(value)
        {
            MaxLength = 6;
        }


    }
}
