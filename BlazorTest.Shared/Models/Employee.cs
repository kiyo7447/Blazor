using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    [Author("hogehoge", Affiliation ="fugofugo")]
    public class Employee
	{
		public int Id { get; set; }

        [Field(typeof(EmployeeCode), IsRequire =true)]
        public string Code{ get; set; }

        public string Name { get; set; }

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

        public Dictionary<string, string> ErrorMessage = new Dictionary<string, string>();

        public bool IsValid()
        {
            return ErrorMessage.Count > 0 ? true : false;
        }

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

                //ex 3
                Facade.Checker.Validate(this, nameof(Employee.Code));
                //必須チェックは属性によって指定されている

                //ex 4
                (new EmployeeCode(Code)).Validate();
                Facade.Checker.IsRequire(Code, typeof(EmployeeCode));

            }
            catch (ApplicationException ae)
            {
                ErrorMessage[nameof(Employee.Code)] = ae.Message;
                _ret =  false;
            }

            

            return _ret;
        }

    }
}
