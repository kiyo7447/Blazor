using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;

namespace BlazorTest.Library
{
    public static　class ElementRefExtensions
    {
        public static void Focus(this ElementRef elementRef)
        {
            RegisteredFunction.Invoke<object>("BlazorFocus.FocusElement", elementRef);
        }
    }
}
