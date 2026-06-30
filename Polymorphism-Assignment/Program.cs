using System;

namespace PolymorphismAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an Employee object.
            Employee employee = new Employee();

            // Set the employee's first name.
            employee.FirstName = "Zehra";

            // Set the employee's last name.
            employee.LastName = "Tosun";

            // Use polymorphism to create an object of type IQuittable.
            // The object is an Employee, but it is stored as the interface type.
            IQuittable quittableEmployee = employee;

            // Call the Quit method using the IQuittable interface object.
            quittableEmployee.Quit();

            // Keep the console window open.
            Console.ReadLine();
        }
    }
}
