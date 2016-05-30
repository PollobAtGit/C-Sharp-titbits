using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//No access specifier is acceptable for namespace because it is be default 'public'
//(Compare with 'interface', in which case too no specifier is allowed because that
//interface & it's members are public by default). If used it will throw the following
//error: Error CS1671  A namespace declaration cannot have modifiers or attributes
namespace OOP.Namespace
{
    //Namespace is a container for related classes.
    //Besides classes it also contains interface,
    //struct & enum
    namespace InnerNameSpace
    {
        struct InnerStruct
        {

        }

        class CustomNamespace
        {
            public CustomNamespace()
            {

            }
        }

        namespace InnerNameSpaceWithIncustomNameSpace
        {
            class VeryInnerNameSpace
            {
                public VeryInnerNameSpace()
                {

                }
            }

            interface IInnerInterface
            {
                void InterfaceMethod();
            }

            namespace DeepNameSpace
            {
                enum Month
                {
                    JAN
                    , FEB
                    , MARCH
                    , APRIL
                    , MAY
                    , JUNE
                    , JULY
                    , AUGUST
                    , SEPTEMBER
                    , OCTOBER
                    , NOVEMBER
                    , DECEMBER
                }

                class DeepestClass
                {
                    public DeepestClass()
                    {

                    }

                    public void DeepestClassMethod()
                    {

                    }
                }
            }
        }
    }

    //Note that: There's a namespace with same name above. But the following namespace is in a 
    //different namespace (hierarchy/sub-tree). Fully qualified name of the following namespace is:
    //OOP.Namespace.DeepNameSpace
    //But fully qualified namespace of the above namespace is:
    //OOP.Namespace.DeepNameSpace.InnerNameSpaceWithIncustomNameSpace.DeepNameSpace
    //See output of 'Namespace.TestingCustomNameSpace.TestNamSpaceMethod()' to find
    //out the difference between both class's namespace
    namespace DeepNameSpace
    {
        class DeepestClass
        {
            public DeepestClass()
            {

            }
        }
    }

    namespace SplitNameSpace
    {
        class ClsFirst
        {
            public ClsFirst()
            {

            }
        }
    }

    namespace SplitNameSpace
    {
        //Compiler properly gets that this namespace contains this same class (ClsFirst) in some other place.
        //So the following class creation statement throws the below error
        //Error CS0101  The namespace 'OOP.Namespace.SplitNameSpace' already contains a definition for 'ClsFirst'
        //class ClsFirst

        class ClsSecond
        {

        }
    }

    namespace Root.Child.RightChild.LeftChild.LastChild
    {
        class ClassInsideHierarchy
        {
            public ClassInsideHierarchy()
            {
                    
            }
        }
    }
}
