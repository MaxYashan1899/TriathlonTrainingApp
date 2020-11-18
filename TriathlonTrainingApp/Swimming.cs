using System;

namespace TriathlonTrainingsApp
{
    class Swimming : Triathlon
    {
        public override void GetCurrentDistance(double distance)
        {
            Console.WriteLine($"Swim: {distance} km");
        }
        public override void GetPaceAndSpeed(double duration, double distance)
        {
            base.GetPaceAndSpeed(duration, distance);
            Console.WriteLine($"Swimming pace: {GetPaceInMinutes()},{GetPaceInSeconds()} min/km");
            Console.WriteLine($"Swimming speed: {Math.Round(Speed, 2)} km/hour");
        }
    }
}
