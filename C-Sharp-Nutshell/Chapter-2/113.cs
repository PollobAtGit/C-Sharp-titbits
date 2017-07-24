namespace Outer
{
    // POI: System.Console is available to both Outer & Outer.Inner. So Hierarchal relationship is applicable
    // for importing namespace
    using static System.Console;

    // POI: This Foo will be hidden by 'Inner.Foo'
    class Foo
    {
        public int Outer = 0;

        // POI: Exception because 'System.Collections.Generic' is available for Outer.Inner but not for Outer
        // private IList<int> _list = new List<int>();

        private void Print()
        {
            WriteLine("From Outer");
        }
    }

    namespace Inner
    {
        // POI: using scoped (nested) using directive. This namespace is not available for namespace Outer but
        // only for namespace Inner
        using System.Collections.Generic;

        // POI: If Foo is used inside this namespace then Inner.Foo will take precedence over Outer.Foo
        // POI: This Foo will hide the Foo of 'Outer'
        // POI: Same named Type can be defined in other namespace & Inner even though is nested inside Outer
        // is actually a totally different namespace. So declaring Foo inside Inner is acceptable
        class Foo
        {
            public int Inner = 0;

            private IList<int> _list = new List<int>();

            private void Print()
            {
                WriteLine("From Outer.Inner");
            }
        }

        internal static class Solution
        {
            internal static void Main()
            {
                // POI: This 'Foo' is the same as Inner.Foo NOT Outer.Foo
                var foo = new Foo();

                // POI: Foo is Inner.Foo NOT Outer.Foo. So 'Outer' is not defined. Error: error CS1061: 'Foo' does not contain a definition for 'Outer
                // WriteLine(foo.Outer);

                WriteLine(foo.Inner);
                WriteLine("Hello !!");
            }
        }
    }
}