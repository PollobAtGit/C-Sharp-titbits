using System;

namespace ServiceLocatorNamespace
{
  public interface IServiceLocator
  {
    IMessageService GetMessageService();
    INotificationSystem GetNotificationService();
  }

  public interface IMessageService { }
  public interface INotificationSystem { }

  public class EmailService : IMessageService { }
  public class NotificationSystem : INotificationSystem 
  { 
    private IMessageService service;
    public NotificationSystem(IServiceLocator svc)
    {
      service = svc.GetMessageService();
    }
  }

  public class ServiceLocatorConcrete : IServiceLocator
  {
    public IMessageService GetMessageService() { return new EmailService(); }
    
    //Poi: Note this usage. Here NotificationSystem depends on a service locator but NotificationSystem
    //can be provided by service locator too. So this locator injects itself into NotificationSystem.
    
    //Cmwk: What's the advantage of this approach? Why would I want to use this approach?
    public INotificationSystem GetNotificationService() { return new NotificationSystem(this); }
  }

  public class ServiceLocatorClient
  {
    public static void Main()
    {
      var clientServiceLocator = new ServiceLocatorConcrete();
      var notificationService = clientServiceLocator.GetNotificationService();
      var messageService = clientServiceLocator.GetMessageService();  
    }
  }
}

//Cmwk: What's the difference between strongly typed & weekly typed service locator?
//Cmwk: Normally, should an application contain one concrete implementation of the service locator interface?