using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
	public enum CodeEnum {
		EmployeeCode,
		StoreCode
	}
    public class CodeChecker
    {
		public string Check(object code, CodeEnum codeEnum)
		{
			//数値化出来ないものは入力エラー



			switch (codeEnum)
			{
				case CodeEnum.EmployeeCode:

					if (code is string)
					{
						int i;
						if (int.TryParse(code.ToString(), out i))
							return $"{i:D6}";
						else
							throw new ApplicationException($"数字のみ入力可能");
					}
					else
					{
						throw new NotImplementedException($"コードがまだ実装中");
					}
				case CodeEnum.StoreCode:
					throw new NotImplementedException("入力エラー");
				default:
					throw new SystemException($"コードをまだ実装中");
			}
			return code.ToString();
		}

		public void IsRequire(object code, CodeEnum codeEnum)
		{
			if (code.ToString().TrimEnd().Length == 0) throw new ApplicationException($"未入力エラー");
		}
    }
}
