using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public class Money : DecimalProperty
    {
        public Money(string value) : base(value) {
            Format = null;  //既定値
            PositiveDigit = 14;
            DecimalDigit = 0;
        }
    }
}
