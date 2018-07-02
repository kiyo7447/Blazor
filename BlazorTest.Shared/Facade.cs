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

        public static string NilStr(string format,  params string[] param)
        {
            if (param.Length == 0) return "";
            return String.Format(format, param);
        }

    }


    //public class Checker
    //{
    //	Checker _code = null;
    //	public Checker Code
    //	{
    //		get
    //		{
    //			if (_code == null) _code = new Checker();
    //			return _code;
    //		}
    //	}
    //}


}
