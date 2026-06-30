using System;

namespace PolymorphismAssignment
{
    // The Employee class implements the IQuittable interface.
    public class Employee : IQuittable
    {
        // This property stores the employee's first name.
        public string FirstName { get; set; }

        // This property stores the employee's last name.
        public string LastName { get; set; }

        // This method implements the Quit method from the IQuittable interface.
        public void Quit()
        {
            // Display a message showing that the employee has quit.
            Console.WriteLine(FirstName + " " + LastName + " has quit the company.");
        }
    }
}
