using System;
using System.Collections.Generic;
using System.Linq;

namespace Houses
{
    public class PaintingCompany : IPainter
    {
        private IEnumerable<IPainter> painters;
        private IPaintingScheduler scheduler;

        public PaintingCompany(IEnumerable<IPainter> painters, IPaintingScheduler scheduler)
        {
            this.painters = new List<IPainter>(painters);
            this.scheduler = scheduler;
        }

        public double Paint(double houses)
        {
            double totalDays =
                scheduler
                .Organize(painters, houses)
                .Select(record => record.Painter.Paint(record.HousesToPaint))
                .Max();

            return totalDays;
        }

        public double EstimateDays(double houses)
        {
            return
                scheduler
                .Organize(painters, houses)
                .Select(record => record.Painter.EstimateDays(record.HousesToPaint))
                .Max();
        }
    }
}