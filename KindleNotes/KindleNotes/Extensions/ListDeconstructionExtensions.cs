using System.Collections.Generic;
using System.Linq;

namespace KindleNotes.Extensions
{
	public static class ListDeconstructionExtensions
	{
        public static void Deconstruct<T>(this List<T> list, out T first, out T second, out IEnumerable<T> rest)
        {
            first = list[0];
            second = list[1];
            rest = list.Skip(2);
        }
    }
}
