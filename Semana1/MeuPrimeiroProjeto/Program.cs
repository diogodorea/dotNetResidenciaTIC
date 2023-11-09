// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

#region Teste de tipos de dados

    int tipoInteiro;
    double tipoDouble;
    string tipoString;
    long tipoLong;

    tipoInteiro = int.MaxValue;
    tipoLong = int.MaxValue;
    tipoString = "100";
    tipoInteiro=int.Parse(tipoString);
    Console.WriteLine("O Máximo valor positivo intero é: "+ tipoInteiro);
    Console.WriteLine("O Máximo valor positivo long é: "+ tipoLong);
    

#endregion

#region Operadores
    tipoDouble = tipoInteiro+tipoLong;
    //Conversão implciita não é possivel visto que long e double não cabem num inteiro
    //tipoInteiro=tipoDouble+tipoLong;

#endregion