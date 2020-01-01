using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AsciiInvaders.GameObjects.GameStates;
using OpenTK.Graphics;

namespace AsciiInvaders.GameObjects.GameEntities
{
    public class BattleField : GameObject
    {
        private const int MaxRockets = 7;
        private const int MaxEnemies = 36;
        private const int EnemiesOnRow = 12;

        private readonly Player _player = new Player(0, 1, 22);

        private List<Rocket> _rockets = new List<Rocket>();
        private List<Enemy> _enemies = new List<Enemy>();

        private bool _running = true;

        private readonly Timer _enemyXMovement = new Timer(0.75f);
        private readonly Timer _enemyYMovement = new Timer(3f);
        private readonly Timer _shootCooldown = new Timer(0.3f);

        private int _shiftDirection = -1;

        public BattleField()
        {
            var tmp = 0;
            for (var i = 0; i < MaxEnemies; i++)
            {
                //init position of Enemy
                if (i % EnemiesOnRow == 0)
                    tmp++;
                var x = ((i * 5) + 4) - ((5 * (tmp - 1)) * EnemiesOnRow);
                _enemies.Add(new Enemy(i, x + (tmp % 2 == 0 ? 2 : 0), tmp + 1));
            }

            _shootCooldown.Start();
            _enemyXMovement.Start();
            _enemyYMovement.Start();
        }


        public override void Render()
        {
            _player.Render();
            foreach (var missile in _rockets)
            {
                missile.Render();
            }

            foreach (var enemy in _enemies)
            {
                enemy.Render();
            }
        }

        public override void Update()
        {
            _enemyXMovement.Update();
            _enemyYMovement.Update();
            _shootCooldown.Update();
            foreach (var missile in _rockets)
            {
                missile.Update();
            }

            if (_shootCooldown.IsFinished())
            {
                _player.Canshoot = true;
            }

            if (_enemyXMovement.IsFinished())
            {
                _enemyXMovement.Restart();
                _shiftDirection *= -1;  
                for (var index = 0; index < _enemies.Count; index++)
                {
                    var enemy = _enemies[index];
                    if((index/EnemiesOnRow)%2==0)
                        enemy.X += 2 * _shiftDirection;
                    else
                        enemy.X -= 2 * _shiftDirection;
                }
            }

            if (_enemyYMovement.IsFinished())
            {
                _enemyYMovement.Restart();
                foreach (var enemy in _enemies)
                {
                    enemy.Y += 1;
                }

                if (_enemies.Last().Y == _player.Y)
                    GameOverScreen();
            }

            foreach (var enemy in _enemies)
            {
                foreach (var rocket in _rockets)
                {
                    if (rocket.Y == enemy.Y)
                    {
                        //check collision between Rocket and enemy

                        if (rocket.X >= enemy.X &&
                            rocket.X <= enemy.X + 2)
                        {
                            enemy.Visible = false;
                            rocket.Visible = false;
                        }
                    }
                }
            }

            var destroyedEnemies = _enemies.Where(enemy => !enemy.Visible);
            _enemies = _enemies.Except(destroyedEnemies).ToList();


            var destroyedRockets = _rockets.Where(rocket => rocket.Y <= 0 || !rocket.Visible);
            _rockets = _rockets.Except(destroyedRockets).ToList();
        }

        public void ShootRocket()
        {
            if (!_player.Canshoot || _rockets.Count >= MaxRockets) return;
            
            _rockets.Add(new Rocket(0, _player.X + 1, _player.Y - 1));
            _player.Canshoot = false;
            _shootCooldown.Restart();
        }

        public void PlayerLeft()
        {
            if (_player.X > 0)
            {
                _player.X -= 1;
            }
        }

        public void PlayerRight()
        {
            if(_player.X+3<70)
                _player.X += 1;
        }

        private void GameOverScreen()
        {
            GameStateManager.Console.Write(20,30,"GAME OVER!",Color4.White);
            Thread.Sleep(4000);
            _running = false;
        }

        public bool IsRunning()
        {
            return (_running);
        }
    }
}