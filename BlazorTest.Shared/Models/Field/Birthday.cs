using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public class Birthday : DateProperty
    {
        public Birthday(string value) : base(value) { }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ApplicationException">入力エラー</exception>
        public override string Validate()
        {
            base.Validate();
            if (Date != null && DateTime.Compare(Date.Value, DateTime.Now) > 0)
                throw new ApplicationException($"{Name}に未来日は入力できません。入力値={this.ToString()}");

            return InputValue;
        }
    }
}
