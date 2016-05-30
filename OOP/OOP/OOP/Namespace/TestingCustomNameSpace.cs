using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Namespace
{
    public static class TestingCustomNameSpace
    {
        public static void TestNamSpaceMethod()
        {
            Console.WriteLine(typeof(InnerNameSpace.CustomNamespace).Namespace);
            Console.WriteLine(typeof(InnerNameSpace.InnerNameSpaceWithIncustomNameSpace.VeryInnerNameSpace).Namespace);
            Console.WriteLine(typeof(InnerNameSpace.InnerNameSpaceWithIncustomNameSpace.DeepNameSpace.DeepestClass).Namespace);
            Console.WriteLine(typeof(DeepNameSpace.DeepestClass).Namespace);
            Console.WriteLine(typeof(DefaultNameSpace).Namespace);//Returns nothing (EMPTY). Note that no qualifier ha been used
            Console.WriteLine(typeof(SplitNameSpace.ClsFirst).Namespace);
            Console.WriteLine(typeof(SplitNameSpace.ClsSecond).Namespace);
            Console.WriteLine(typeof(Root.Child.RightChild.LeftChild.LastChild.ClassInsideHierarchy).Namespace);
        }
    }
}
