using System;

namespace CodeFirstStudentDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                var student = new Student()
                {
                    StudentName = "Zehra Tosun"
                };

                context.Students.Add(student);
                context.SaveChanges();

                Console.WriteLine("Student has been added to the database successfully.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
