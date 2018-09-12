using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;

namespace BlazorTest.Library
{
    public static　class ElementRefExtensions
    {
        public static void Focus(this ElementRef elementRef)
        {
			JSRuntime.Current.InvokeAsync<object>("BlazorFocus.FocusElement", elementRef);
//			RegisteredFunction.Invoke<object>("BlazorFocus.FocusElement", elementRef);
        }
    }
}
