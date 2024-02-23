using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class SortByIdNumber : IComparer
    {
        public int Compare(object? a, object? b)
        {
            MusicalInstrument m1 = a as MusicalInstrument;
            MusicalInstrument m2 = b as MusicalInstrument;
            if (m1.id.Number < m2.id.Number) return -1;
            else
                if (m1.id.Number == m2.id.Number) return 0;
            else return 1;
        }
    }
}
