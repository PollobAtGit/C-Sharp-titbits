using System.Web.Http;
using WebInterface.Factories;

namespace WebInterface.Controllers
{
    public class CalculatorController : ApiController
    {
        //http://localhost:28529/api/calculator?binaryOperation=%2B&x=10&y=20
        public int Get(string binaryOperationStream)
        {
            var interfaceInstance = new PlainTextInterface(binaryOperationStream);
            var factory = new CommandFactory(interfaceInstance);

            var command = factory.GetCommand(operation: interfaceInstance.Operation);
            return (int)command.Execute();
        }
    }
}
