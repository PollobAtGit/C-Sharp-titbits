
void Print(object obj) { Console.WriteLine(obj); }

var stringBuilderInstance = new StringBuilder("Some");

Print(stringBuilderInstance);//Some

Modify(stringBuilderInstance);

Print(stringBuilderInstance);//SomeString

//POI: Both 'stringBuilderInstance' & 'sb' are referencing the same memory location. But they are SEPERATE variables. So setting 'sb' to 'null'
//doesn't make stringBuilderInstance null because it's a SEPERATE variable which references the original memory location
//POI: At the end of each method invocation the local instance variables are de-referenced but that doesn't make the original instance variable
//'null' because of this feature
Null(stringBuilderInstance);

Print(stringBuilderInstance);

//POI: 'sb' & 'stringBuilderInstance' both references the same memory location but they ARE INDEPENDENT variables
void Modify(StringBuilder sb)
{
    //POI: This statement WILL change the original 'stringBuilderInstance'
    sb.Append("String");
}

void Null(StringBuilder sb) { sb = null; }