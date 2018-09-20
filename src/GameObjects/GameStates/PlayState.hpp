/*
 * PlayState.h
 *
 *  Created on: 01/ott/2014
 *      Author: Antonio
 */



#ifndef GAMEOBJECTS_GAMESTATES_PLAYSTATE_HPP_
#define GAMEOBJECTS_GAMESTATES_PLAYSTATE_HPP_

#include "GameState.hpp"
#include "../GameEntities/BattleField.hpp"
#include "GameStateManager.hpp"

class PlayState:public GameState{
	BattleField* gameField;
	GameStateManager* gsm;
	void init();
public:
	PlayState(GameStateManager* gsm);
	void update();
	void render();
	bool isRunning();
	void dispose();
    int kbhit(void)    /* comment */
    {
        int ch, r;

        // turn off getch() blocking and echo
        nodelay(stdscr, TRUE);
        noecho();

        // check for input
        ch = getch();
        if( ch == ERR)      // no input
            r = FALSE;
        else                // input
        {
            r = TRUE;
            ungetch(ch);
        }

        // restore block and echo
        echo();
        nodelay(stdscr, FALSE);
        return(r);
    }
};



#endif /* GAMEOBJECTS_GAMESTATES_PLAYSTATE_HPP_ */
