using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    [Obsolete]
    public enum CodeEnum
    {
        EmployeeCode,
        StoreCode
    }
    public class Checker
    {
        public T GetField<T>(object value) where T : BaseProperty
        {
            return (T)Activator.CreateInstance(typeof(T), value);
#if false
            if (typeof(T) == typeof(EmployeeCode))
                return new EmployeeCode(value.ToString()) as T;
            //var a = new EmployeeCode();
            //if a.return (T)a;
            return null;
#endif
        }

        public void Validate(object model, string fieldName)
        {
            var propertyInfo = model.GetType().GetProperty(fieldName);
            var propertyInfoAttributes = propertyInfo.GetCustomAttributes(typeof(PropertyInfoAttribute), false) as PropertyInfoAttribute[];
            if (propertyInfoAttributes != null && propertyInfoAttributes.Length > 0)
            {
                //入力チェックを行う
                var value = propertyInfo.GetValue(model);
                var proInfo = propertyInfoAttributes[0];
                //Console.WriteLine("Activator.CreateInstance start");
                var check = (BaseProperty)Activator.CreateInstance(proInfo.Type, value);
                //Console.WriteLine("Activator.CreateInstance end");
                if (check == null) throw new SystemException($"入力チェックのインスタンス化に失敗しました。propertyInfo.Type={proInfo.Type}, value={value}");
                check.Name = proInfo.Name;
                check.IsRequired = proInfo.IsRequired;
                try
                {
                    var ret =  check.Validate();
                    propertyInfo.SetValue(model, ret);
                 
                    if (proInfo.Link != null)
                    {
                        var pi = model.GetType().GetProperty(proInfo.Link);
                        switch (Type.GetTypeCode(pi.PropertyType))
                        {
                            case TypeCode.DateTime:
                                if (ret.TrimEnd().Length != 0 && DateTime.TryParse(ret, out DateTime dt))
                                    pi.SetValue(model, dt);
                                break;
                            case TypeCode.Decimal:
                                if (ret.TrimEnd().Length != 0 && decimal.TryParse(ret, out decimal d))
                                    pi.SetValue(model, d);
                                break;
                            case TypeCode.Int32:
                                if (ret.TrimEnd().Length != 0 && int.TryParse(ret, out int i))
                                    pi.SetValue(model, i);
                                break;
                            default:
                                throw new NotImplementedException($"この機能は実装中です。TypeCode={Type.GetTypeCode(pi.PropertyType)}");
                        }
                    }
                }
                catch (ApplicationException ex)
                {
                    var m = model as BaseModel;
                    if (m == null) throw;
                    m.ErrorMessage[fieldName] = ex.Message;
                }
            }
        }

        //[Obsolete]
        public string Validate(string value, Type type, string name = null, bool isRequired = false)
        {
            var chk = (BaseProperty)Activator.CreateInstance(type, value);

            if (name != null) chk.Name = name;
            chk.IsRequired = isRequired;

            return chk.Validate();
#if false
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
#endif
        }

        [Obsolete]
        public void IsRequire(object code, Type type)
        {
            //typeのSuperClassをチェックする方法は？
            if (type == typeof(CodeProperty))
                if (code.ToString().TrimEnd().Length == 0)
                    throw new ApplicationException($"未入力エラーです。");
        }
    }
}
