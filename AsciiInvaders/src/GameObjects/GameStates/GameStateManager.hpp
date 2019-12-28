/*
 * GameStateManager.h
 *
 *  Created on: 01/ott/2014
 *      Author: Antonio
 */



#ifndef GAMEOBJECTS_GAMESTATEMANAGER_H_
#define GAMEOBJECTS_GAMESTATEMANAGER_H_

#include "GameState.hpp"
#include <stack>

class GameStateManager{
private:
	std::stack<GameState*> stackState;
	int PLAY=1;
	int PAUSE=2;
public:
	GameStateManager();
	~GameStateManager();
	void pushState(GameState* newState);
	void popState();
	void update();
	void render();
	bool isRunning();
};


#endif /* GAMEOBJECTS_GAMESTATEMANAGER_H_ */
