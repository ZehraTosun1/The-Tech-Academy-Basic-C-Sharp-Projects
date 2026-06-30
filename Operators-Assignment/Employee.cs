using System;

namespace OperatorsAssignment
{
    // This class represents an employee.
    public class Employee
    {
        // This property stores the employee's ID number.
        public int Id { get; set; }

        // This property stores the employee's first name.
        public string FirstName { get; set; }

        // This property stores the employee's last name.
        public string LastName { get; set; }

        // This overloads the == operator.
        // It compares two Employee objects by their Id property.
        public static bool operator ==(Employee employee1, Employee employee2)
        {
            // Check if both objects are null.
            if (ReferenceEquals(employee1, null) && ReferenceEquals(employee2, null))
            {
                return true;
            }

            // Check if only one object is null.
            if (ReferenceEquals(employee1, null) || ReferenceEquals(employee2, null))
            {
                return false;
            }

            // Return true if both employee Id values are the same.
            return employee1.Id == employee2.Id;
        }

        // This overloads the != operator.
        // It must be overloaded because == and != operators must be overloaded in pairs.
        public static bool operator !=(Employee employee1, Employee employee2)
        {
            // Return the opposite result of the == operator.
            return !(employee1 == employee2);
        }

        // Override Equals because the == operator was overloaded.
        public override bool Equals(object obj)
        {
            // Check if the object is an Employee.
            Employee employee = obj as Employee;

            // If it is not an Employee, return false.
            if (employee == null)
            {
                return false;
            }

            // Compare employees by Id.
            return this.Id == employee.Id;
        }

        // Override GetHashCode because Equals was overridden.
        public override int GetHashCode()
        {
            // Return the Id as the hash code.
            return Id.GetHashCode();
        }
    }
}
