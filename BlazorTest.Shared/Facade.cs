using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public static class Facade
    {
		static Checker _checker;

		public static  Checker Checker
		{
			get
			{
				if (_checker == null) _checker = new Checker();
				return _checker;
			}
		}
    }


	public class Checker
	{
		CodeChecker _code = null;
		public CodeChecker Code
		{
			get
			{
				if (_code == null) _code = new CodeChecker();
				return _code;
			}
		}
	}


}
