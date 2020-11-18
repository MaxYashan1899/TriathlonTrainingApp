using System;

namespace TriathlonTrainingsApp
{
    class ActivityEvent : Triathlon
    {
        public void ActivityEventHandler(Triathlon triathlon, double distance, double duration)
        {
            triathlon.EventRunning += (sender, date) =>
            {
                if (distance != 0.00000001 && duration != 0.00000001)
                {
                    Console.WriteLine("--------------------");
                    triathlon.GetCurrentDistance(distance);
                    Console.WriteLine("Date: " + date.ToString("d"));
                    triathlon.GetPaceAndSpeed(duration, distance);
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your entered not correct data. Try again");
                    Console.ResetColor();
                }
            };
            triathlon.CurrentActivityEvent();
        }
    }
}
