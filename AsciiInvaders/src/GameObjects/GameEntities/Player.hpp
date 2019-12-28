/*
 * Player.h
 *
 *  Created on: 29/set/2014
 *      Author: Antonio
 */


#ifndef PLAYER_H_
#define PLAYER_H_

#include "../DrawableObject.hpp"

class Player: public DrawableObject{
    bool canshoot;
public:
    Player();
    Player(int,float,float);
    bool canShoot();
    void canShoot(bool canshoot);
    void update();
    void render();
};

#endif /* PLAYER_H_ */
