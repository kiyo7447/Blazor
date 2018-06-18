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
						if (int.TryParse(code.ToString(), out int i))
							return $"{i:D6}";
						else
							throw new ApplicationException($"数字のみ入力可能です。");
					}
					else
					{
						throw new NotImplementedException($"コードがまだ実装中です。");
					}
				case CodeEnum.StoreCode:
					throw new NotImplementedException("コードがまだ実装中です。");
				default:
					throw new SystemException($"コードをまだ実装中です。");
			}
		}

		public void IsRequire(object code, CodeEnum codeEnum)
		{
			if (code.ToString().TrimEnd().Length == 0) throw new ApplicationException($"未入力エラーです。");
		}
    }
}
