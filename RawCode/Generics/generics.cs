using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		var intStack = new Stack<int>();
		var strStack = new Stack<string>();
		var bookStack = new Stack<Book>();
		
		try
		{
			//Int operations
			intStack.Push(10);
			intStack.Push(20);
			intStack.Push(100);

			Console.WriteLine("INT OPERATION OUTPUTS\n");
			Console.WriteLine(intStack.Pop());
			Console.WriteLine(intStack.Pop());
			Console.WriteLine(intStack.Pop() + "\n");

			//String operations

			strStack.Push("Samsung");
			strStack.Push("Amber Heard");
			strStack.Push("Paulo Coelho");

			Console.WriteLine("STRING OPEARTION OUTPUTS\n");
			Console.WriteLine(strStack.Pop());
			Console.WriteLine(strStack.Pop());
			Console.WriteLine(strStack.Pop() + "\n");

			//Operation With Custom Object
			bookStack.Push(new Book(price: 563.23m, title: "Mao: The Unknown Story"));
			bookStack.Push(new Book(price: 458.00m, title: "Catch-22"));
			
			Console.WriteLine(bookStack.Pop().ToString());
			Console.WriteLine(bookStack.Pop().ToString() + "\n");

			//Higher Boundary Checking
			intStack.Push(10);
			intStack.Push(20);
			intStack.Push(100);
			intStack.Push(30);//Should throw EXCEPTION

			strStack.Push("Samsung");
			strStack.Push("Amber Heard");
			strStack.Push("Paulo Coelho");
			strStack.Push("Exception");//Should throw EXCEPTION			

			//Lower Boundary Checking
			Console.WriteLine(intStack.Pop());
			Console.WriteLine(strStack.Pop());
		}
		catch(IndexOutOfRangeException exp)
		{
			Console.WriteLine(exp.Message);
		}
	}
}

public class Stack<T>
{
	private const int _capacity = 3;
	private T[] _array = new T[_capacity];
	private int _length = -1;

	public Stack()
	{

	}

	public void Push(T valueToPut)
	{
		if(_length == (_capacity - 1))
			throw new IndexOutOfRangeException("Max Capacity " + _capacity);

		_array[++_length] = valueToPut;
	}

	public T Pop()
	{
		if(_length == -1)
			throw new IndexOutOfRangeException("No Elements Exist In Stack");

		return _array[_length--];
	}
}

public class Book
{
	private string _title;
	private decimal _price;

	public Book(string title, decimal price)
	{
		this._title = title;
		this._price = price;
	}

	public override string ToString()
	{
		return "Book Title: " + _title + " => Price: " + _price;
	}
}
