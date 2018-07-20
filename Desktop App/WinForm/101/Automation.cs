using System;
using System.Net;
using System.Threading.Tasks;

namespace _101
{
    abstract class Automation
    {
        protected abstract void StartUp(int ownerId, AuotmationType type);

        // POI: async is a implementation details so not required in abstract method only in implementation
        protected abstract Task<bool> AuotmationCompleted();

        protected abstract Task PurgeAutomation();
    }

    class ProjectAutomation : Automation
    {
        protected override async Task<bool> AuotmationCompleted()
        {
            await Task.Delay(10000);

            // POI: A Task must be awaited
            return await new Task<bool>(() => true);
        }

        protected override Task PurgeAutomation()
        {
            throw new NotImplementedException();
        }

        protected override void StartUp(int ownerId, AuotmationType type)
        {
            throw new NotImplementedException();
        }
    }

    enum AuotmationType
    {
    }
}
