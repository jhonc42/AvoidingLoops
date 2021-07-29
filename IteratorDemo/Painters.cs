using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorDemo
{
    class Painters
    {
        private IEnumerable<IPainter> ContainedPainters { get; }
        public Painters(IEnumerable<IPainter> painters)
        {
            ContainedPainters = painters.ToList();
        }

        // Primitives Methods
        public Painters GetAvailable()
        {
            // lo comentado soloo es una demostracion de que aqui se puede cambiar logica sin afectar los clientes que consuman este metodo
            // consumiria mas procesador pero menos memoria en ciertos casos:
            //if (this.ContainedPainters.All(painter => painter.IsAvailable))
            //    return this;
            return new Painters(ContainedPainters.Where(painter => painter.IsAvailable));
        }

        public IPainter GetCheapestOne(double sqMeters) =>
            ContainedPainters.WithMinimun(painter => painter.EstimateCompensation(sqMeters));

        public IPainter GetFastestOne(double sqMeters) =>
            ContainedPainters.WithMinimun(painter => painter.EstimateTimeToPaint(sqMeters));
    }
}
