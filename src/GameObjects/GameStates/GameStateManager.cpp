/*
 * GameStateManager.cpp
 *
 *  Created on: 15/ott/2014
 *      Author: Antonio
 */

#include "GameStateManager.hpp"
#include <curses.h>



GameStateManager::GameStateManager(){
    //initializzation
    initscr();
    cbreak();
    noecho();
    raw();
    intrflush( stdscr, FALSE );
    keypad( stdscr, TRUE );
    curs_set(0);
}
GameStateManager::~GameStateManager(){
    stackState.top()->dispose();
    delete &stackState;
    endwin();
}
void GameStateManager::pushState(GameState* newState){
    stackState.push(newState);
}

void GameStateManager::popState(){
    stackState.pop();
}
void GameStateManager::update(){
    stackState.top()->update();
}
void GameStateManager::render(){
    clear();
    stackState.top()->render();
    refresh();
}

bool GameStateManager::isRunning(){
    return (stackState.top()->isRunning());
}
