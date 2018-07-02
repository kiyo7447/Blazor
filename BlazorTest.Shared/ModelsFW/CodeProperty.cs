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

            if (InputValue.TrimEnd().Length != 0)
                //数字のみのチェック
                if (int.TryParse(InputValue, out int ret))
                    //入力書式は、ゼロ埋め編集
                    InputValue = ret.ToString().PadLeft(MaxLength, '0');
                else
                    throw new ApplicationException($"{Facade.NilStr("{0}は", Name)}数字のみ入力可能です。");
            return InputValue;
        }

    }
}
