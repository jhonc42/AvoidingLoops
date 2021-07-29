using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorDemo
{
    class ProportionalPainter : IPainter
    {
        public TimeSpan TimePerSqMeter { get; set; }
        public double DollarsPerHour { get; set; }
        public bool IsAvailable => true;

        public double EstimateCompensation(double sqMeters) => EstimateTimeToPaint(sqMeters).TotalHours * DollarsPerHour;

        public TimeSpan EstimateTimeToPaint(double sqMeters) => TimeSpan.FromHours(TimePerSqMeter.TotalHours * sqMeters);
    }
}
