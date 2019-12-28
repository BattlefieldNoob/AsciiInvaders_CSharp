/*
 * Timer.hpp
 *
 *  Created on: 06/ott/2014
 *      Author: Antonio
 */

#ifndef GAMEOBJECTS_TIMER_HPP_
#define GAMEOBJECTS_TIMER_HPP_

#include <chrono>
#include <iostream>
#include <ctime>


using namespace std::chrono;

class Timer{
	float goal,startvalue;
	bool finished=false,started=false;
	std::chrono::time_point<std::chrono::high_resolution_clock> prev, now;
public:
	Timer(float seconds);
	void start();
	void update();
	bool isFinished();
	void restart();
};

#endif /* GAMEOBJECTS_TIMER_HPP_ */
