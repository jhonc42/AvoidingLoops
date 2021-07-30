using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorDemo
{
    class CompositePainter<TPainter> : IPainter where TPainter : IPainter
    {
        // Con esta propiedad se encapsula la colección, los clientes llamadores no tienen que saber como manipular los objetos, en este caso esta clase lo hace.
        private IEnumerable<TPainter> Painters { get; }
        private Func<double, IEnumerable<TPainter>, IPainter> Reduce { get; }

        public bool IsAvailable => Painters.Any(painter => painter.IsAvailable);

        public CompositePainter(IEnumerable<TPainter> painters, Func<double, IEnumerable<TPainter>, IPainter> reduce)
        {
            Painters = painters.ToList();
            Reduce = reduce;
        }
        // Esta es la misma funcion WorkTogether que estaba en el cliente, pero ahroa se llama reduce porque se trata de reducir toda la coleccion de pintores
        // a un solo pintor.
        //private IPainter Reduce(double sqMeters)
        //{
        //    TimeSpan time =
        //        TimeSpan.FromHours(
        //            1 /
        //            Painters
        //                .Where(painter => painter.IsAvailable)
        //                .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
        //                .Sum()
        //            );
        //    double cost =
        //        Painters
        //            .Where(painter => painter.IsAvailable)
        //            .Select(painter =>
        //                painter.EstimateCompensation(sqMeters) /
        //                painter.EstimateTimeToPaint(sqMeters).TotalHours *
        //                time.TotalHours)
        //            .Sum();
        //    return new ProportionalPainter()
        //    {
        //        TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
        //        DollarsPerHour = cost / time.TotalHours
        //    };

        //}

        public TimeSpan EstimateTimeToPaint(double sqMeters) => Reduce(sqMeters, Painters).EstimateTimeToPaint(sqMeters);

        public double EstimateCompensation(double sqMeters) => Reduce(sqMeters, Painters).EstimateCompensation(sqMeters);
    }
}
