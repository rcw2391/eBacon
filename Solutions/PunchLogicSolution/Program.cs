using PunchLogicSolution;

PayrollCalculator payroll = new(Data.Json);
Console.WriteLine(payroll.ToString());