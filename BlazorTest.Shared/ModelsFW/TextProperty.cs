using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public class TextProperty : BaseProperty
    {

        public TextProperty(string value) : base (value) {}

        //public string Text { get; set; } = "";

        public int MaxLength { get; set; } = 0;

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override void Validate()
        {
            Console.WriteLine($"check Text Validate() MaxLength={MaxLength}, InputValue={InputValue}");
            if (MaxLength != 0 && InputValue.Length > MaxLength)
                throw new ApplicationException($"{Name}は、最大入力桁数を超えています。入力内容={InputValue}, 最大入力桁数={MaxLength}");

            if (IsRequired == true && InputValue.TrimEnd().Length == 0)
                throw new ApplicationException($"{Name}は、必須入力です。");

            //TODO:禁則文字のチェック


        }
    }
}
