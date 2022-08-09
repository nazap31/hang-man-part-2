string[] words = new string[] { "computadora", "botella", "lapiz", "celular", "internet", "gato", "zorro", "oveja" };
char[] guesses;
string[] fails;
string secretWord;
bool won, lost;

Random random = new Random();
int index = random.Next(words.Length);
secretWord = words[index];
guesses = new char[secretWord.Length];
Array.Fill(guesses, '*');
fails = new string[0];
won = false;
lost = false;



Console.WriteLine("\n\n¡Bienvenido a ahorcado para 2 jugadores!\n\n");
Console.WriteLine("Porfavor ingrese el nombre del jugador 1: ");
string NumberPlayer1 = Console.ReadLine() ?? "";
Console.WriteLine("\nPorfavor ingrese el nombre del jugador 2: ");
string NumberPlayer2 = Console.ReadLine() ?? "";
NombresdeJugadores();
void NombresdeJugadores()
{
    Console.Write("\nJugador 1 :" + NumberPlayer1);
    Console.Write("             Jugador 2 :" + NumberPlayer2);
}

gameCicle();

void gameCicle()
{

    Console.WriteLine($"\n\nLa palabra secreta es {new String(guesses)}");
    printHangMan();
    if (lost)
    {
        Console.WriteLine("¡Perdieron todos los turnos!");

    }
    else if (won)
    {
        int turno = fails.Length;
        if (turno % 2 == 0)
        {
            Console.WriteLine("\n¡Felicidades! Ha ganado el jugador 1: " + "¡" + NumberPlayer1 + "!\n\n");

        }
        else
        {
            Console.WriteLine("\n¡Felicidades! Ha ganado el jugador 2: " + "¡" + NumberPlayer2 + "!\n\n");

        }

    }
    else
    {
        playerTurn();
        gameCicle();
    }
    
    
}


void playerTurn()
{
    int turno = fails.Length;
    if (turno % 2 == 0)
    {
        jugador1();
        Console.WriteLine("Turno del jugador 1: " + NumberPlayer1);
    }
    else
    {
        jugador2();
        Console.WriteLine("Turno del jugador 2: " + NumberPlayer2);
    }

    Console.Write("Ingrese una letra o adivine la palabra: ");
    string attempt = Console.ReadLine() ?? "";
    if (attempt.Length == 0)
    {
        Console.WriteLine("Intente de nuevo");
    }
    else if (attempt.Length == 1)
    {
        lookForLetter(attempt[0]);
    }
    else
    {
        tryToGuess(attempt);
    }
}

void lookForLetter(char letter)
{
    Console.WriteLine("Buscando letra...");
    if (secretWord.IndexOf(letter) > -1)
    {
        Console.WriteLine($"La letra {letter} SI está!");
        partidasGanadasLetra();
        void partidasGanadasLetra()
        {
            int turno = fails.Length;
            if (turno % 2 == 0)
            {
                jugador1();
                Console.WriteLine("El jugador que adivino la letra es: " + "¡" + NumberPlayer1 + "!");

            }
            else
            {
                jugador2();
                Console.WriteLine("El jugador que adivino la letra es: " + "¡" + NumberPlayer2 + "!");

            }


        }


        for (int i = 0; i < secretWord.Length; i++)
        {
            if (secretWord[i] == letter)
            {
                guesses[i] = letter;
                

            }
        
        
        }

        won = (Array.IndexOf(guesses, '*') == -1);


    }
    else
    {
        Console.WriteLine($"La letra {letter} NO está!");
        Array.Resize(ref fails, fails.Length + 1);
        fails.SetValue(letter.ToString(), fails.Length - 1);
    }
}

void tryToGuess(string word)
{
    if (secretWord == word)
    {
        Console.WriteLine($"La palabra {word} SI es");
        guesses = secretWord.ToCharArray();
        won = true;
        partidasGanadasPalabra();
        void partidasGanadasPalabra()
        {
            int turno = fails.Length;
            if (turno % 2 == 0)
            {
                jugador1();
                Console.WriteLine("El jugador que adivino la palabra es: " + "¡" + NumberPlayer1 + "!");

            }
            else
            {
                jugador2();
                Console.WriteLine("El jugador que adivino la palabra es: " + "¡" + NumberPlayer2 + "!");

            }


        }

    }
    else
    {
        Console.WriteLine($"La palabra {word} NO es");
        Array.Resize(ref fails, fails.Length + 1);
        fails.SetValue(word, fails.Length - 1);

    }
}
void printHangMan()
{
    Console.Write("Intentos fallidos: ");
    for (int i = 0; i < fails.Length; i++)
    {
        Console.Write(fails[i] + ' ');

    }
    int f = fails.Length;
    Console.WriteLine();
    Console.WriteLine("|---");
    Console.WriteLine($"|   {(f > 0 ? 'o' : ' ')}");
    Console.WriteLine($"|  {(f > 2 ? '/' : ' ')}{(f > 1 ? '|' : ' ')}{(f > 3 ? '\\' : ' ')}");
    Console.WriteLine($"|  {(f > 4 ? '/' : ' ')} {(f > 5 ? '\\' : ' ')}");
    Console.WriteLine("|");
    Console.WriteLine("/--------\\");
    if (f == 6)
    {
        lost = true;
    }
}

void jugador1()
{
    int turno = fails.Length;
    if (turno == 0)
    {
        Console.WriteLine("");
    }

    else if (turno == 2)
    {
        Console.WriteLine("");
    }

    else if (turno == 4)
    {
        Console.WriteLine("");
    }

}

void jugador2()
{
    int turno = fails.Length;

    if (turno == 1)
    {
        Console.WriteLine("");
    }

    else if (turno == 3)
    {
        Console.WriteLine("");
    }

    else if (turno == 5)
    {
        Console.WriteLine("");
    }

}



