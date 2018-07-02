using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public class DecimalProperty : BaseProperty
    {
        public DecimalProperty(string value) : base(value)
        {
            //このコードは、asmでは動作しない。
            if (decimal.TryParse(value, out decimal ret)) Decimal = ret;

        }

        public decimal? Decimal { get; set; } = null;

        public string Format { get; set; }

        public int PositiveDigit { get; set; }
        public int DecimalDigit { get; set; }

        public string ToString(string format = null)
        {
            if (format == null)
                if (Format == null)
                    return Decimal?.ToString("#,##0");
                else
                    return Decimal?.ToString(Format);
            else
                return Decimal?.ToString(format);
        }

        public override string Validate()
        {
            Console.WriteLine($"DecimalProperty Name={Name}, InputValue={(InputValue == null ? "null" : InputValue)}, Decimal={(Decimal == null ? "null" : this.ToString())}");

            if (IsRequired == true)
            {
                if (InputValue.TrimEnd().Length == 0)
                    throw new ApplicationException($"{Name}は必須入力です。入力してください。");
            }
            if (InputValue.Length > 0)

                if (decimal.TryParse(InputValue, out decimal ret))
                    Decimal = ret;
                else
                    throw new ApplicationException($"{Name}を数値として解釈できませんでした。入力内容={InputValue}");

            //TODO:整数桁のチェック


            //TODO:少数桁のチェック


            return InputValue;
        }
    }
}
