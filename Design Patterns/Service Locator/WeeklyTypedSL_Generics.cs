using System;
using System.Collections.Generic;  

namespace ServiceLocator
{

  public interface INotificationService { }

  public class NotificationService : INotificationService
  {
    public NotificationService() { }
  }

  public interface IServiceLocator
  {
    object GetService(Type svcType);
    TService GetService<TService>() where TService : class;
  }

  public class ConcreteServiceLocator : IServiceLocator
  {
    public object GetService(Type svcType) { throw new NotImplementedException("Generic alternative is available"); }
    public TService GetService<TService> () where TService : class
    { 
      if(typeof(TService) == typeof(INotificationService))
      {
        //Cmwk: Why doesn't (TService)(new NotificationService()) works?
        return new NotificationService() as TService;
      }
      throw new NotImplementedException(); 
    }
  }

  public class Client
  {
    public static void Main()
    {
      var svcLocator = new ConcreteServiceLocator();
      var svc = svcLocator.GetService<INotificationService>();
      
      Console.WriteLine(svc.GetType());
    }
  }
}
