using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Inheritance.Abstract_Class
{
    internal class DerivedClassFromAbstractOne : AbstractClass
    {
        //This constructor must be able to invoke base (in this case abstract class) class's
        //constructor. Which means Base class must have public constructor
        //(what about parameterless & different parameter number)
        public DerivedClassFromAbstractOne()
        {

        }

        //This overriding is by default. Because Abstract class has marked this method as abstract
        //Note the use of keyword 'override'. In this context it does mean this method is being
        //overridden. But doesn't necessarily mean the base class has the same method marked as 'virtual'
        public override void AbstractMethod()
        {
            throw new NotImplementedException();
        }
    }

    internal abstract class AbstractClass
    {
        bool IsAbstract { get; set; }

        //Default value set in parameter. Research on the similarity with C++
        protected AbstractClass(bool _isOverloaded = true)
        {

        }

        //Abstract class's constructor should have some level of visibility (public/protected/internal)
        //1) Single & 2) private constructor causes derived class to think that the derived class can't be
        //initialized by default through constructor invocation chain. (Research more!)
        public AbstractClass()
        {

        }

        public static void IAmAStaticMethodInAAbstractClass()
        {
            Console.WriteLine();
            Console.WriteLine("I AM A STATIC METHOD IN A ABSTRACT CLASS");
            Console.WriteLine();
        }

        //Error CS0513	'AbstractClass.AbstractMethod()' is abstract but it is contained in non-abstract class
        //Makes sense because, essentially if you have a class that has an abstract method then that class is
        //incomplete, in other words Abstract
        public abstract void AbstractMethod();
    }

    internal static class AbstractClassTest
    {
        public static void TryingToCreateInstanceOfAbstractClass()
        {
            //Error CS0144  Cannot create an instance of the abstract class or interface 'AbstractClass'
            //Abstract class shouldn't be instantiated
            //AbstractClass cls = new AbstractClass();

            //Woo! Abstract class's static method can be invoked with the syntax ==> ClassName.StaticMethod()
            AbstractClass.IAmAStaticMethodInAAbstractClass();
        }
    }
}
