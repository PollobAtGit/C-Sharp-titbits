using System.Collections.Generic;

namespace Basic
{

    public class UnitOfWork
    {
        readonly Dictionary<string, IRepository> container = new Dictionary<string, IRepository>();

        public void Register(IRepository repo)
        {
            if (container.ContainsKey(repo.GetType().Name)) { return; }
            container.Add(repo.GetType().Name, repo);
        }

        public void Commit() { }
    }
}
