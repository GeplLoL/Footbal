using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalgpall
{
    using System;
    using System.Drawing;

        public class Player
        {
            public string Name { get; }
            public double X { get; private set; }
            public double Y { get; private set; }
            private double _vx, _vy;
            public Team? Team { get; set; } = null;
            private const double MaxSpeed = 5;
            private const double MaxKickSpeed = 25;
            private const double BallKickDistance = 10;
            private Random _random = new Random();
            public Player(string name)
            {
                Name = name;
            }
        public Player(string name, double x, double y, Team team)
            {
                Name = name;
                X = x;
                Y = y;
                Team = team;
            }

            // Устанавливает позицию игрока на поле
            public void SetPosition(double x, double y)
            {
                X = x;
                Y = y;
            }

            // Получает позицию игрока на поле относительно его команды
            public (double, double) GetAbsolutePosition()
            {
                return Team!.Game.GetPositionForTeam(Team, X, Y);
            }

            // Вычисляет расстояние от игрока до мяча
            public double GetDistanceToBall()
            {
                var ballPosition = Team!.GetBallPosition();
                var dx = ballPosition.Item1 - X;
                var dy = ballPosition.Item2 - Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            // Двигает игрока в направлении мяча с максимальной скоростью
            public void MoveTowardsBall()
            {
                var ballPosition = Team!.GetBallPosition();
                var dx = ballPosition.Item1 - X;
                var dy = ballPosition.Item2 - Y;
                var distanceToBall = Math.Sqrt(dx * dx + dy * dy);

                var ratio = distanceToBall / MaxSpeed;

                // Устанавливаем скорости чтобы двигаться в направлении мяча
                _vx = dx / ratio;
                _vy = dy / ratio;
            }

            // Двигает игрока на поле
            public void Move()
            {
                if (Team.GetClosestPlayerToBall() != this)
                {
                    // Если игрок не ближайший к мячу останавливаем его
                    _vx = 0;
                    _vy = 0;
                }

                if (GetDistanceToBall() < BallKickDistance)
                {
                    // Если игрок находится близко к мячу устанавливаем скорость мяча
                    Team.SetBallSpeed(MaxKickSpeed * _random.NextDouble(), MaxKickSpeed * (_random.NextDouble() - 0.5));
                }

                // Вычисляем новые координаты игрока на основе скорости
                var newX = X + _vx;
                var newY = Y + _vy;

                // Получаем координаты игрока относительно его команды
                var newAbsolutePosition = Team.Game.GetPositionForTeam(Team, newX, newY);

                if (Team.Game.Stadium.IsIn(newAbsolutePosition.Item1, newAbsolutePosition.Item2))
                {
                    // Если новые координаты находятся в пределах поле перемещаем игрока
                    X = newX;
                    Y = newY;
                }
                else
                {
                    // Если игрок выходит за пределы пол останавливаем его
                    _vx = _vy = 0;
                }
            }
        }
}
