using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Houses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IPaintingScheduler scheduler = new WholeHouseScheduler();

            IPainter localPaintersCo =
                new PaintingCompany(
                    new IPainter[]{
                        new Painter("Andy", 7),
                        new Painter("Bill", 5)
                    },
                    // scheduler);
                    new ProportionalScheduer());

            IPainter bestPaintersCo =
                new PaintingCompany(
                    new IPainter[]{
                        new Painter("Joe", 4),
                        new Painter("Jill", 5),
                        new Painter("Buster", 3),
                        localPaintersCo
                    },
                    scheduler);

            LandOwner owner = new LandOwner(14, bestPaintersCo);

            owner.MaintainHouses();

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
