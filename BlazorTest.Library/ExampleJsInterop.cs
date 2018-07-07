using System;
using Microsoft.AspNetCore.Blazor.Browser.Interop;

namespace BlazorTest.Library
{
    public class ExampleJsInterop
    {
        public static string Prompt(string message)
        {
            return RegisteredFunction.Invoke<string>(
                "BlazorTest.Library.ExampleJsInterop.Prompt",
                message);
        }

		public static void SetFocus(string id)
		{
			RegisteredFunction.Invoke<string>(
				"BlazorTest.Library.ExampleJsInterop.Focus",id);
		}
	}
}
