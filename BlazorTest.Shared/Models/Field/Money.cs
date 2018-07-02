using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public class Money : DecimalProperty
    {
        public Money(string value) : base(value) {
            Format = null;  //既定値
            PositiveDigit = 7;//最大桁数 9,999,999
            DecimalDigit = 0;
        }
    }
}
