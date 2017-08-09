namespace EF
{
    using static System.Console;
    using EF.DAL;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            using (var repository = new Repository<Student>(new SchoolContext()))
            {
                if (repository.GetByID(1) == null)
                {
                    repository.Insert(new Student
                    {
                        Name = "Cosos"
                    });

                    repository.SaveAsync();

                    WriteLine("Insertion Successful");
                }

                WriteLine("\n\nInserted Values");
                foreach (var student in repository.Get())
                {
                    WriteLine(student);
                }
            }

        }
    }
}
