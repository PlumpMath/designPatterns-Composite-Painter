using System;
using System.Collections.Generic;
using System.Linq;

namespace Houses
{
    public class WholeHouseScheduler : IPaintingScheduler
    {
        public IEnumerable<PainterSchedule> Organize(IEnumerable<IPainter> painters, double houses)
        {
            IEnumerable<PainterSchedule> schedule = CreateEmptySchedule(painters);

            while (houses > 0.0)
            {
                double part = Math.Min(1.0, houses);
                schedule = Add(schedule, part);
                houses -= part;
            }

            return schedule;
        }

        private IEnumerable<PainterSchedule> Add(IEnumerable<PainterSchedule> schedule, double part)
        {
            PainterSchedule optimalPainter =
                schedule
                .Select(painterSchedule => new PainterSchedule(painterSchedule.Painter, painterSchedule.HousesToPaint + part))
                .OrderBy(painterSchedule => painterSchedule.Painter.EstimateDays(painterSchedule.HousesToPaint))
                .First();

            IEnumerable<PainterSchedule> newSchedule =
                schedule
                .Where(painterSchedule =>
                    !object.ReferenceEquals(painterSchedule.Painter, optimalPainter.Painter))
                .Union(new PainterSchedule[] { optimalPainter });

            return newSchedule;
        }

        private IEnumerable<PainterSchedule> CreateEmptySchedule(IEnumerable<IPainter> painters)
        {
            return
                painters
                .Select(painter => new PainterSchedule(painter, 0.0));
        }
    }
}