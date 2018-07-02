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
        public T GetField<T>(object value) where T : TextProperty
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
            var propertyInfoAttributes =  propertyInfo.GetCustomAttributes(typeof(PropertyInfoAttribute), false) as PropertyInfoAttribute[];
            if (propertyInfoAttributes != null && propertyInfoAttributes.Length > 0)
            {
                //入力チェックを行う
                var value = propertyInfo.GetValue(model);
                var proInfo = propertyInfoAttributes[0];
                Console.WriteLine("Activator.CreateInstance start");
                var check = (BaseProperty)Activator.CreateInstance(proInfo.Type, value);
                Console.WriteLine("Activator.CreateInstance end");
                if (check == null) throw new SystemException($"入力チェックのインスタンス化に失敗しました。propertyInfo.Type={proInfo.Type}, value={value}");
                check.Name = proInfo.Name;
                check.IsRequired = proInfo.IsRequired;
                try
                {
                    check.Validate();
                }
                catch(ApplicationException ex)
                {
                    var m = model as BaseModel;
                    if (m == null) throw;
                    m.ErrorMessage[fieldName] = ex.Message;
                }
            }
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
            if (type == typeof(CodeProperty))
                if (code.ToString().TrimEnd().Length == 0)
                    throw new ApplicationException($"未入力エラーです。");
        }
    }
}
