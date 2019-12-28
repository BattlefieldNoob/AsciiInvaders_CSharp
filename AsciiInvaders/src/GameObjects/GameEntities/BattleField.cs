using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AsciiInvaders.GameObjects.GameEntities
{
    public class BattleField : GameObject
    {
        private const int MAX_MISSILI = 7;
        private const int MAX_NEMICI = 36;
        private const int NEMICI_RIGA = 12;

        Player player = new Player(0, 1, 24);

        List<Rocket> rockets=new List<Rocket>();
        //   List<Enemy*> enemys;
        bool running = true;
        //    static BattleField* instance;

        Timer enemyMoviments = new Timer(1.0f), shootCooldown = new Timer(0.3f);


        public BattleField()
        {
            int tmp = 0, X = 0;
            /*  for (int i = 0; i < MAX_NEMICI; i++) {//init position of Enemy
                  if (i % NEMICI_RIGA == 0)
                      tmp++;
                  X = ((i * 5) + 4) - ((5 * (tmp - 1)) * NEMICI_RIGA);//Calculate the X position Of Enemy
                  enemys.push_back(new Enemy(i, X + (tmp % 2 == 0 ? 2 : 0), tmp + 1, true));
              }*/
            shootCooldown.Start();
            enemyMoviments.Start();
        }


        public override void Render()
        {
            player.Render();
            foreach (var missile in rockets) {
                missile.Render();
            }
    /*for (auto enemy:enemys) {
        enemy->render();
    }*/
        }

        public override void Update()
        {
            // UPDATE          UPDATE            UPDATE
            bool GameOver = false;
            int shiftDirection = -1;
            //   enemyMoviments->update();
            shootCooldown.Update();
            foreach (var missile in rockets) {
                missile.Update();
            }
            if (GameOver)
            {
                GameOverScreen();
            }
            else
            {
                if (shootCooldown.IsFinished())
                {
                    player._canshoot = true;
                }

                /*  std::vector<Enemy *>::iterator EnemyIt;
                  std::vector<Rocket *>::iterator RocketIt;
          
                  if (enemyMoviments->isFinished()) {
                      shiftDirection *= -1;
                      for (EnemyIt = enemys.begin(); EnemyIt < enemys.end(); EnemyIt++) {
                          (*EnemyIt)->Y((*EnemyIt)->Y() + 0.1);
          
                          if ((*EnemyIt)->Id() == NEMICI_RIGA || (*EnemyIt)->Id() == NEMICI_RIGA * 2)
          
                              shiftDirection *= -1;
          
                          if ((int) player->Y() == (int) (*EnemyIt)->Y()) {
                              GameOver = true;
                              break;//Game Over
                          }
          
                          (*EnemyIt)->X((*EnemyIt)->X() + 2 * shiftDirection);
          
                          enemyMoviments->restart();
                      }
                  }
          
                  for (EnemyIt = enemys.begin(); EnemyIt < enemys.end(); EnemyIt++) {
                      for (RocketIt = rockets.begin(); RocketIt < rockets.end(); RocketIt++) {
          
                          if ((int) (*RocketIt)->Y() == (int) (*EnemyIt)->Y()) {//check collision between Rocket and enemy
          
                              if (((int) (*RocketIt)->X()) >= ((int) (*EnemyIt)->X()) &&
                                  ((int) (*RocketIt)->X()) <= ((int) (*EnemyIt)->X()) + 2) {
          
                                  (*EnemyIt)->setVisible(false);
                                 // enemys.erase(EnemyIt);//Delete Enemy
                                  (*RocketIt)->setVisible(false);
                                  //rockets.erase(RocketIt);//Delete Rocket
                              }
                          }
                      }
                  }
          
                  
          
                  enemys.erase(remove_if(enemys.begin(), enemys.end(), [](Enemy* e) {
                      return !e->isVisible();
                  }),enemys.end());
          */
                var destroyed = rockets.Where(rocket => rocket.Y <= 0 || !rocket.visible);
                rockets = rockets.Except(destroyed).ToList();
            }
        }

        public void ShootRocket()
        {
            if (player._canshoot && rockets.Count < MAX_MISSILI)
            {
                rockets.Add(new Rocket(0,player.X+1,player.Y-1));
                player._canshoot = false;
                shootCooldown.Restart();
            }
        }

        public void PlayerLeft()
        {
            if (player.X > 1)
            {
                player.X = player.X - 1;
            }
        }

        public void PlayerRight()
        {
            player.X = player.X + 1;
        }

        int GameOverScreen()
        {
            Thread.Sleep(4000);
            running = false;
            return (1);
        }

        public bool IsRunning()
        {
            return (running);
        }
    }
}