using PunchLogicSolution;
using Xunit;

namespace PunchLogicTest
{
    public class PunchLogicTest
    {
        [Fact]
        public void PayrollCalculator_CalculatesCorrectValues()
        {
            PayrollCalculator payroll = new(Data.Json);

            EmployeePayroll mike = payroll.Payroll.First(p => p.Employee.Name == "Mike");
            Assert.Equal("Mike", mike.Employee.Name);
            Assert.Equal(39.2856, mike.Regular);
            Assert.Equal(0, mike.Overtime);
            Assert.Equal(0, mike.Doubletime);
            Assert.Equal(1056.4017, mike.WageTotal);
            Assert.Equal(36.8320, mike.BenefitTotal);

            EmployeePayroll steve = payroll.Payroll.First(p => p.Employee.Name == "Steve");
            Assert.Equal("Steve", steve.Employee.Name);
            Assert.Equal(40, steve.Regular);
            Assert.Equal(8, steve.Overtime);
            Assert.Equal(1.1658, steve.Doubletime);
            Assert.Equal(1653.5979, steve.WageTotal);
            Assert.Equal(49.9036, steve.BenefitTotal);

            EmployeePayroll alex = payroll.Payroll.First(p => p.Employee.Name == "Alex");
            Assert.Equal("Alex", alex.Employee.Name);
            Assert.Equal(40, alex.Regular);
            Assert.Equal(3.6428, alex.Overtime);
            Assert.Equal(0, alex.Doubletime);
            Assert.Equal(795.3979, alex.WageTotal);
            Assert.Equal(44.5985, alex.BenefitTotal);
        }
    }
}