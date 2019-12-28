/*
 * Timer.cpp
 *
 *  Created on: 15/ott/2014
 *      Author: Antonio
 */

#include "Timer.hpp"

Timer::Timer(float seconds){
    startvalue=goal=seconds*1000;

}

void Timer::start(){

    started=true;
    prev = std::chrono::high_resolution_clock::now();

}

void Timer::update(){
    now = std::chrono::high_resolution_clock::now();
    if(started && !finished){
	int elapsed = std::chrono::duration_cast<std::chrono::milliseconds>(now-prev).count();
	if(elapsed>=1){
	    prev=now;
	    goal-=elapsed;
	    if(goal<=0){
		finished=true;
	    }
	}
    }
}

bool Timer::isFinished(){
    return (finished);
}

void Timer::restart(){
    finished=false;
    started=true;
    prev = std::chrono::high_resolution_clock::now();
    goal=startvalue;
}
