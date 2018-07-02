﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    class EmployeeName : TextProperty
    {
        public EmployeeName(string value) : base(value)
        {
            MaxLength = 50;
        }

        public override void Validate()
        {
            base.Validate();
        }
    }
}
