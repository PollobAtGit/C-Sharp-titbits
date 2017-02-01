using System;

namespace ServiceLocatorNamespace
{
  public interface IServiceLocator
  {
    object GetService(Type serviceType);
  }

  public interface IMessageService { }
  public interface INotificationSystem { }

  public class EmailService : IMessageService { }
  public class NotificationSystem : INotificationSystem 
  { 
    private IMessageService service;
    public NotificationSystem(IServiceLocator svc)
    {
      service = (IMessageService)svc.GetService(typeof(IMessageService));
    }
  }

  public class ServiceLocatorConcrete : IServiceLocator
  {
    public object GetService(Type serviceType)
    { 
      if(serviceType == typeof(IMessageService))
      {
        return new EmailService();
      }
      
      if(serviceType == typeof(INotificationSystem))
      {
        return new NotificationSystem(this);
      }
      
      throw new NotImplementedException("Only IEmailService & INotificationSystem types are allowed");
    }
  }

  public class ServiceLocatorClient
  {
    public static void Main()
    {
      var notificationSys = new ServiceLocatorConcrete().GetService(typeof(INotificationSystem));
    }
  }
}

//Poi: GetType on any object will return the Type of that object in runtime
//Poi: typeof will take the class/interface/enum/struct as the parameter & will return a Type object
//Poi: Normally usage is like this: 
//  if(obj.GetYpe() == typeof(CLASS_NAME) { ... }

//Cmwk: What are the other usages of typeof() or GetType()? Search for idiomatic usage.