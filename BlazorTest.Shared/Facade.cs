using System;
using System.Collections.Generic;
using System.Reflection;
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

		public static object ObjectCopy(object from, object to)
		{
			var fromProperties = from.GetType().GetProperties();
			var toProperties = to.GetType().GetProperties();
			var toFields = to.GetType().GetFields();

			Func<PropertyInfo[], string, PropertyInfo> GetProperty = (PropertyInfo[] targetsProperty, string name) => {
				foreach (var pro in targetsProperty)
					if (pro.Name == name)
						return pro;
				return null;
			};

			foreach(var toPro in toProperties)
			{
				var fromPro = GetProperty(fromProperties, toPro.Name);
				if (fromPro != null)
				{
					var fromValue = fromPro.GetValue(from);
					toPro.SetValue(to, fromValue);
				}
				else
				{
					//コピーしない
				}
			}
			return to;
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
