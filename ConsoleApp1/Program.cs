using System.Net.Quic;

void Vermapa(char[,] mapa){
    for (int i = 0; i < 3; i++)
    {
        System.Console.Write(i);
        for (int j = 0; j < 3; j++)
        {
            Console.Write("[ " + mapa[i, j] + " ]");
        }
        Console.WriteLine(); // Salto de línea después de cada fila
    }
}
bool Ganador(char[,] mapa, char Jugador){
     //vertical primera colummna
    if(mapa[0,0] == Jugador && mapa[0,1] == Jugador && mapa[0,2] == Jugador)
    {
        return true;
    }
    //vertical segunda columna
    if(mapa[1,0] == Jugador && mapa[1,1] == Jugador && mapa[1,2] == Jugador)
    {
        return true;
    }
    //vertical tercera columna
    if(mapa[2,0] == Jugador && mapa[2,1] == Jugador && mapa[2,2] == Jugador)
    {
        return true;
    }

    //Diagonal desde esquina izquierda
    if(mapa[0,0] == Jugador && mapa[1,1] == Jugador && mapa[2,2] == Jugador){
        return true;
    }
    //Diagonal desde esquina derecha
    if(mapa[0,2] == Jugador && mapa[1,1] == Jugador && mapa[2,0] == Jugador){
        return true;
    }

    //primera fila 
    if(mapa[0,0] == Jugador && mapa[1,0] == Jugador && mapa[2,0] == Jugador){
        return true;
    }
    //Segunda fila
    if(mapa[0,1] == Jugador && mapa[1,1] == Jugador && mapa[2,1] == Jugador){
        return true;
    }
    //Tercera Fila
    if(mapa[0,2] == Jugador && mapa[1,2] == Jugador && mapa[2,2] == Jugador){
        return true;
    }

    return false;
}
char CambiarJugador(char JugadorActual){
    return (JugadorActual == 'X') ? 'O' : 'X';
}


char[,] mapa = new char[3, 3];
char JugadorActual = 'X';
int movimientos = 0;

Console.WriteLine("----------Bienvenido----------");
while(true){
    Vermapa(mapa);

    System.Console.WriteLine(JugadorActual + ": indique una fila de 0 a 2");
    int fila = int.Parse(Console.ReadLine());


    System.Console.WriteLine(JugadorActual + ": indique una columna de 0 a 2");
    int columna = int.Parse(Console.ReadLine());

    if (mapa[fila, columna] == '\0')
    {
        mapa[fila, columna] = JugadorActual;

        if(Ganador(mapa, JugadorActual))
        {
            Console.WriteLine(JugadorActual + " Gano");
            Vermapa(mapa);
            break;
        }
        

        JugadorActual = CambiarJugador(JugadorActual);
        movimientos++;

        if(movimientos == 9){
            Console.WriteLine("Se tranco");
            Vermapa(mapa);
            break;
        }
    }

    else
    {
        Console.WriteLine("Esta posicion esta ocupada, intente de nuevo");
    }
}
