using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTest.Shared
{
    [Author("hogehoge", Affiliation = "fugofugo")]
    public class Employee : BaseModel
    {
        public int Id { get; set; }

        [PropertyInfo("従業員コード", typeof(EmployeeCode), IsRequired = true)]
        public string Code { get; set; }

        [PropertyInfo("従業員名", typeof(EmployeeName), IsRequired = true)]
        public string Name { get; set; }

        [PropertyInfo("従業員の誕生日", typeof(Birthday), IsRequired = true, Link = nameof(Birthday))]
        public string InpBirthday { get; set; }

        public DateTime Birthday { get; set; }


        [PropertyInfo("従業員の年収", typeof(Money), IsRequired = true, Link = nameof(Salary))]
        public string InpSalary { get; set; }

        public int Salary { get; set; }

        public int Age => DateTime.Now.Year - Birthday.Year;

        public bool Validation()
        {
            ErrorMessage.Clear();
            try
            {
                Console.WriteLine("ex1 start");
                //ex.1 ５行バージョン
                var employeeCode = Facade.Checker.GetField<EmployeeCode>(Code);
                employeeCode.Name = "従業員コード";
                employeeCode.IsRequired = true;
                var ret = employeeCode.Validate();
                //本来は書式を返す
                //Code = ret;
                Console.WriteLine("ex1 end");

                Console.WriteLine("ex2 start");
                //ex.3 ３行バージョン
                employeeCode = new EmployeeCode(Code);
                employeeCode.Name = "従業員コード";
                employeeCode.IsRequired = true;
                ret = employeeCode.Validate();
                //本来は書式を返す
                //Code = c2;
                Console.WriteLine("ex2 end");

                Console.WriteLine("ex3 start");
                //ex.3 ２行バージョン
                ret = Facade.Checker.Validate(Code, typeof(EmployeeCode), name: "従業員コード", isRequired: true);
                //本来は書式を返す
                //Code = ret;
                Console.WriteLine("ex3 end");

            }
            catch (ApplicationException ae)
            {
                ErrorMessage[nameof(Employee.Code)] = ae.Message;
            }

            //ex.4 １行バージョン
            //コードをチェック
            Facade.Checker.Validate(this, nameof(Employee.Code));
            //必須チェックは属性によって指定されている

            //TODO:サーバ側で動作する場合は、DBのチェックを組み込みたいが、、その判断は？？
            // if (IsServerf


            //名前をチェック
            Facade.Checker.Validate(this, nameof(Employee.Name));

            //誕生日チェック
            Facade.Checker.Validate(this, nameof(Employee.InpBirthday));

            //年収チェック
            if (Facade.Checker.Validate(this, nameof(Employee.InpSalary)))
            {
                if (Salary > 3000000)
                    ErrorMessage[nameof(Employee.InpSalary)] = $"従業員の年収は300万を超えることは許しません。";
            }            

            Console.WriteLine($"IsValid()={IsValid()}");

            return IsValid();
        }

    }
}
