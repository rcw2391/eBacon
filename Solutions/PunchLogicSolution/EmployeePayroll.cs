namespace PunchLogicSolution
{
    public class EmployeePayroll
    {
        public EmployeePayroll(Employee employee)
        {
            Employee = employee;
            CalculatePayroll();
        }

        public Employee Employee { get; }
        public double Regular { get; private set; }
        public double Overtime { get; private set; }
        public double Doubletime { get; private set; }
        public double WageTotal { get; private set; }
        public double BenefitTotal { get; private set; }

        private void CalculatePayroll()
        {
            double total = 0;

            foreach (TimePunch punch in Employee.Punches)
            {
                double deltaRemaining = punch.Delta;
                if (40 <= total + punch.Delta && total + punch.Delta <= 48)
                {
                    if (total < 40)
                    {
                        double regularIncrease = 40 - total;
                        deltaRemaining -= regularIncrease;
                        Regular += regularIncrease;
                        WageTotal += regularIncrease * punch.Job.Rate;
                        BenefitTotal += regularIncrease * punch.Job.BenefitsRate;
                    }
                    Overtime += deltaRemaining;
                    WageTotal += deltaRemaining * punch.Job.Rate * 1.5;
                    BenefitTotal += deltaRemaining * punch.Job.BenefitsRate;
                    total += punch.Delta;
                }
                else if (total + punch.Delta > 48)
                {
                    if (total < 40)
                    {
                        double regularIncrease = 40 - total;
                        deltaRemaining -= regularIncrease;
                        Regular += regularIncrease;
                        WageTotal += regularIncrease * punch.Job.Rate;
                        BenefitTotal += regularIncrease * punch.Job.BenefitsRate;
                        total += regularIncrease;
                    }

                    if (total < 48)
                    {
                        double overtimeIncrease = 48 - total;
                        deltaRemaining -= overtimeIncrease;
                        Overtime += overtimeIncrease;
                        WageTotal += overtimeIncrease * punch.Job.Rate * 1.5;
                        BenefitTotal += overtimeIncrease * punch.Job.BenefitsRate;
                        total += overtimeIncrease;
                    }
                    Doubletime += deltaRemaining;
                    WageTotal += deltaRemaining * punch.Job.Rate * 2;
                    BenefitTotal += deltaRemaining * punch.Job.BenefitsRate;
                    total += deltaRemaining;
                }
                else
                {
                    Regular += deltaRemaining;
                    WageTotal += deltaRemaining * punch.Job.Rate;
                    BenefitTotal += deltaRemaining * punch.Job.BenefitsRate;
                    total += deltaRemaining;
                }
            }

            Regular = Math.Round(Regular, 4);
            Doubletime = Math.Round(Doubletime, 4);
            Overtime = Math.Round(Overtime, 4);
            WageTotal = Math.Round(WageTotal, 4);
            BenefitTotal = Math.Round(BenefitTotal, 4);
        }
    }
}
