using System;

namespace AsciiInvaders
{
    public class Timer
    {
        float _goal,_startvalue;
        bool _finished=false,_started=false;
        
        
        DateTime _prev, _now;


        public Timer(float seconds){
            _startvalue=_goal=seconds*1000;

        }

        public void Start(){

            _started=true;
            _prev = DateTime.Now;

        }

        public void Update(){
            _now = DateTime.Now;
            if(_started && !_finished)
            {
                int elapsed = (_now - _prev).Milliseconds;
                if(elapsed>=1){
                    _prev=_now;
                    _goal-=elapsed;
                    if(_goal<=0){
                        _finished=true;
                    }
                }
            }
        }

        public bool IsFinished(){
            return (_finished);
        }

        public void Restart(){
            _finished=false;
            _started=true;
            _prev = DateTime.Now;
            _goal=_startvalue;
        }
    }
}