using System.Globalization;
using System.Collections.Generic;
using Teste.Entities;
using Teste.Entities.Enums;


namespace Teste
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter department's name: ");
            string departmentName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string workerName = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            Department department = new Department(departmentName);
            Worker worker = new Worker(workerName, level, baseSalary, department);
            Console.WriteLine();

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter #{i + 1} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime dateParse = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration: ");
                int duration = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(dateParse, valuePerHour, duration);
                worker.AddContract(contract);
            }

            Console.Write("Enter month and year to calculate income (MM/YYY): ");
            string monthAndYear = Console.ReadLine();

            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));


            Console.WriteLine();
            Console.WriteLine("Nome: "+ worker.Name);
            Console.WriteLine("Department: "+ worker.DepartmentName.Name);
            Console.WriteLine($"Income for {monthAndYear}:" +
                $" {worker.Income(year, month).ToString("f2", CultureInfo.InvariantCulture)}");

        }
    }
}