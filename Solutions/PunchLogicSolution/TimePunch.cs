namespace PunchLogicSolution
{
    public class TimePunch
    {
        public TimePunch(JobInfo job, DateTime start, DateTime end)
        {
            Job = job;
            Start = start;
            End = end;
        }

        public JobInfo Job { get; }
        public DateTime Start { get; }
        public DateTime End { get; }
        public double Delta => (End - Start).TotalSeconds / 3600;
    }
}
