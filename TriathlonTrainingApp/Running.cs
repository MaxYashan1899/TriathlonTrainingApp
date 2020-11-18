using System;

namespace TriathlonTrainingsApp
{
    class Running : Triathlon
    {
        public override void GetCurrentDistance(double distance)
        {
            Console.WriteLine($"Run: {distance} km");
        }

        public override void GetPaceAndSpeed(double duration, double distance)
        {
            base.GetPaceAndSpeed(duration, distance);
            Console.WriteLine($"Running pace: {GetPaceInMinutes()},{GetPaceInSeconds()} min/km");
            Console.WriteLine($"Running speed: {Math.Round(Speed, 2)} km/hour");
        }

    }
}
