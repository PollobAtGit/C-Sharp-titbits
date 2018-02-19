using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Data_Type
{
    internal class LinkedListWithClass
    {
        public int itemValue = 256;

        public LinkedListWithClass(int _value)
        {
            LinkedListWithClass cls = new LinkedListWithClass(_value);
            this.itemValue = cls.itemValue;
        }
    }

    internal struct LinkedList
    {
#pragma warning disable 0649
        public int itemValue;
#pragma warning restore 0649

        //Following isn't allowed. It gives the following error, because here (unlike class)
        //'LinkedList' isn't a reference but an actual value type variable instance
        //Error CS0523  Struct member 'LinkedList.next' of type 'LinkedList' causes a cycle in the struct layout

        //LinkedList next;

        public LinkedList(int _value)
        {
            //Note the below assignment.
            //1) 'this' is THIS OBJECT not reference to this object.
            //Compared it to class related example such as: 'this.itemValue = _value'
            //2) new() operator with parameterless constructor creates another LinkedList
            //which have all of it's data members assigned to default value (0 in this case)
            //3) That new LinkedList instance is then assigned to THIS OBJECT
            //4) This can't be done with class specially in this manner because assigning to 'this'
            //isn't allowed for class. In case of class this refers to a reference
            //Something similar can be done with class CONCEPTUALLY & but will cause
            //stack overflow because this approach will result CYCLIC object creation

            this = new LinkedList();
        }
    }


    internal struct Glass
    {
        //Cannot have instance property or field initializers in struct
        //So 'private double height = 0.0;' is not valid
        private double height;
        private double circumference;

        public double Height
        {
            get
            {
                return height;
            }
            private set
            {
                height = value;
            }
        }

        public double Circumference
        {
            get
            {
                return circumference;
            }
            private set
            {
                circumference = value;
            }
        }

        #region Constructor

        //Struct cannot contain explicit parameterless constructors
        //Parameter-less constructor is provided by compiler & user can't override that behavior
        public Glass(double _height, double _circumference)
        {
            //The 'this' object cannot be used before all of its fields are assigned to
            //Summary: Properties of struct can't be accessed before that object is created
            //So properties can't be used in constructor (Use fields directly)
            //Height = _height;

            height = _height;
            circumference = _circumference;
        }

        #endregion
    }

    internal interface ICapacity
    {
        int MinimumCapacity { get; set; }
        int MaximumCapacity { get; set; }
    }

    internal interface IMaximumCapacity
    {

        //Following gives error for good reasons. Interface can only provide contracts or specification.
        //Obviously not definition/implementation. So auto-implemented properties are OK for interface
        //but providing definition for these accessors is not OK
        //Error CS0531	'ICapacity.MaximumCapacity.get': interface members cannot have a definition
        //int MaximumCapacity { get { } set { } }

        int MaximumCapacity { get; set; }
    }

    struct Carrier : IMaximumCapacity, ICapacity
    {
        //Note that ambiguity for MaximumCapacity has been resolved by using explicit interface implementation syntax
        int ICapacity.MaximumCapacity
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        int ICapacity.MinimumCapacity
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        //Interesting! Now the consumer of the interface is bound to provide definition for this property
        int IMaximumCapacity.MaximumCapacity
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }

    //Following attempt to inherit from a class with throw error. Error Code: CS0527
    //It is possible for a struct or interface to inherit from another interface but not from any other type.
    //Other type in this case indicates class

    //internal struct StructThatImplementsClass : LinkedListWithClass { }

    class StructTest
    {
        public static void TestStructInitialization()
        {

#pragma warning disable 0168
            Glass bigGlass;
#pragma warning restore 0168

            //Following is not compilable because at line #44 only variable is defined but none of the members are initialized
            //Error CS0165  Use of unassigned local variable 'bigGlass'
            //Console.WriteLine("Glass Circumference: " + bigGlass.Circumference + "\nGlass height: " + bigGlass.Height);

            //Here 'new()' operator is implicitly initializing (zeroing) all struct members
            //This is the default constructor
            Glass mediumSizedGlass = new Glass();
            Console.WriteLine("Glass Circumference: " + mediumSizedGlass.Circumference
                + "\nGlass height: " + mediumSizedGlass.Height);

            Glass bigSizedGlass = new Glass(20.56, 56.96);
            Console.WriteLine("Glass Circumference: " + bigSizedGlass.Circumference
                + "\nGlass height: " + bigSizedGlass.Height);

            //As new() operator hasn't been invoked here, none of the members are initialized. So invoking any of the
            //members (field or method) will cause compilation error

#pragma warning disable 0168
            Glass regularGlass;
#pragma warning restore 0168

            //System.ValueType
            Console.WriteLine(bigSizedGlass.GetType().BaseType);

            //System.Object
            Console.WriteLine(bigSizedGlass.GetType().BaseType.BaseType);

            //{NULL}
            Console.WriteLine(bigSizedGlass.GetType().BaseType.BaseType.BaseType);
            //Console.WriteLine(bigSizedGlass.GetType().BaseType.BaseType.BaseType.BaseType);//NULL EXCEPTION

            //Following object creation will expectedly give the following error:
            //(note class definition & discussion inside constructor of struct 'LinkedList')
            //Process is terminated due to StackOverflowException.
            //LinkedListWithClass cls = new LinkedListWithClass(50);
        }
    }
}
