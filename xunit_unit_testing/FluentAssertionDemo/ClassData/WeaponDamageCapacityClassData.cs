using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FluentAssertionDemo.ClassData
{
    public class WeaponDamageCapacityClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() => Enumerable.Range(0, 50).Select(i => new object[] { i }).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}