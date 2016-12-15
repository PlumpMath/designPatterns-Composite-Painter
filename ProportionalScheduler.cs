using System;
using System.Collections.Generic;
using System.Linq;

namespace Houses
{
    public class ProportionalScheduer : IPaintingScheduler
    {
        public IEnumerable<PainterSchedule> Organize(IEnumerable<IPainter> painters, double houses)
        {
            double totalVelocity = GetOverallVelocity(painters);

            IEnumerable<PainterSchedule> result =
                painters
                .Select(painter =>
                    new
                    {
                        Painter = painter,
                        Velocity = 1 / (double)painter.EstimateDays(1)
                    })
                .Select(record =>
                    new PainterSchedule(
                        record.Painter,
                        houses * record.Velocity / totalVelocity));

            return result;
        }

        private double GetOverallVelocity(IEnumerable<IPainter> painters)
        {
            return
                painters
                .Select(painter => painter.EstimateDays(1))
                .Select(daysPerHouse => 1 / (double)daysPerHouse)
                .Sum();
        }
    }
}