using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorDemo
{
    class Program
    {
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters) 
        {

            return
                painters
                .Where(x => x.IsAvailable)
                .WithMinimun(painter => painter.EstimateCompensation(sqMeters));

            // este c´ódigo es el mejor approach, pero es ilegible y viola ese principio de clean code, por lo cual, una forma de volver bonito y legible un código
            // es envolviendo lo feo en un método de extensión:
            //return
            //    painters
            //    .Where(x => x.IsAvailable)
            //    .Aggregate((IPainter)null, (best, cur) =>
            //        best == null ||
            //        cur.EstimateCompensation(sqMeters) < best.EstimateCompensation(sqMeters) ?
            //        cur : best
            //    );

            // este código es bueno, pero ilegible y llama dos veces a la función, además si viene un null se reventaría.
            //return
            //    painters
            //    .Where(x => x.IsAvailable)
            //    .Aggregate((best, cur) =>
            //        best.EstimateCompensation(sqMeters) < cur.EstimateCompensation(sqMeters) ?
            //        best : cur
            //    );

            // Este código no es bueno para buscar dentro de una secuencia de elementos, ya que afecta el performance
            //return
            //    painters
            //    .Where(x => x.IsAvailable)
            //    .OrderBy(painter => painter.EstimateCompensation(sqMeters))
            //    .FirstOrDefault();

            //return 
            //    painters
            //    .ThoseAvailable()
            //    .WithMinimim(painter.EstimateCompensation(sqMeters));

            //double bestPrice = 0;
            //IPainter cheapest = null;
            //foreach (IPainter painter in painters)
            //{
            //    if (painter.IsAvailable)
            //    {
            //        double price = painter.EstimateCompensation(sqMeters);
            //        if (cheapest == null || price < bestPrice)
            //        {
            //            cheapest = painter;
            //        }

            //    }
            //}
            //return cheapest;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
