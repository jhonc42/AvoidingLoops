using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorDemo
{
    class Program
    {
        //Este metodo se paso a la clase CompositePainterFactories:
        //private static IPainter FindCheapestPainter(double sqMeters, Painters painters) =>
        //    painters.GetAvailable().GetCheapestOne(sqMeters);
        //{

        //return
        //    painters
        //    .Where(x => x.IsAvailable)
        //    .WithMinimun(painter => painter.EstimateCompensation(sqMeters));

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
        //}

        // OTROS METODOS QUE PODRIAN NECESITARSE SOBRE AVERIGUAR QUIEN ES EL MAS RAPIDO PINTOR:
        //private static IPainter FindFastestPainter(double sqMeters, Painters painters) =>
        //    painters.GetAvailable().GetFastestOne(sqMeters);
        //{
        //    return
        //        painters
        //            .Where(painter => painter.IsAvailable)
        //            .WithMinimun(painter => painter.EstimateTimeToPaint(sqMeters));
        //}
        // AHORA SE QUIERE QUE LOS PINTORES TRABAJEN CONJUNTAMENTE, JUNTOS PARA SOLUCIONAR UN PEDIDO:
        //private static IPainter WorkTogether(double sqMeters, IEnumerable<IPainter> painters)
        //{
        //    TimeSpan time =
        //        TimeSpan.FromHours(
        //            1/
        //            painters
        //                .Where(painter => painter.IsAvailable)
        //                .Select(painter => 1/painter.EstimateTimeToPaint(sqMeters).TotalHours)
        //                .Sum()
        //            );
        //    double cost =
        //        painters
        //            .Where(painter => painter.IsAvailable)
        //            .Select(painter => 
        //                painter.EstimateCompensation(sqMeters)/
        //                painter.EstimateTimeToPaint(sqMeters).TotalHours*
        //                time.TotalHours)
        //            .Sum();
        //    return new ProportionalPainter()
        //    {
        //        TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
        //        DollarsPerHour = cost/time.TotalHours
        //    };
                
        //}
        static void Main(string[] args)
        {
            IEnumerable<ProportionalPainter> painters = new ProportionalPainter[10];
            // Aqui por ejemplo se crea un objeto pintor que es el mas barato de todos los pintores.
            IPainter painter = CompositePainterFactories.CreateCheapestSelector(painters);
        }
    }
}
