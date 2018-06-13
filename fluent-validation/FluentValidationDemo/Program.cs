using FluentValidationDemo.Model;
using System;

namespace FluentValidationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //定义待校验的实体
            Company company = new Company();
            company.ID = 1;
            company.CompanyName = "测试企业名称";
            company.CompanyCode = "9988065487";
            company.Email = "q5401103q@github.com";
            company.Start = DateTime.Now.AddDays(-1);
            company.End = DateTime.Now;       

            //定义不正确的信息，查看校验效果     
            company.TaxNumber = "3102055546874545";
            company.SocialNumber = "3102055546874545";

            //定义校验器
            CompanyValidator validator = new CompanyValidator();
            var validateResult = validator.Validate(company);

            //检查校验结果
            if (validateResult.IsValid)
            {
                Console.WriteLine("校验通过");
            }
            else
            {
                foreach (var error in validateResult.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            Console.Read();
        }
    }
}
