using System.Collections.Generic;
using System.Threading;

namespace AsciiInvaders.GameObjects.GameEntities
{
    public class BattleField : GameObject
    {
        private const int MAX_MISSILI = 7;
        private const int MAX_NEMICI = 36;
        private const int NEMICI_RIGA = 12;

        Player player = new Player(0, 1, 20);

        //List<Rocket*> rockets;
        //   List<Enemy*> enemys;
        bool running = true;
        //    static BattleField* instance;

        Timer enemyMoviments = new Timer(1.0f), shootEnabler = new Timer(0.3f);


        public BattleField()
        {
            int tmp = 0, X = 0;
            /*  for (int i = 0; i < MAX_NEMICI; i++) {//init position of Enemy
                  if (i % NEMICI_RIGA == 0)
                      tmp++;
                  X = ((i * 5) + 4) - ((5 * (tmp - 1)) * NEMICI_RIGA);//Calculate the X position Of Enemy
                  enemys.push_back(new Enemy(i, X + (tmp % 2 == 0 ? 2 : 0), tmp + 1, true));
              }*/
            shootEnabler.Start();
            enemyMoviments.Start();
        }


        public override void Render()
        {
            player.Render();
/*    for (auto missile:rockets) {
        missile->render();
    }
    for (auto enemy:enemys) {
        enemy->render();
    }*/
        }

        public override void Update()
        {
            // UPDATE          UPDATE            UPDATE
            bool GameOver = false;
            int shiftDirection = -1;
            //   enemyMoviments->update();
            //   shootEnabler->update();
            /*  for (auto missile:rockets) {
                  missile->update();
              }*/
            if (GameOver)
            {
                GameOverScreen();
            }
            else
            {
                if (shootEnabler.IsFinished())
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
          
                  rockets.erase(remove_if(rockets.begin(), rockets.end(), [](Rocket *r) {
                      return r->Y() < 0 || !r->isVisible();
                  }),rockets.end());
          
                  enemys.erase(remove_if(enemys.begin(), enemys.end(), [](Enemy* e) {
                      return !e->isVisible();
                  }),enemys.end());
          */
            }
        }

        void ShootRocket()
        {
            if (player._canshoot /*&& rockets.size() < MAX_MISSILI*/)
            {
                //   rockets.push_back(new Rocket(0, (int) player->X() + 1, (int) player->Y(), true));
                player._canshoot = false;
                shootEnabler.Restart();
            }
        }

        public void PlayerLeft()
        {
            if (player.X > 1)
            {
                player.X = player.X - 0.6f;
            }
        }

        public void PlayerRight()
        {
            player.X = player.X + 0.6f;
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