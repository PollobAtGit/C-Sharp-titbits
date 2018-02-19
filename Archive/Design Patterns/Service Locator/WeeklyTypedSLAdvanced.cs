using System;
using System.Collections.Generic;  

namespace ServiceLocator
{

  public interface INotificationService { }
  public interface IEmailService { }

  public class NotificationService : INotificationService { }
  public class EmailService : IEmailService { }
  
  public class ConcreteServiceLocator
  {
    private Dictionary<Type, object> _serviceContainer = new Dictionary<Type, object>();
    private static ConcreteServiceLocator _instance = null;

    private ConcreteServiceLocator() { }

    public static ConcreteServiceLocator GetInstance
    {
      get
      {
        return (_instance == null) ? new ConcreteServiceLocator() : _instance;
      }
    }
  
    public TService GetService<TService>() where TService : class
    {
        try
        {
          return _serviceContainer[typeof(TService)] as TService;        
        }
        catch (Exception ex)
        {
          throw ex;
        }
    }
  
    //Poi: There's a chance of misuse. Developer might provide inconsistency <Type, Object> pair
    //But ultimately it won't have any impact because during retrieving a cast is required which will eventually
    //ensure inconsistent type won't be provided
    
    //Poi: Using Generic version solves the above problem. That's why the following statement won't compile:
    //      svcLocator.AddService<INotificationService>(new EmailService());
    
    public void AddService<TService>(TService instance) where TService : class
    {
      try
      {
        _serviceContainer.Add(typeof(TService), instance);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }

  public class Client
  {
    public static void Main()
    {
      var svcLocator = ConcreteServiceLocator.GetInstance;

      svcLocator.AddService<INotificationService>(new NotificationService());
      Console.WriteLine(svcLocator.GetService<INotificationService>().GetType());
    }
  }
}
