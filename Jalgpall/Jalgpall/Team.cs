using System;
using System.Collections.Generic;

namespace Jalgpall
{
    public class Team
    {
        public List<Player> Players { get; } = new List<Player>();
        public string Name { get; private set; }
        public Game Game { get; set; }

        public Team(string name)
        {
            Name = name;
        }

        // Устанавливает позицию игрока случайным образом
        public void StartGame(int width, int height)
        {
            Random rnd = new Random();
            foreach (var player in Players)
            {
                player.SetPosition(
                    rnd.NextDouble() * width,
                    rnd.NextDouble() * height
                );
            }
        }

        // Добавляет игрока к команде если он не состоит в другой команде
        public void AddPlayer(Player player)
        {
            if (player.Team != null) return;
            Players.Add(player);
            player.Team = this;
        }

        // Получает текущее положение мяча для команды
        public (double, double) GetBallPosition()
        {
            return Game.GetBallPositionForTeam(this);
        }

        // Устанавливает скорость мяча для команды
        public void SetBallSpeed(double vx, double vy)
        {
            Game.SetBallSpeedForTeam(this, vx, vy);
        }

        // Находит игрока из команды находящегося ближе всего к мячу
        public Player GetClosestPlayerToBall()
        {
            Player closestPlayer = Players[0];
            double bestDistance = Double.MaxValue;
            foreach (var player in Players)
            {
                var distance = player.GetDistanceToBall();
                if (distance < bestDistance)
                {
                    closestPlayer = player;
                    bestDistance = distance;
                }
            }

            return closestPlayer;
        }

        // Ближайший игрок двигается в направлении мяча
        public void Move()
        {
            GetClosestPlayerToBall().MoveTowardsBall();
            Players.ForEach(player => player.Move());
        }
    }
}
