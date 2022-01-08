using System.Collections.Generic;
using System.Linq;

namespace MonoTest.Extensions
{
    public static class RectangleListExtensions
    {
        public static List<RectangleF> Mirror(this IEnumerable<RectangleF> rectangleFs, int parentWidth)
        {
            return rectangleFs.Select(r => r.Mirror(parentWidth)).ToList();
        }
    }
}