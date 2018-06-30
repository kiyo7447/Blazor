using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    public class Birthday : DateProperty
    {
        public Birthday(string value) : base(value) { }

        public override void Validate()
        {
            base.Validate();
            if (DateTime.Compare(Date, DateTime.Now) > 0)
                throw new ApplicationException($"{Name}に過去日は入力できません。入力値={this.ToString()}");
        }
    }
}
