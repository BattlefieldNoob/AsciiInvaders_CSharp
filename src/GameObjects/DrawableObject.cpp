/*
 * DrawableObject.cpp
 *
 *  Created on: 15/ott/2014
 *      Author: Antonio
 */

#include "DrawableObject.hpp"

DrawableObject::DrawableObject():GameObject(){
    x=0;
    y=0;
    id=0;
    visible=false;
}

DrawableObject::DrawableObject(int id,float x,float y,bool visible):GameObject(){
    this->x=x;
    this->y=y;
    this->visible=visible;
    this->id=id;
}

float const DrawableObject::X(){
    return (x);
}

float const DrawableObject::Y(){
    return (y);
}

float const DrawableObject::Id(){
    return (id);
}

bool DrawableObject::isVisible(){
    return (this->visible);
}

void DrawableObject::setVisible(bool value){
    this->visible=value;
}

void DrawableObject::X(float x) {
    this->x=x;
}

void DrawableObject::Y(float y) {
    this->y=y;
}


