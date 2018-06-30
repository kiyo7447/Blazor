using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public class DateProperty : Property
    {
        public DateProperty(string value) : base(value.ToString())
        {
            if (DateTime.TryParse(value, out DateTime ret)) Date = ret;
        }

        public DateTime Date { get; set; }

        public string ToString(string format = null)
        {
            if (format == null)
                return Date.ToString("yyyy/MM/dd");
            else
                return Date.ToString(format);
        }

        public override void Validate()
        {

            if (InputValue.Length > 0)
                if (DateTime.TryParse(InputValue, out DateTime ret))
                    Date = ret;
                else
                    throw new ApplicationException($"{Name}を日付として解釈できませんでした。入力内容={InputValue}");
        }
    }
}
