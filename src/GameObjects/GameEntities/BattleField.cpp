/*
 * BattleField.cpp
 *
 *  Created on: 30/set/2014
 *      Author: Antonio
 */

#include "BattleField.hpp"
#include <curses.h>
#include <algorithm> // for remove_if
#include <zconf.h>

Timer *enemyMoviments = new Timer(1.0f), *shootEnabler = new Timer(0.3f);


BattleField *BattleField::instance = nullptr;

BattleField::BattleField() {
    int tmp = 0, X = 0;
    for (int i = 0; i < MAX_NEMICI; i++) {//init position of Enemy
        if (i % NEMICI_RIGA == 0)
            tmp++;
        X = ((i * 5) + 4) - ((5 * (tmp - 1)) * NEMICI_RIGA);//Calculate the X position Of Enemy
        enemys.push_back(new Enemy(i, X + (tmp % 2 == 0 ? 2 : 0), tmp + 1, true));
    }
    shootEnabler->start();
    enemyMoviments->start();
}

BattleField::~BattleField() {
    delete &player;
    delete &rockets;
    delete &enemys;
}


BattleField *BattleField::getInstance() {
    if (instance == nullptr)
        instance = new BattleField();
    return (instance);
}


void BattleField::render() {
    player->render();
    for (auto missile:rockets) {
        missile->render();
    }
    for (auto enemy:enemys) {
        enemy->render();
    }
}

void BattleField::update() {
    // UPDATE          UPDATE            UPDATE
    static bool GameOver = false;
    static int shiftDirection = -1;
    enemyMoviments->update();
    shootEnabler->update();
    for (auto missile:rockets) {
        missile->update();
    }
    if (GameOver) {
        GameOverScreen();
    } else {
        if (shootEnabler->isFinished()) {
            player->canShoot(true);
        }
        std::vector<Enemy *>::iterator EnemyIt;
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

    }
}

void BattleField::shootRocket() {
    if (player->canShoot() && rockets.size() < MAX_MISSILI) {
        rockets.push_back(new Rocket(0, (int) player->X() + 1, (int) player->Y(), true));
        player->canShoot(false);
        shootEnabler->restart();
    }
};

void BattleField::playerLeft() {
    if (player->X() > 1) {
        player->X(player->X() - 0.6);
    }
};

void BattleField::playerRight() {
    player->X(player->X() + 0.6);
}

int BattleField::GameOverScreen() {
    sleep(2000);
    sleep(2000);
    system("pause");
    running = false;
    return (1);
}

bool BattleField::isRunning() {
    return (running);
}

