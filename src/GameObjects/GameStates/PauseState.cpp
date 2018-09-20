/*
 * PauseState.cpp
 *
 *  Created on: 15/ott/2014
 *      Author: Antonio
 */


#include "PauseState.hpp"

PauseState::PauseState(GameStateManager* gsm):GameState(){
    this->gsm=gsm;
    init();
}

void PauseState::init(){
    gameField=BattleField::getInstance();
}

void PauseState::update(){
    if(kbhit() && getch()=='p'){
	gsm->popState();
    }};
void PauseState::render(){
    gameField->render();
    mvprintw(22,35,"PAUSE");
}

bool PauseState::isRunning(){
    return (gameField->isRunning());
}

void PauseState::dispose(){
    delete gameField;
}


