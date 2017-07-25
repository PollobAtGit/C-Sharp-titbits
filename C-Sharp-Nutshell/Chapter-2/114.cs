namespace Main
{
    // POI: Both of this namespaces define Type 'D'
    // using A.B.C;
    // using A.B.E;

    // POI: Aliasing Type NOT namespace. 'D' is a Type
    // POI: using directive allows only one way to import namespace but there are two other ways which can be used
    // to import TYPE (NOT namespace). One is using 'using static ...' another is aliasing using 'using A = ...'
    using ABCD = A.B.C.D;
    using ABED = A.B.E.D;

    internal static class Solution
    {
        internal static void Main()
        {
            // POI: Ambiguous Type name because compiler finds both 'A.B.C.D' & 'A.B.E.D'
            var abcd = new ABCD();

            var abed = new ABED();

            // POI: 'S' hasn't been imported. Because the using directive (used here) directly imports Type
            // not namespace
            // var s = new S();
        }
    }
}

namespace A.B.C
{
    // POI: This Type is defined in A.B.E
    internal class D
    {

    }
}

namespace A.B.E
{
    // POI: This Type is defined in A.B.C
    internal class D
    {

    }

    internal class S
    {

    }
}