using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public class DateProperty : BaseProperty
    {
        public DateProperty(string value) : base(value)
        {
            //このコードは、asmでは動作しない。
            if (DateTime.TryParse(value, out DateTime ret)) Date = ret;
            // ↓
            //validation()で設定する
            //try
            //{
            //    Date = DateTime.Parse(value);
            //}
            //catch (Exception)
            //{
            //    //Validation()でチェックを行う
            //}

        }

        public DateTime? Date { get; set; } = null;

        public string ToString(string format = null)
        {
            if (format == null)
                return Date?.ToString("yyyy/MM/dd");
            else
                return Date?.ToString(format);
        }

        public override string Validate()
        {
            Console.WriteLine($"DateProperty Name={Name}, InputValue={(InputValue == null?"null":InputValue)}, Date={(Date == null?"null":Date.Value.ToShortDateString())}");

            if (IsRequired == true)
            {
                if (InputValue.TrimEnd().Length == 0)
                    throw new ApplicationException($"{Name}は必須入力です。入力してください。");
            }
            if (InputValue.Length > 0)

                if (DateTime.TryParse(InputValue, out DateTime ret))
                    Date = ret;
                else
                    throw new ApplicationException($"{Name}を日付として解釈できませんでした。入力内容={InputValue}");
            return InputValue;
#if false
            //↓
            try
                {
                    Date = DateTime.Parse(InputValue);
                }
                catch (Exception)
                {
                    throw new ApplicationException($"{Name}を日付として解釈できませんでした。入力内容={InputValue}");
                }
#endif
        }
    }
}
