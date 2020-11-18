using System;
using System.Collections.Generic;
using System.IO;

namespace TriathlonTrainingsApp
{
    class ReadActivityData
    {
        double totalDistance = 0;
        double totalDuration = 0;

        public void ReadData(string path, double activityData, List<double> list, double distance)
        {
            try
            {
                using (var readFile = new StreamReader(path))
                {
                    string fileStringData;
                    double totalActivity = 0;
                    int activityQuantity = 0;
                    double longestActivity = 0;

                    while ((fileStringData = readFile.ReadLine()) != null)
                    {
                        for (int i = 0; i < list.Count + 1; i++)
                        {
                            double fileDoubleData = Double.Parse(fileStringData);
                            if (list.Count == 0)
                                list.Add(fileDoubleData);
                            else
                            {
                                list.Clear();
                                list.Add(fileDoubleData);
                            }
                        }
                        foreach (var currentActivity in list)
                        {
                            totalActivity += currentActivity;
                            activityQuantity++;

                            if (currentActivity > longestActivity)
                                longestActivity = currentActivity;
                        }
                    }

                    if (activityData == distance)
                    {
                        Console.WriteLine($"Total distance per {activityQuantity} activity: {totalActivity} km");
                        totalDistance = totalActivity;
                        Console.WriteLine($"Best activity distance: {longestActivity} km");
                    }
                    else
                    {
                        totalDuration = totalActivity;
                        Console.WriteLine($"Total duration per {activityQuantity} activity: {totalActivity} min ({GetTimeInHours()} hours {GetTimeInMinutes()} min )");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AverageSpeed()
        {
            double averageSpeed = totalDistance / (totalDuration / 60);
            Console.WriteLine($"Average speed: {Math.Round(averageSpeed, 2)} km/hour");
        }
        double GetTimeInHours()
        {
            double hours = Math.Floor(totalDuration / 60);
            return hours;
        }
        double GetTimeInMinutes()
        {
            double minutes = Math.Round(totalDuration % 60);
            return minutes;
        }
    }
}
