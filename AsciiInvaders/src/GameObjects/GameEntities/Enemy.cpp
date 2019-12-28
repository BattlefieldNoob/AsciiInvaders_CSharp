/*
 * Enemy.h
 *
 *  Created on: 29/set/2014
 *      Author: Antonio
 */

#include "Enemy.hpp"

Enemy::Enemy(): DrawableObject() {
}

Enemy::Enemy(int id, float x, float y, bool visible): DrawableObject(id, x, y, visible) {
}

void Enemy::update() {
}

void Enemy::render() {
    if(isVisible())
        mvprintw(Y(),X(),"(#)");
}