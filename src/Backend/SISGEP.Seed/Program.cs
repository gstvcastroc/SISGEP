using System;
using System.Threading.Tasks;

namespace SISGEP.Seed
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await PersonSeed.Execute();

            await ProjectSeed.Execute();

            Console.ReadLine();
        }
    }
}