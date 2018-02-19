using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var xS = new List<X>
            {
                new X { Id = 10, Name = "SS", Ints = new List<int> { 1, 2, 3 }, Y = new Y { Id = 100, Name ="A" } },
                new X { Id = 20, Name = "SX", Ints = new List<int> { 4, 5, 6 }, Y = new Y { Id = 200, Name="D"} },
                new X { Id = 30, Name = "XX", Ints = new List<int> { 7, 8, 9 }, Y = new Y { Id = 300, Name="D"} },
                new X { Id = 10, Name = "YY", Ints = new List<int> { 10, 20, 30 }, Y = new Y { Id = 400, Name="D"} },
                new X { Id = 10, Name = "FF", Ints = new List<int> { 10, 20, 30 }, Y = new Y { Id = 400 }},
                new X { Id = 20, Name = "ZZ", Ints = new List<int> { 40, 42, 43 }, Y = new Y { Id = 500 } }
            };

            // POI: Select Key
            // POI: Element Key (Projection)
            // POI: Both of above with IEqualityComparer<T> implementation

            var skk = xS.ToLookup(x => x.Y);
            var skkk = xS.ToLookup(x => x.Y, x => new { x.Name, x.Y.Id });

            var sk = xS.ToLookup(x => x.Y, new YNameEquality());
            var k = xS.ToLookup(x => x.Y, x => new { x.Name, x.Y.Id }, new YNameEquality());

            Console.ReadKey();
        }
    }

    class YNameEquality : IEqualityComparer<Y>
    {
        public bool Equals(Y a, Y b) => a != null && b != null && a.Name == b.Name;
        public int GetHashCode(Y y)
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ (y.Name ?? "").GetHashCode();

                return hash;
            }
        }
    }

    // POI: Overriding Equals & GetHashCode allows runtime to compare this composite object properly
    // POI: But this overridding will be discarded if implementation for IEqualityComparer<T> of this Type is provided
    class Y
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return Id == ((Y)obj).Id;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash = (hash * 16777619) ^ Id.GetHashCode().GetHashCode();

                return hash;
            }
        }
    }

    class X
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Y Y { get; set; }

        public List<int> Ints { get; set; }
    }
}
