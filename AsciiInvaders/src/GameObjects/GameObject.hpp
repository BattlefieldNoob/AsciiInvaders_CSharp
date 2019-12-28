/*
 * GameObject.h
 *
 *  Created on: 30/set/2014
 *      Author: Antonio
 */

#ifndef GAMEOBJECT_H_
#define GAMEOBJECT_H_

#include <curses.h>
#include <cstdio>

class GameObject{
public:
    GameObject();
    virtual void update()=0;
    virtual void render()=0;
    virtual ~GameObject();
};

#endif /* GAMEOBJECT_H_ */
