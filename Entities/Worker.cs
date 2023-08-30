using System.Globalization;
using Teste.Entities.Enums;

namespace Teste.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }

        public Department DepartmentName { get; set; }

        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker(string name, WorkerLevel level, double baseSalary, Department departmentName)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            DepartmentName = departmentName;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;

            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Month == month && contract.Date.Year == year)
                {
                    sum += contract.TotalValue();
                }
            }

            return sum;
        }
    }

}
