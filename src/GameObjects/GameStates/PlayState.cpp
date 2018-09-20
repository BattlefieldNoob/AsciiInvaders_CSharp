/*
 * PauseState.cpp
 *
 *  Created on: 15/ott/2014
 *      Author: Antonio
 */


#include "PlayState.hpp"
#include "PauseState.hpp"
#include "ncurses.h"

PlayState::PlayState(GameStateManager* gsm):GameState(){
    this->gsm=gsm;
    init();
}

void PlayState::init(){
    gameField=BattleField::getInstance();
}

void PlayState::update(){
    if(kbhit()) {
        switch (getch()) {
            case 'd':
                gameField->playerRight();
                break;
            case 'a':
                gameField->playerLeft();
                break;
            case ' ':
                gameField->shootRocket();
                break;
            case 'p':
                gsm->pushState(new PauseState(gsm));
                break;
        }
    }
    gameField->update();
};

void PlayState::render(){
    gameField->render();
}

bool PlayState::isRunning(){
    return (gameField->isRunning());
}

void PlayState::dispose(){
    delete gameField;
}
