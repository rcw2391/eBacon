using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PunchLogicSolution
{
    public class PayrollCalculator
    {
        public PayrollCalculator(string json)
        {
            LoadData(json);
            Payroll = CalculatePayroll();
        }

        public List<EmployeePayroll> Payroll { get; private set; } = new();

        private Dictionary<string, JobInfo> _jobs = new();
        private List<Employee> _employees = new();

        private void LoadData(string json)
        {
            var data = (JObject)JsonConvert.DeserializeObject(json);
            var jobMetaString = data["jobMeta"];

            foreach (var job in jobMetaString)
            {
                _jobs.Add(job["job"].ToString(), new JobInfo(job["job"].ToString(), double.Parse(job["rate"].ToString()), double.Parse(job["benefitsRate"].ToString())));
            }

            var employeeDataString = data["employeeData"];
            
            foreach (var employee in employeeDataString)
            {
                List<TimePunch> punches = new();
                string employeeName = employee["employee"].ToString();

                foreach (var timePunch in employee["timePunch"])
                {
                    punches.Add(new(_jobs[timePunch["job"].ToString()], DateTime.Parse(timePunch["start"].ToString()), DateTime.Parse(timePunch["end"].ToString())));
                }

                _employees.Add(new(employeeName, punches));
            }
        }

        private List<EmployeePayroll> CalculatePayroll()
        {
            List<EmployeePayroll> payroll = new();
            foreach (Employee employee in _employees) payroll.Add(new EmployeePayroll(employee));
            return payroll;
        }

        public override string ToString()
        {
            string print = "";
            foreach (EmployeePayroll employeePayroll in Payroll) 
            {
                print += employeePayroll.Employee.Name + Environment.NewLine;
                print += $"Employee: {employeePayroll.Employee.Name}" + Environment.NewLine;
                print += $"Regular: {employeePayroll.Regular}" + Environment.NewLine;
                print += $"Overtime: {employeePayroll.Overtime}" + Environment.NewLine;
                print += $"Doubletime: {employeePayroll.Doubletime}" + Environment.NewLine;
                print += $"WageTotal: {employeePayroll.WageTotal}" + Environment.NewLine;
                print += $"BenefitTotal: {employeePayroll.BenefitTotal}" + Environment.NewLine;
            }
            return print;
        }
    }
}
