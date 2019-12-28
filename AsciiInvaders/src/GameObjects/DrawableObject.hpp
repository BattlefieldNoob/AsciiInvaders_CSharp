/*
 * GameObject.h
 *
 *  Created on: 29/set/2014
 *      Author: Antonio
 */

#ifndef DRAWABLEOBJECT_H_
#define DRAWABLEOBJECT_H_

#include "GameObject.hpp"
#include "curses.h"

class DrawableObject:public GameObject{
    float x,y;
    bool visible;
    int id;
public:
    float const X();
    float const Y();
    float const Id();
    bool isVisible();
    void setVisible(bool value);
    void update()=0;
    void render()=0;
    void X(float x);
    void Y(float y);

protected:
    DrawableObject();
    DrawableObject(int id,float x,float y,bool visible);
};

#endif /* DRAWABLE_H_ */
