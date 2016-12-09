using System;
using System.Collections.Generic;

public class Program
{
    private delegate void XDel();

    public static void Main()
    {
        Tuple<double> aTpl = Tuple.Create(85.56);
        Tuple<double, int> bTpl = Tuple.Create(85.56, 78);
        Tuple<double, int, float> cTpl = Tuple.Create(85.56, 78, 56.20f);
        Tuple<double, int, float, decimal> dTpl = Tuple.Create(85.56, 78, 56.20f, 0.00m);
        Tuple<double, int, float, decimal, string> eTpl = Tuple.Create(85.56, 78, 56.20f, 0.00m, "");
        Tuple<double, int, float, decimal, string, char> fTpl = Tuple.Create(85.56, 78, 56.20f, 0.00m, "", ' ');

        //128 needed to be cast to byte because compiler considers 128 as int & for bytes there's no character literal defined in .NET 
        Tuple<double, int, float, decimal, string, char, byte> gTpl = Tuple.Create(85.56, 78, 56.20f, 0.00m, "", ' ', (byte)128);

        //A object is being inserted into tuple
        Tuple<double, int, float, decimal, string, char, X> hTpl = Tuple.Create(85.56, 78, 56.20f, 0.00m, "", ' ', new X());

        IList<X> xLst = new List<X> { new X() };

        //Why can't 'new List<X>() { new X() }'  be used in place of 'xLst' 
        Tuple<double, int, float, decimal, string, char, IList<X>> iTpl = Tuple.Create(85.56, 78, 56.20f, 0.00m, "", ' ', xLst);

        Print(aTpl.Item1);
        Print(bTpl.Item1 + " " + bTpl.Item2);
        Print(cTpl.Item1 + " " + cTpl.Item2 + " " + cTpl.Item3);
        Print(dTpl.Item1 + " " + dTpl.Item2 + " " + dTpl.Item3 + " " + dTpl.Item4);
        Print(eTpl.Item1 + " " + eTpl.Item2 + " " + eTpl.Item3 + " " + eTpl.Item4 + " " + eTpl.Item5);
        Print(fTpl.Item1 + " " + fTpl.Item2 + " " + fTpl.Item3 + " " + fTpl.Item4 + " " + fTpl.Item5 + " " + fTpl.Item6);
        Print(gTpl.Item1 + " " + gTpl.Item2 + " " + gTpl.Item3 + " " + gTpl.Item4 + " " + gTpl.Item5 + " " + gTpl.Item6 + " " + gTpl.Item7);

        Print(hTpl.Item7.Content == 10);//TRUE
        Print(iTpl.Item7[0].Content == 10);//TRUE

        Print(hTpl.Item7.XContent == 0);//TRUE
        Print(iTpl.Item7[0].XContent == 0);//TRUE

        //Other .NET types in Tuple
        Tuple<XDel> jTpl = Tuple.Create(new XDel(MethodOne));
        Tuple<X.Country> kTpl = Tuple.Create(X.Country.BD);
    }

    private class X 
    { 
        public int Content { get { return 10; }}
        
        //This will always return 0 because that's the default for int
        public int XContent { get; }

        public enum Country
        {
            BD,
            UK
        }
    }

    public static void MethodOne() { }

    public static void Print<T>(T msg) => Console.WriteLine(msg);
}

/*
POI: Setting '' to a char variable isn't allowed (CE) because '' IS NOT EMPTY rather NULL
        To put EMPTY in a char variable use a SPACE in between. So the first statement below is NOT valid but the second one is valid

            var char = '';//EMPTY CHARACTER LITERAL. SIMILAR TO SETTING null
            var char = ' ';//Note SPACE

POI: IList<T> provides array like indexer but ICollection<T> doesn't provide anything like that to access Collection content. So following statement are valid
    
    IList<int> list = new List<int> { 0, 1, 2 };
    var isTrue = list[0] == 0;
    isTrue = list[1] == 1;
    isTrue = list[2] == 2;

*/