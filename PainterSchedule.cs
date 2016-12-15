namespace Houses
{
    public class PainterSchedule
    {
        public IPainter Painter { get; set; }
        public double HousesToPaint { get; set; }

        public PainterSchedule(IPainter painter, double housesToPaint)
        {
            Painter = painter;
            HousesToPaint = housesToPaint;
        }
    }
}