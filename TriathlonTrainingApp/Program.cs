using System;
using System.Collections.Generic;
using System.IO;

enum Sport
{
    running = 1,
    bike,
    swimming
}

namespace TriathlonTrainingsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Sport kindOfSport;
            Console.WriteLine("Enter kind of activity: 1) running 2) bike 3) swimming (for example: 2)");
            string enteredData = Console.ReadLine();
            kindOfSport = (Sport)Enum.Parse(typeof(Sport), enteredData, ignoreCase: true);
            if (!Enum.TryParse(enteredData, out kindOfSport))
                Console.WriteLine("It is not correct data");
            else
                kindOfSport = (Sport)Enum.Parse(typeof(Sport), enteredData, ignoreCase: true);

            switch (kindOfSport)
            {
                case Sport.running:
                    var running = new Running();
                    string writePathDistanceData = @"C:\SomeDir\Run(Distance).txt";
                    string writePathDurationData = @"C:\SomeDir\Run(Duration).txt";
                    CurrentActivity(running, writePathDistanceData, writePathDurationData);
                    break;
                case Sport.bike:
                    var bike = new Bicycle();
                    writePathDistanceData = @"C:\SomeDir\Bike(Distance).txt";
                    writePathDurationData = @"C:\SomeDir\Bike(Duration).txt";
                    CurrentActivity(bike, writePathDistanceData, writePathDurationData);
                    break;
                case Sport.swimming:
                    var swimming = new Swimming();
                    writePathDistanceData = @"C:\SomeDir\Swim(Distance).txt";
                    writePathDurationData = @"C:\SomeDir\Swim(Duration).txt";
                    CurrentActivity(swimming, writePathDistanceData, writePathDurationData);
                    break;
                default:
                    Console.WriteLine("It is not correct data");
                    break;
            }

            void CurrentActivity(Triathlon triathlon, string writePathDistanceData, string writePathDurationData)
            {
                double distance, duration;
                Console.WriteLine("Enter activity distance(in kilometers): (for example: 10,5)");
                enteredData = Console.ReadLine();
                if (!Double.TryParse(enteredData, out distance) || distance < 0 || distance > 1000)
                {
                    distance = 0.00000001;
                    Console.WriteLine("It is not correct data");
                }

                Console.WriteLine("Enter time (in minutes):");
                enteredData = Console.ReadLine();
                if (!Double.TryParse(enteredData, out duration) || duration < 0 || duration > 5000)
                {
                    duration = 0.00000001;
                    Console.WriteLine("It is not correct data");
                }

                var activityEvent = new ActivityEvent();
                activityEvent.ActivityEventHandler(triathlon, distance, duration);

                List<double> listOfDistance = new List<double>();
                List<double> listOfDuration = new List<double>();

                var readActivity = new ReadActivityData();
                var writeActivity = new WriteActivityData(writePathDistanceData, writePathDurationData);

                if (distance != 0.00000001 && duration != 0.00000001)
                {
                    writeActivity.WriteData(writePathDistanceData, distance);
                    readActivity.ReadData(writePathDistanceData, distance, listOfDistance, distance);
                    writeActivity.WriteData(writePathDurationData, duration);
                    readActivity.ReadData(writePathDurationData, duration, listOfDuration, distance);
                    readActivity.AverageSpeed();
                }
            }
        }
    }
}

