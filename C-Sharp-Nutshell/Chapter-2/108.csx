
void Print(object obj) { Console.WriteLine(obj); }

var x = 10;

Print(x);//10
Print(2 * x);//20

//POI: Assignment expression returns the number that has been assigned. So operations occur, 1) Assignment
//2) Returning assignment value
Print(2 * (x = 20));//40
Print(x);//20

Print(null);

//POI: To use continuous assignment the variables must be defined/declared before. In this case variable declaration &
//initialization can't be done together
int s, k, m;

//POI: 'k = 10' returns 10 which is assigned to 's'. (s = k = 10) returns 10 which is then multiplied with 100
//POI: This style of continuous assignment only works because assignment expressions return value that has been assigned
m = 100 * (s = k = 10);

Print(s);//10
Print(k);//10
Print(m);//1000
