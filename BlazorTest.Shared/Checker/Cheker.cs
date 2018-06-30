using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public enum CodeEnum
    {
        EmployeeCode,
        StoreCode
    }
    public class Checker
    {
        public T GetField<T>(object value) where T : Text
        {

            if (typeof(T) == typeof(EmployeeCode))
                return new EmployeeCode(value.ToString()) as T;
            //var a = new EmployeeCode();
            //if a.return (T)a;
            return null;
        }

        public void Validate(object model, string fieldName)
        {
            var propertyInfo = model.GetType().GetProperty(fieldName);

            //propertyInfo.GetValue()
            //propertyInfo.GetCustomAttributes()
            

        }


        public string Check(object code, Type type)
        {
            //数値化出来ないものは入力エラー
            if (type == typeof(EmployeeCode))
            {
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

            }
            if (type == typeof(StoreCode))
            {
                throw new NotImplementedException($"コードがまだ実装中です。");
            }
            throw new NotImplementedException($"コードがまだ実装中です。");
        }

        public void IsRequire(object code, Type type)
        {
            //typeのSuperClassをチェックする方法は？
            if (type == typeof(Code))
                if (code.ToString().TrimEnd().Length == 0)
                    throw new ApplicationException($"未入力エラーです。");
        }
    }
}
