/*
 * GameState.h
 *
 *  Created on: 01/ott/2014
 *      Author: Antonio
 */


#ifndef GAMEOBJECTS_GAMESTATE_H_
#define GAMEOBJECTS_GAMESTATE_H_

#include "../GameObject.hpp"

class GameState:public GameObject{
protected:
    GameState();
    ~GameState();
public:
    virtual void init()=0;
    void update()=0;
    void render()=0;
    virtual bool isRunning()=0;
    virtual void dispose()=0;
};

#endif /* GAMEOBJECTS_GAMESTATE_H_ */
