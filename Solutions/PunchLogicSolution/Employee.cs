namespace PunchLogicSolution
{
    public class Employee
    {
        public Employee(string name, List<TimePunch> punches)
        {
            Name = name;
            Punches = punches.OrderBy(punch => punch.Start).ToList();
        }

        public string Name { get; }
        public List<TimePunch> Punches { get; }
    }
}
