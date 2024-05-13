using System;
using System.ComponentModel.Design;
using System.Threading;

namespace Øvelse_3
{
    internal class Program
    {
        class Temperature
        {
            // Byte for checking if temperature exceeds or decreases more than its allowed
            internal byte alarmTemperature = 0;
            // Boolean variable to check if thread is alive
            bool alive = true;

            /// <summary>
            /// Generating random temperature and checking the temperature.
            /// </summary>

            public void GenerateRandomTemperature()
            {
                while (alive)
                {
                    Random rnd = new Random();
                    int temperature = rnd.Next(-20, 120);
                    Console.WriteLine($"The current temperature is: {temperature}");
                    if (temperature < 0)
                    {
                        Console.WriteLine("The temperature is lower than allowed ! ! ! !");
                        alarmTemperature++;
                    }
                    if (temperature > 100)
                    {
                        Console.WriteLine("The temperature is higher than allowed ! ! ! !");
                        alarmTemperature++;
                    }
                    if (alarmTemperature >= 3)
                    {
                        alive = false;
                        break;
                    }
                    Thread.Sleep(2000);
                }
            }
            /// <summary>
            /// Testing if temperature is alive
            /// </summary>
            public void TestingAlive()
            {
                while (true)
                {
                    if (alive)
                    {
                        Console.WriteLine("Thread is alive");
                    }
                    if (!alive)
                    {
                        Console.WriteLine("Thread has been terminated ! ! !");
                        Thread.Sleep(2000);
                        break;
                    }
                    Thread.Sleep(10000);
                }
                if (!alive)
                {
                    Console.WriteLine("All threads have been terminated ! ! !");
                }
            }


            static void Main(string[] args)
            {
                // Creating a new instance of the class temperature
                Temperature tmp = new Temperature();
                // Creating a new thread that runs the temperature generator
                Thread temperatureTester = new Thread(new ThreadStart(tmp.GenerateRandomTemperature));
                temperatureTester.Start();
                // Creating a new thread that checks if the other thread is alive.
                Thread testAlive = new Thread(new ThreadStart(tmp.TestingAlive));
                testAlive.Start();
            }
        }
    }
}
