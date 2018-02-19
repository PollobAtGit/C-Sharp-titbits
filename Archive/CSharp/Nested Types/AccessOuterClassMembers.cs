using System;

internal class Parent 
{
	//Note that here child is being initialized with 'this' which is the Parent itself
	internal Child ChildMemberWithParent { get { return new Child(this); } }
	internal Child ChildMember { get { return new Child(); } }

	private readonly int _value = 10;	
	internal static int _staticValue = 100;
	
	//Full set of access modifiers on class. This is not possible for the outer class
	//or any class that is declared inside a namespace. Because any member inside namespace has to be public or internal
	protected internal class ProtectedChildMember { }
	private class PrivateChild { }
	public class PublicChild { }
	protected class ProtectedChild { }
	internal class InternalChild { }

	//Nested classes are usual class members. That's why if not specified then the nested class's access specifier is 'private' 
	class IAmAPrivateNestedCls { }

	internal class Child
	{
		private readonly Parent _parent = null;

		//Why is public allowed? The class is defined in 'internal' scope. So outside the project this class can't be referenced but because of the
		//constructor access specifier (public) it seems like it can be accessed outside the project
		public Child()
		{
			//This is not valid. Because for a nested class to AUTOMATICALLY access a member of the outer containing class that member HAS TO BE static
			//Other obvious option is to create a instance of the outer class & access it. One difference between a normal object creation & object
			//creation inside nested class is that the instance can be used to access PRIVATE members of the instance class  
			//Console.WriteLine("Top Level Value: " + _value);

			var value = new Parent()._value;//As _value is an instance member an object HAS TO BE created 
			
			//Static members from outer class are AUTOMATICALLY available to the nested class
			var staticValue = _staticValue;
		}

		public Child(Parent parent)
		{
			_parent = parent;
		}

		public int? getParentValue() 
		{
			//Note that '_value' is a private member in Parent class.
			//This is the difference between a normal object & an object inside a nested class

			//General rule is that a nested class (Child) can access any member that the enclosing class (Parent) has access to

			return _parent?._value;
		}
	}
}

class Program
{
	public static void Main()
	{
		//Accessing Nested class
		var parent = new Parent();

		var parentValue = parent.ChildMember.getParentValue(); 

		//Create object for nested class
		//Note that full name for the class is needed & the invocation is like accessing any static members

		var childObj = new Parent.Child();
		
		//The above can also written as following
		Parent.Child parentChildObj = new Parent.Child();

		//Following will not compile because the child member is private to Parent class
		//Parent.PrivateChild prvtChild = new Parent.PrivateChild();//CS0122

		//Using another ctor of Child class that takes parent
		var childObjWithParent = new Parent.Child(parent);

		//Assertions
		Prnt(parent.ChildMemberWithParent.getParentValue() == 10);//True
		Prnt(parentValue == null);//True
		Prnt(childObj.getParentValue() == null);//True
		Prnt(childObjWithParent.getParentValue() == 10);//True
	}

	public static void Prnt(object msg) => Console.WriteLine(msg);
}

//POI #1: One usecase for nested class is that some entity (not member of that class) must access private members of the class
// Nested class can do it.
//POI #2: Another usecase for nested class is that to have greater access control over some type (class, struct, interface, enum).
// This can be achived because nested classes are ultimately members of outer class & any member of a class can have
// any of the permissible access modifiers (public, private, protected, protected internal) though types under namespace
// can have only two possible access specifiers (public & internal). Default is internal 

//Some excellent examples can be found here: http://stackoverflow.com/questions/1083032/why-would-i-ever-need-to-use-c-sharp-nested-classes