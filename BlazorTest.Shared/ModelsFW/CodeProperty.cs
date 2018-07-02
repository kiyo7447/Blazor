using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public class CodeProperty : TextProperty
    {
        public CodeProperty(string value) : base(value) { }
        public override string Validate()
        {
            base.Validate();
            Console.WriteLine($"DecimalProperty Name={Name}, InputValue={(InputValue == null ? "null" : InputValue)}");

            //TODO:数字のみのチェック
            if (InputValue.TrimEnd().Length != 0)
                if (int.TryParse(InputValue, out int ret))
                    InputValue = ret.ToString().PadLeft(MaxLength, '0');
                else
                    throw new ApplicationException($"{Name}は数字のみ入力可能です。");
            //TODO:入力書式は、ゼロ埋め編集
            return InputValue;
        }

    }
}
