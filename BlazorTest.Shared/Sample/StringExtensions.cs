using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public static class StringExtensions
    {
        public static string GetHoge(this string str, string test)
        {
            return test + "ok";
        } 
    }
}
