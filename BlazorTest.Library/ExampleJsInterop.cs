using System;
using Microsoft.JSInterop;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Blazor.Browser.Interop;

namespace BlazorTest.Library
{
    public class ExampleJsInterop
    {
        public static Task<string> Prompt(string message)
        {
            return JSRuntime.Current.InvokeAsync<string>(
                "BlazorTest.Library.ExampleJsInterop.Prompt",
                message);
        }

		public static Task<bool> Confirm(string message)
		{
			return JSRuntime.Current.InvokeAsync<bool>(
				"BlazorTest.Library.ExampleJsInterop.Confirm",
				message);
		}

		public static void SetFocus(string id)
		{
			JSRuntime.Current.InvokeAsync<string>(
				"BlazorTest.Library.ExampleJsInterop.Focus",id);
		}
	}
}
