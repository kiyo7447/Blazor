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
					return "001";
				case CodeEnum.StoreCode:
					throw new ApplicationException("入力エラー");
				default:
					throw new SystemException($"");
			}
			return code.ToString();
		}
    }
}
