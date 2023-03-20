using ConsoleApp33.Data;

namespace ConsoleApp33
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");
            using(var context = new PersonDbContext())
            {
                var persons=context.Persons;
                foreach(var items in persons)
                {
                    Console.WriteLine(items.FirstName);
                    Console.WriteLine(items.LastName);
                }
            }
        }
    }
}