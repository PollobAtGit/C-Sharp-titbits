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
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            using (SchoolDBEntities ctx = new SchoolDBEntities())
            {
                //ObjectContext objCtx = (ctx as IObjectContextAdapter).ObjectContext;
                Student proxyStudent = ctx.Students.FirstOrDefault<Student>();

                Console.WriteLine(proxyStudent.StudentName);

                //Poi: Following will return 'System.Data.Entity.DynamicProxies.Student.....'
                //Poi: The instance Type is Student still GetType() returns DynamicProxy. Which shows another
                //derived type of Student has been created. That's Student type can hold it also GetType() returns the
                //injected (DynamicProxies.Student) Type
                Console.WriteLine(proxyStudent.GetType());

                Type originalStudentType = ObjectContext.GetObjectType(proxyStudent.GetType());
                Console.WriteLine(originalStudentType);
            }
        }
    }
}
