using System;
using System.Collections.Generic;

namespace Houses
{
    public interface IPaintingScheduler
    {
        IEnumerable<PainterSchedule> Organize(IEnumerable<IPainter> painters, double houses);
    }
}