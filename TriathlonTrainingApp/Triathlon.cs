using System;

namespace TriathlonTrainingsApp
{
    class Triathlon
    {
        public double Distance { get; set; }
        public double Duration { get; set; }
        public double Speed { get; set; }
        public double Pace { get; set; }

        public DateTime CurrentData { get; set; }
        public Triathlon()
        {
        }

        public event EventHandler<DateTime> EventRunning;
        public virtual void CurrentActivityEvent()
        {
            CurrentData = DateTime.Now;
            EventRunning?.Invoke(this, CurrentData);

        }
        public virtual void GetPaceAndSpeed(double duration, double distance)
        {
            Pace = 60 / (distance / (duration / 60));
            Speed = distance / (duration / 60);
        }
        public virtual void GetCurrentDistance(double distance)
        {
        }
        public double GetPaceInMinutes()
        {
            double paceInMinutes = Math.Floor(Pace / 1);
            return paceInMinutes;
        }
        public double GetPaceInSeconds()
        {
            double paceInSeconds = Math.Round((Pace % 1) * 60, 0);
            return paceInSeconds;
        }

    }
}
