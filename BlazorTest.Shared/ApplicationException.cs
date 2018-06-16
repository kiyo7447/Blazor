using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public class ApplicationException : Exception
    {
		public ApplicationException(string errmsg) :base(errmsg)
		{
			
		}
    }
}
