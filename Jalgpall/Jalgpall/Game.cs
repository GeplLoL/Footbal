using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalgpall
{
    public class Game
    {
        public Team HomeTeam { get; }
        public Team AwayTeam { get; }
        public Walls Stadium { get; }
        public Ball Ball { get; private set; }

        public Game(Team homeTeam, Team awayTeam, Walls stadium)
        {
            HomeTeam = homeTeam;
            homeTeam.Game = this;
            AwayTeam = awayTeam;
            awayTeam.Game = this;
            Stadium = stadium;
        }

        public void Start()
        {
            Ball = new Ball(Stadium.Width / 2, Stadium.Height / 2, this);
            HomeTeam.StartGame(Stadium.Width / 2, Stadium.Height);
            AwayTeam.StartGame(Stadium.Width / 2, Stadium.Height);
            DrawBall pallC = new DrawBall(78, 24, '*');
            Point pall = pallC.BallDraw();
            Console.ForegroundColor = ConsoleColor.Green;
            pall.Draw();
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 6; i++)
            {
                DrawPlayers PlayC = new DrawPlayers(78, 24, 'A');
                Point player = PlayC.PlayersDraw();
                Console.ForegroundColor = ConsoleColor.Blue;
                player.Draw();
                Console.ForegroundColor = ConsoleColor.White;
                DrawPlayers PlayCi = new DrawPlayers(78, 24, 'B');
                Point playeri = PlayCi.PlayersDraw();
                Console.ForegroundColor = ConsoleColor.Red;
                playeri.Draw();
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.SetWindowSize(80, 25);
            Walls walls = new Walls(80, 25);
            walls.Draw();
        }
        private (double, double) GetPositionForAwayTeam(double x, double y)
        {
            return (Stadium.Width - x, Stadium.Height - y);
        }

        public (double, double) GetPositionForTeam(Team team, double x, double y)
        {
            return team == HomeTeam ? (x, y) : GetPositionForAwayTeam(x, y);
        }

        public (double, double) GetBallPositionForTeam(Team team)
        {
            return GetPositionForTeam(team, Ball.X, Ball.Y);
        }

        public void SetBallSpeedForTeam(Team team, double vx, double vy)
        {
            if (team == HomeTeam)
            {
                Ball.SetSpeed(vx, vy);
            }
            else
            {
                Ball.SetSpeed(-vx, -vy);
            }
        }

        public void Move()
        {
            HomeTeam.Move();
            AwayTeam.Move();
            Ball.Move();
        }
    }
}
