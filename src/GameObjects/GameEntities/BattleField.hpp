/*
 * BattleField.h
 *
 *  Created on: 30/set/2014
 *      Author: Antonio
 */

#ifndef GAMEOBJECTS_BATTLEFIELD_H_
#define GAMEOBJECTS_BATTLEFIELD_H_
#define MAX_MISSILI 7
#define MAX_NEMICI 36
#define NEMICI_RIGA 12

#include <vector>

#include "../GameObject.hpp"
#include "Player.hpp"
#include "Enemy.hpp"
#include "Rocket.hpp"
#include "../Timer.hpp"


using namespace std;

class BattleField:public GameObject{
    Player *player=new Player(0,1,20);
    vector<Rocket*> rockets;
    vector<Enemy*> enemys;
    bool running=true;
    static BattleField* instance;
    BattleField();
public:
    ~BattleField();
    static BattleField* getInstance();
    void update();
    void render();
    void controller();
    void shootRocket();
    void playerLeft();
    void playerRight();
    int GameOverScreen();
    bool isRunning();
};

#endif /* GAMEOBJECTS_BATTLEFIELD_H_ */
