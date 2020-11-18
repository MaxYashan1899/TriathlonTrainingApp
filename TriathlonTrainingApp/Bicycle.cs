using System;

namespace TriathlonTrainingsApp
{
    class Bicycle : Triathlon
    {
        public override void GetCurrentDistance(double distance)
        {
            Console.WriteLine($"Bike: {distance} km");
        }
        public override void GetPaceAndSpeed(double duration, double distance)
        {
            base.GetPaceAndSpeed(duration, distance);
            Console.WriteLine($"Bike pace: {GetPaceInMinutes()},{GetPaceInSeconds()} min/km");
            Console.WriteLine($"Bike speed: {Math.Round(Speed, 2)} km/hour");
        }
    }
}
