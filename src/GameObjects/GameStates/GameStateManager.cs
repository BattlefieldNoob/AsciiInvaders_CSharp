using System;
using System.Collections.Generic;
using System.Threading;
using TestWolfCurses;

namespace AsciiInvaders.GameObjects.GameStates
{
    public class GameStateManager
    {
        Stack<GameState> stackState;

        public InputManager _inputManager;
        
        
        public GameStateManager(){
            //initialization
            Console.Clear();
            
            stackState=new Stack<GameState>();
            _inputManager=new InputManager();
            
            _inputManager.RegisterInput(ConsoleKey.A);
            _inputManager.RegisterInput(ConsoleKey.D);
        }
        
        public void PushState(GameState newState){
            stackState.Push(newState);
        }

        public void PopState(){
            stackState.Pop();
        }
        public void Update(){
            stackState.Peek().Update();
            _inputManager.EventLoop();
        }
        public void Render(){
            Console.Clear();
            stackState.Peek().Render();
        }

        public bool IsRunning(){
            return (stackState.Peek().IsRunning());
        }

    }
}