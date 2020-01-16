using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mock.Tutorial;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Tutorial.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void ConvertUSDtoRMBTest()
        {
            //测试时构造Mock对象
            Mock<IExchange> mock = new Mock<IExchange>();

            //通过Setup函数构造返回值
            mock.Setup(n => n.GetActualUSDValue()).Returns(500);

            //像正常的单元测试一样进行
            Calculator calculator = new Calculator(mock.Object);
            var actual = calculator.ConvertUSDtoRMB(1);
            var expected = 500;

            Assert.AreEqual(expected, actual);
        }
    }
}