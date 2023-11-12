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
Console.WriteLine("Este é o maior valor de um tipo ulong: "+tipoUlong+"\n");

#endregion

#region
/*Problema: Suponha que você tenha uma variável do tipo double e deseja convertê-la 
em um tipo int. Como você faria essa conversão e o que aconteceria se a parte 
fracionária da variável double não pudesse ser convertida em um int? Resolva o 
problema através de um exemplo em C#.*/

double tipoDouble = 4.0;
int meuInt = 0;

Console.WriteLine("Valor de tipoDouble: "+tipoDouble);
Console.WriteLine("valor de meuInt: "+meuInt);
meuInt = (int)tipoDouble;
Console.WriteLine("Valor de meuInt apos atribuir tipoDouble: "+meuInt);

tipoDouble = 4.7;
int meuInt2 = 0;
Console.WriteLine("Valor de tipoDouble: "+tipoDouble);
Console.WriteLine("valor de meuInt2: "+meuInt2);
meuInt = (int)tipoDouble;
Console.WriteLine("Valor de meuInt2 apos atribuir tipoDouble: "+meuInt);
Console.WriteLine("parte da informação de ponto flutuante 0.7 é perdida\n");

tipoDouble = 4.8;
int meuInt3 = 0;
Console.WriteLine("Valor de tipoDouble: "+tipoDouble);
Console.WriteLine("valor de meuInt3: "+meuInt3);
meuInt3 = (int)Math.Round(tipoDouble);
Console.WriteLine("Valor de meuInt3 apos atribuir tipoDouble utilizando metodo de arredondamento Math.round da CLasse Math: "+meuInt3);

#endregion

