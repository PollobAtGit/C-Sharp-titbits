using System;

public class Program
{
    public delegate void ProcessReporter(int percentageComplete);

    class X
    {
        public void InstanceProcess(int percentageComplete) => Print(percentageComplete);
    }

    public static void Main()
    {
        //This method can not be deleted from delegate because we have no reference to the instance 
        ProcessReporter processReporterInstance = new ProcessReporter(new X().InstanceProcess);
        
        X instance = processReporterInstance.Target as X;
        instance.InstanceProcess(0);//instance has been retrieved from defined delegate

        X xInstance = new X();
        ProcessReporter xProcessReporterInstance = new ProcessReporter(xInstance.InstanceProcess);
        
        //How is this comparison done? Target returns object but xInstance is X. Implicit conversion? 
        Print(xProcessReporterInstance.Target == xInstance);//TRUE

        Print(null);
        Print(xProcessReporterInstance.Method.Name);//InstanceProcess

        Print(xProcessReporterInstance.Method.GetType());//System.Reflection.RuntimeMethodInfo
        //Why 'V' in void uppercase ?!
        Print(xProcessReporterInstance.Method.ToString());//Void InstanceProcess(Int32)

        //TRUE
        Print(string.Equals(xProcessReporterInstance.Method.ToString(), "void InstanceProcess(Int32)", StringComparison.CurrentCultureIgnoreCase));
    }

    public static void Print(object msg) => Console.WriteLine(msg);
}