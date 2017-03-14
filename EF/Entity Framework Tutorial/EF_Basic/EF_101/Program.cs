using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

//Poi: Infrastructure is required when IObjectContextAdapter needs to be accessed to get ObjectContext
using System.Data.Entity.Infrastructure;

//Poi: ObjectContext resides in this namespace (System.Data.Entity.Core.Objects)
using System.Data.Entity.Core.Objects;

using EF_101.EDM;

    namespace EF_101
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SchoolDBEntities ctx = new SchoolDBEntities())
            {
                ObjectContext objCtx = (ctx as IObjectContextAdapter).ObjectContext
            }
        }
    }
}
