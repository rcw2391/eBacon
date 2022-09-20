namespace PunchLogicSolution
{
    public class JobInfo
    {
        public JobInfo(string name, double rate, double benefitsRate)
        {
            Name = name;
            Rate = rate;
            BenefitsRate = benefitsRate;
        }

        public string Name { get; }
        public double Rate { get; }
        public double BenefitsRate { get; }
    }
}
