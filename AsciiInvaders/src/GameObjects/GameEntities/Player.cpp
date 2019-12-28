/*
 * Player.cpp
 *
 *  Created on: 15/ott/2014
 *      Author: Antonio
 */

#include "Player.hpp"


Player::Player():DrawableObject(){
    canshoot=true;
}

Player::Player(int id,float x,float y):DrawableObject(id,x,y,true){
    canshoot=true;
    this->X(x);
    this->Y(y);
}

void Player::canShoot(bool canshoot){
    this->canshoot=canshoot;
}

bool Player::canShoot(){
    return (canshoot);
}

void Player::update(){

}

void Player::render(){
    mvprintw(Y(),X(),"<^>");
}
