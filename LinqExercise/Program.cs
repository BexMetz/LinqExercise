using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            int numSum = numbers.Sum();
            Console.WriteLine($"Numbers sum:");
            Console.WriteLine(numSum);
            Console.WriteLine();

            //TODO: Print the Average of numbers
            double numAve = numbers.Average();
            Console.WriteLine($"Numbers average:");
            Console.WriteLine(numAve);
            Console.WriteLine();

            //TODO: Order numbers in ascending order and print to the console
            var numAscend = numbers.OrderBy(n => n);
            Console.WriteLine($"Numbers ascending:");
            foreach (int n in numAscend) { Console.WriteLine(n); }
            Console.WriteLine();

            //TODO: Order numbers in decsending order and print to the console
            var numDescend = numbers.OrderByDescending(n => n);
            Console.WriteLine($"Numbers descending:");
            foreach (int n in numDescend) { Console.WriteLine(n); }
            Console.WriteLine();

            //TODO: Print to the console only the numbers greater than 6
            var greaterSix = numbers.Where(n => n > 6);
            Console.WriteLine($"Numbers greater than 6:");
            foreach(int n in greaterSix) { Console.WriteLine(n); }
            Console.WriteLine();

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            var onlyFour = numbers.OrderByDescending(n => n).Where(n => n % 2 == 0 && n != 0 );
            Console.WriteLine($"Only 4 of the descending numbers:");
            foreach(int n in onlyFour) { Console.WriteLine(n); }
            Console.WriteLine();

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            numbers.SetValue(32, 4);
            Console.WriteLine($"Index 4 changed to age:");
            foreach (int n in numDescend ) { Console.WriteLine(n); }
            Console.WriteLine();


            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their
            //FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("Employees with a first name beginning with C or S:");
            employees.Where(e => e.FirstName[0] == 'C' || e.FirstName[0] == 'S')
                .OrderBy(e => e.FirstName)
                .ToList()
                .ForEach(e => Console.WriteLine(e.FullName));
            Console.WriteLine();

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the
            //console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Employees over 26 (ordered by age then name):");
            employees.Where(e => e.Age > 26).OrderBy(e => e.Age).ThenBy(e => e.FirstName)
                .ToList().ForEach(e => Console.WriteLine($"{e.Age}  {e.FullName}"));
            Console.WriteLine();

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if
            //their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine("Employees over 35 with 10 or less years experience:");
            int sumOfYOE = employees.Where(e => e.Age > 35 && e.YearsOfExperience <= 10).Sum(e => e.YearsOfExperience);
            Console.WriteLine($"Total years of experience: {sumOfYOE}");
            double aveOfYOE = employees.Where(e => e.Age > 35 && e.YearsOfExperience <= 10).Average(e => e.YearsOfExperience);
            Console.WriteLine($"Average years of experience: {aveOfYOE}");
            Console.WriteLine();

            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Original Employee List:");
            foreach (var e in employees) { Console.WriteLine($"{e.FullName} / Age:{e.Age} / YOE:{e.YearsOfExperience}"); }
            Console.WriteLine();
            Console.WriteLine("Appended Employee List:");
            employees = employees.Append(new Employee("Bex", "Metz", 32, 2)).ToList();
            foreach (var e in employees) { Console.WriteLine($"{e.FullName} / Age:{e.Age} / YOE:{e.YearsOfExperience}"); }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 4));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion


    }
}
