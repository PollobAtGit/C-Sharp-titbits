using System;
using System.Collections.Generic;

namespace Ch_9.DI
{
    internal class DependencyResolver
    {
        private static Dictionary<Type, object> DependencyBucket { get; }

        static DependencyResolver()
        {
            DependencyBucket = new Dictionary<Type, object>();
        }

        public static void Register<T, U>() where U : T
        {
            if (DependencyBucket.ContainsKey(typeof(T)))
                throw new Exception("Service is already registered");

            // if empty/parameterless constructor exists for the type then initialize 
            //an object of that Type

            if (typeof(U).GetConstructor(Type.EmptyTypes) != null)

                // TODO: Find a better way
                DependencyBucket.Add(typeof(T), (U)Activator.CreateInstance(typeof(U), null));
            else
            {
                var u = GetResolvedParametersType<U>();

                if (u != null)
                {
                    var t = (U)Activator.CreateInstance(typeof(U), u.ToArray());
                    DependencyBucket.Add(typeof(T), t);
                }
            }
        }

        private static List<object> GetResolvedParametersType<U>()
        {
            foreach (var ctor in typeof(U).GetConstructors())
            {
                var resolvedParams = new List<object>();
                var parameterInfos = ctor.GetParameters();

                foreach (var param in parameterInfos)
                {
                    try
                    {
                        resolvedParams.Add(DependencyBucket[param.ParameterType]);
                    }
                    catch { }
                }

                if (parameterInfos.Length == resolvedParams.Count)
                {
                    return resolvedParams;
                }
            }

            return null;
        }

        public static object Resolve<T>() => DependencyBucket[typeof(T)];
    }
}