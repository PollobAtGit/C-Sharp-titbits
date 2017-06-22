using System;

namespace ExtensionMethodOnInheritance
{

  public class LightBulb
  {
    public int GetWatt() => 10;
    public virtual string GetManufacturer() => "NONE";
  }

  public class IncandescentBulbs : LightBulb
  {
    //Poi: Keyword 'new' in this context will indicate to the compiler that developer is aware that this method declaration
    //will HIDE the base implementation
    public new int GetWatt() => 20;
    public override string GetManufacturer() => "LOWES";
  }
  
  public class HalogenBulbs : IncandescentBulbs
  {
    //Poi: An overridden method is virtual by default. This method 'GetManufacturer()' has been overridden in base class 
    //'IncandescentBulbs' it can be overridden in derived class also
    public override string GetManufacturer() => "ADISON & CO.";
  }

  public static class LightBulbExtensionMethods
  {
    public static string GetPowerAsString(this LightBulb blb)
    {
      //Poi: Here 'blb' is of type 'LightBulb' so if method 'GetWatt()' isn't virtual & if the derived class of LightBulb
      //doesn't override method 'GetWatt()' than 'blb.GetWatt()' will ALWAYS return the base implementation
      return blb.GetWatt().ToString();
    }
    
    public static string GetManufacturerName(this LightBulb blb)
    {
      //Poi: This will invoke the proper method
      return blb.GetManufacturer();
    }
  }

  public class Client
  {
    public static void Main()
    {
    
      Console.WriteLine(new LightBulb().GetPowerAsString());//10
      
      //Poi: Note the returned value. Reason mentioned above
      Console.WriteLine(new IncandescentBulbs().GetPowerAsString());//10
      Console.WriteLine(new HalogenBulbs().GetPowerAsString());//10
    
      Console.WriteLine(new LightBulb().GetManufacturerName());//NONE
      Console.WriteLine(new IncandescentBulbs().GetManufacturerName());//LOWES
      Console.WriteLine(new HalogenBulbs().GetManufacturerName());//ADISON & CO.
    }
  }
}