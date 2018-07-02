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

        public override string Validate()
        {
            //後ろのスペースをカットする
            InputValue = InputValue.TrimEnd();

            Console.WriteLine($"check Text Validate() MaxLength={MaxLength}, InputValue={InputValue}");

            if (MaxLength != 0 && InputValue.Length > MaxLength)
                throw new ApplicationException($"{Facade.NilStr("{0}は、", Name)}最大入力桁数を超えています。入力内容={InputValue}, 最大入力桁数={MaxLength}");

            if (IsRequired == true && InputValue.TrimEnd().Length == 0)
                throw new ApplicationException($"{Facade.NilStr("{0}は、", Name)}必須入力です。");

            //禁則文字のチェック
            if (InputValue.IndexOf('\t') >= 0)
                throw new ApplicationException($"{Facade.NilStr("{0}に", Name)}タブ文字は入力できません。");

            if (InputValue.IndexOf(',') >= 0)
                throw new ApplicationException($"{Facade.NilStr("{0}に", Name)}カンマ文字は入力できません。");

            return InputValue;
        }
    }
}
