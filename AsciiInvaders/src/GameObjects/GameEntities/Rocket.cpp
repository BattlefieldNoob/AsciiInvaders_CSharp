/*
 * Rocket.cpp
 *
 *  Created on: 15/ott/2014
 *      Author: Antonio
 */

#include "Rocket.hpp"

Rocket::Rocket():DrawableObject(){}

Rocket::Rocket(int id,float x,float y,bool visible):DrawableObject(id,x,y,visible){
}

void Rocket::update(){
    Y((float)(Y()-0.03));
}

void Rocket::render(){
    if(isVisible())
	mvprintw(Y(),X(),"^");
}
