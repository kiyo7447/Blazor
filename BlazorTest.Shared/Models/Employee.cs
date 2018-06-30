using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    [Author("hogehoge", Affiliation ="fugofugo")]
    public class Employee : BaseModel
	{
		public int Id { get; set; }

        [PropertyInfo("従業員コード", typeof(EmployeeCode), IsRequired =true)]
        public string Code{ get; set; }

        [PropertyInfo("従業員名", typeof(EmployeeName), IsRequired = true)]
        public string Name { get; set; }

        [PropertyInfo("従業員の誕生日", typeof(Birthday), IsRequired = true)]
        public DateTime Birthday { get; set; }

		public int Age => DateTime.Now.Year - Birthday.Year;


        //public void SetError(string errorMessage)
        //{
        //    ErrorMessage[""] = errorMessage;
        //}

        //public void SetError(string key, string errorMessage)
        //{
        //    ErrorMessage[key] = errorMessage;
        //}

        //public string GetError(string key)
        //{
        //    //if (key == "")
        //    if (ErrorMessage.ContainsKey(key) == false) return "";
        //    return ErrorMessage[key];
        //}
        //public void ClearError()
        //{
        //    ErrorMessage.Clear();

        //}



        public bool Validation()
        {
            ErrorMessage.Clear();
            bool _ret = true;
            try
            {
                //ex 1
                Code = Facade.Checker.Check(Code, typeof(EmployeeCode));
                Facade.Checker.IsRequire(Code, typeof(EmployeeCode));

                //ex 2
                var employeeCode = Facade.Checker.GetField<EmployeeCode>(Code);
                employeeCode.Validate();
                Facade.Checker.IsRequire(Code, typeof(EmployeeCode));

                //ex 4
                (new EmployeeCode(Code)).Validate();
                Facade.Checker.IsRequire(Code, typeof(EmployeeCode));

            }
            catch (ApplicationException ae)
            {
                ErrorMessage[nameof(Employee.Code)] = ae.Message;
                _ret =  false;
            }

            //ex 3
            Facade.Checker.Validate(this, nameof(Employee.Code));
            //必須チェックは属性によって指定されている

            Facade.Checker.Validate(this, nameof(Employee.Name));


            Facade.Checker.Validate(this, nameof(Employee.Birthday));

            _ret = IsValid();

            return _ret;
        }

    }
}
