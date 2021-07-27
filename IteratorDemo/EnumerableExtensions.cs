using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorDemo
{
    public static class EnumerableExtensions
    {
        //Metodo generico que recibe una secuencia de elementos de tipo T:
        // tambien habra algun tipo sobre que elementos de la secuencia se compararan, asi se pueden identificar y devolver el elemento con valor minimo
        // y devuelve un tipo T que sera el objeto que tenga el valor minumo de la clave.
        // el constraint que dice que T debe ser un tipo de referencia, porque se planea usar null para la semilla 
        // OBSERVE QUE SE LLAMA DOS VECES AL METODO CRITERION QUE SE ENVIA POR PARAMETRO. ESTO ES REDUNDANTE Y PODRIA SER INEFICAZ, HAY UN PRINCIPIO QUE SE LLAMA
        // EL PRINCIPIO DEL MENOR ASOMBRO O DE LA MENOR SORPRESA, Y ESTE METODO LO INCUMPLE, PORQUE PUEDE QUE LLAMEN AL SEGUNDO CRITERION O PUEDE QUE NO, SE DEBE MEJORAR ESTO
        //public static T WithMinimun<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion) 
        //    where T : class
        //    where TKey : IComparable<TKey> =>
        //        sequence.Aggregate((T)null, (best, cur) =>
        //            best == null || criterion(cur).CompareTo(criterion(best)) < 0 ? cur : best);

        // ESTA SERIA LA SOLUCION AL CASO ANTERIOR, esta solucion es completamente ilegible, pero el autor dice que como va a nivel de infraestructura como 
        // metodo de extension nadie la debe tomar en cuenta ni cambiarla, y el codigo que la consume osea el cliente allí si quedará legible.
        public static T WithMinimun<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> =>
                sequence
                    .Select(obj => Tuple.Create(obj, criterion(obj)))
                        .Aggregate((Tuple<T, TKey>)null,
                            (best, cur) => best == null || cur.Item2.CompareTo(best.Item2) < 0 ? cur : best)
                        .Item1;
    }
}
