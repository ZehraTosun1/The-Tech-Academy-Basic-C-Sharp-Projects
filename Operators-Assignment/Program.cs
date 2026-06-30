using System;

namespace OperatorsAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the first Employee object.
            Employee employee1 = new Employee();

            // Assign values to the first employee.
            employee1.Id = 101;
            employee1.FirstName = "Zehra";
            employee1.LastName = "Tosun";

            // Create the second Employee object.
            Employee employee2 = new Employee();

            // Assign values to the second employee.
            employee2.Id = 101;
            employee2.FirstName = "Sara";
            employee2.LastName = "Smith";

            // Compare the two Employee objects using the overloaded == operator.
            bool areEqual = employee1 == employee2;

            // Compare the two Employee objects using the overloaded != operator.
            bool areNotEqual = employee1 != employee2;

            // Display the first employee information.
            Console.WriteLine("Employee 1: " + employee1.FirstName + " " + employee1.LastName + ", ID: " + employee1.Id);

            // Display the second employee information.
            Console.WriteLine("Employee 2: " + employee2.FirstName + " " + employee2.LastName + ", ID: " + employee2.Id);

            // Display the result of the == comparison.
            Console.WriteLine("Are the employees equal by Id? " + areEqual);

            // Display the result of the != comparison.
            Console.WriteLine("Are the employees not equal by Id? " + areNotEqual);

            // Keep the console window open.
            Console.ReadLine();
        }
    }
}
