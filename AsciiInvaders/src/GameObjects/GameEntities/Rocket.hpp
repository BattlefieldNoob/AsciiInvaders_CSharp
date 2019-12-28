/*
 * Rocket.h
 *
 *  Created on: 29/set/2014
 *      Author: Antonio
 */

#ifndef GAMEOBJECTS_ROCKET_H_
#define GAMEOBJECTS_ROCKET_H_

#include "../DrawableObject.hpp"

class Rocket: public DrawableObject{
public:
    Rocket();
    Rocket(int,float,float,bool);
    void update();
    void render();
};

#endif /* GAMEOBJECTS_ROCKET_H_ */
