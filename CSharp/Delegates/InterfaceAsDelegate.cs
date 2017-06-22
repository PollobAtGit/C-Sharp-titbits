using System;

public class Program
{
    public static void Main()
    {
        float[] array = new float[] { 1.23f, 56.02f };
        
        //POI: the transformer instance implements ITransformer<float> so Transform method will take it
        Transform(array, new SquareFloatTransformer());

        foreach(var elem in array)
        {
            Print(elem);
        }
    }

    private static void Transform<T>(T[] array, ITransformer<T> transformer)
    {
        for(var i = 0; i < array.Length; i++)
        {
            array[i] = transformer.Transform(array[i]);
        }
    }

    //POI: Interface declared inside class
    //POI: Interface can be declared private. The reason why I have found interface can't be declared 
    // anything but public/internal is may be I use to declare them inside namespace & no element inside
    // namespace can be declared private/protected/protected internal
    private interface ITransformer<T>
    {
        T Transform(T a);
    }

    //Type parameter isn't open anymore
    private class SquareIntTransformer : ITransformer<int> 
    {
        //Why no access modifiers are valid here? Infact defining nothing makes it private by default still private can't be specified!
        int ITransformer<int>.Transform(int a) => a * a;
    }

    private class SquareFloatTransformer : ITransformer<float> 
    {
        //Why no access modifiers are valid here? Infact defining nothing makes it private by default still private can't be specified!
        float ITransformer<float>.Transform(float a) => a * a;
    }

    private class CubeDoubleTransformer : ITransformer<double>
    {
        //POI: Following is not allowed because interface ITransformer has been closed for double but here
        // it's being implemented for int. So there are two issues: 1) ITransformer<double> is not implemented
        // 2) Following method doesn't conform to the type to which we have closed type parameter  
        //int ITransformer<int>.Transform(int a) => a * a * a;

        double ITransformer<double>.Transform(double a) => a * a * a;
    }

    public static void Print(object msg) => Console.WriteLine(msg);
}

/*
Interface can be used instead of delegate in most of the cases But there are some issues:

# Interface can not be used when multicast delegates are required
# Interfaces are cumbersome when multiple instances need to be created that implements the interface   

But in case where following are true a delegate is a better option

# The replacement interface contains only one method (in this case interface is a over kill)
# Developer needs multcase capability

*/

