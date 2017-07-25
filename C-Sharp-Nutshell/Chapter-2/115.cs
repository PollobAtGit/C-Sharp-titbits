
// cls & csc /r:WidgetOne=115_lib_a.dll /r:WidgetTwo=115_lib_b.dll 115.cs

namespace Main
{
    // POI: General aliasing solves the problem of using two Types with same names
    // (in different namespaces) inside the solution

    // POI: Same named Types can be resolved using alias 'using alias = Fully Qualified Name'
    // POI: Static class members can be accessed easily using 'using static ...'
    // POI: Direct usage of using statement imports the whole namespace

    // POI: But problem occurs when third party assemblies are imported into the
    // solution & multiple third party assemblies has same fully qualified names
    // (namespace + Type name)

    // POI: Which Widget is being aliased? Both 115_lib_a.dll & 115_lib_b.dll contains
    // Widget
    // using Wid = Widgets.Widget;

    // POI: WidgetOne & WidgetTwo both are aliased from command line
    // POI: 'extern' & 'alias' both are keywords
    extern alias WidgetOne;
    extern alias WidgetTwo;

    internal static class Solution
    {
        internal static void Main()
        {
            // POI: Using 'WidgetOne' which is a alias that is imported in
            // the namespace
            var widget = new WidgetOne.Widgets.Widget();
        }
    }
}