using System;

namespace ExtensionMethod
{

  public interface IServiceLocator<T> where T : class
  {
    T GetService();
  }

  //Poi: Constraint on type parameter is required because IServiceLocator is also using the same type parameter but IServiceLocator
  //has a type parameter constraint
  public class ConcreteServiceLocator<T> : IServiceLocator<T> where T : class
  {
    public T GetService()
    {
      throw new NotImplementedException();
    }
  }

  public static class IServiceLocatorExtensionMethods
  {
    //Poi: Note the Type parameter here. This method is required to be generic because it's an extension method of a generic
    //interface
    //Poi: Because of the same reason that there is a constraint upon the interface's Type parameter this extension method
    //must declare the same constraint on the Type parameter
    public static T GetServiceFromExtMethod<T>(this IServiceLocator<T> svcLctr) where T : class
    {
      throw new NotImplementedException();
    }
    
    public static T GetServiceDelegateToImplementer<T>(this IServiceLocator<T> svcLctr) where T : class
    {
      //Poi: 'GetService' method is invoked via the variable. ANY IServiceLocator<T> type object can access 
      //this (GetServiceDelegateToImplementer) method and as a definition that type MUST implement 'GetService'
      //So eventually invocation to 'svcLctr.GetService()' will invoke that type's implemented 'GetService()'
      return svcLctr.GetService();
    }    
  }

  public class Client
  {
    public static void Main()
    {
      var serviceLocator = new ConcreteServiceLocator<Type>();
      
      try
      {
        serviceLocator.GetServiceFromExtMethod();
      }
      
      //Poi: As the exception isn't being used no variable has been declared. Only the Exception type has been mentioned here
      catch (NotImplementedException)
      {
        Console.WriteLine("GetServiceFromExtMethod() isn't implemented");
      }
      
      try
      {
        serviceLocator.GetServiceDelegateToImplementer();
      }
      
      //Poi: As the exception isn't being used no variable has been declared. Only the Exception type has been mentioned here
      catch (NotImplementedException)
      {
        Console.WriteLine("GetServiceDelegateToImplementer() isn't implemented");
      }
    }
  }
}