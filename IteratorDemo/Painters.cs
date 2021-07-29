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
        public Painters GetAvailable() =>
            new Painters(ContainedPainters.Where(painter => painter.IsAvailable));
    }
}
