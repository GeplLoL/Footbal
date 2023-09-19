using Jalgpall;
using System.Drawing;
class Programm
{
    static void Main(string[] args)
    {
        Console.WriteLine("Nimi: ");
        string name = Console.ReadLine();
        string name2 = Console.ReadLine();
        string name3 = Console.ReadLine();
        Player player = new Player(name);
        Team B = new Team(name2);
        Team A = new Team(name3);
        B.AddPlayer(player);
        A.AddPlayer(player);
        Walls stadium1 = new Walls(600, 700);
        Game game = new Game(B, A, stadium1);
        Ball pall = new Ball(50,50,game);

        game.Start();
    }

}