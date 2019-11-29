using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static async Task PrintAsync(string s)
        {
            await Task.Run(
                    () =>
                    {
                        while (true)
                        {
                            Console.WriteLine(s);
                            Thread.Sleep(700);
                        }
                    }
                );
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Task based APM demo");

            // Volá PrintAsync("a") asynchronně.
            // Okamžitě předává kontrolu do Main
            Task[] t = {
            new Task(async () =>
            {
                await Program.PrintAsync("a");
                // After the operation is completed, the control flow will go here.
                Console.WriteLine("Poa");
            }),
            new Task(async () =>
            {
                await Program.PrintAsync("b");
                // After the operation is completed, the control flow will go here.
                Console.WriteLine("Pob");
            })};

            foreach (var item in t)
            {
                item.Start();
            }

            Console.WriteLine("Zpátky v Main");

            Console.ReadKey();
        }
    }
}