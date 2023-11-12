#region
// Quais são os tipos de dados numéricos inteiros disponíveis no .NET?
//  R: short, ushort, int, uint, long, ulong.
// Dê exemplos de uso para cada um deles através de exemplos.

short tipoShort;
ushort tipoUshort;
int tipoInt;
uint tipoUint;
long tipoLong;
ulong tipoUlong;

tipoShort = short.MinValue;
tipoUshort = ushort.MaxValue;
tipoInt = -100;
tipoUint = 100;
tipoLong = long.MinValue;
tipoUlong = ulong.MaxValue;

Console.WriteLine("Este é o meno valor de um tipo short: "+tipoShort);
Console.WriteLine("Este é o maior valor de tipo ushort: "+tipoUshort);
Console.WriteLine("Este é um inteiro negativo: "+tipoInt);
Console.WriteLine("Este é um inteiro positivo: "+tipoUint);
Console.WriteLine("Este é o menor valor de um tipo long: "+tipoLong);
Console.WriteLine("Este é o maior valor de um tipo ulong: "+tipoUlong);



#endregion

