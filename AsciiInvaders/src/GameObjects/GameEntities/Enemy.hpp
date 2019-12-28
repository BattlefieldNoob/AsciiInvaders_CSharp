/*
 * Enemy.h
 *
 *  Created on: 29/set/2014
 *      Author: Antonio
 */

#ifndef GAMEOBJECTS_ENEMY_H_
#define GAMEOBJECTS_ENEMY_H_

#include "../DrawableObject.hpp"


class Enemy: public DrawableObject{
public:
    Enemy();
    Enemy(int,float,float,bool);
    void update();
    void render();

};


#endif /* GAMEOBJECTS_ENEMY_H_ */
