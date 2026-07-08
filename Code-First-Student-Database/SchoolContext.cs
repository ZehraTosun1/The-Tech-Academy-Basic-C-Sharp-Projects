using System.Data.Entity;

namespace CodeFirstStudentDatabase
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolDB")
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
