using System;
using System.Collections.Generic;
using System.Threading;
using OpenTK;
using OpenTK.Input;
using SunshineConsole;
using InputManager = TestWolfCurses.InputManager;

namespace AsciiInvaders.GameObjects.GameStates
{
    public class GameStateManager
    {
        Stack<GameState> stackState;

        public InputManager _inputManager;
        public static ConsoleWindow Console;
        
        
        public GameStateManager()
        {
            Console = new ConsoleWindow(32, 80, "Ascii Invaders")
            {
                VSync = VSyncMode.On,
                TargetRenderFrequency = 60
            };

            stackState=new Stack<GameState>();
            _inputManager=new InputManager();
            _inputManager.RegisterInput(Key.A);
            _inputManager.RegisterInput(Key.D);
            _inputManager.RegisterInput(Key.Space);
        }
        
        public void PushState(GameState newState){
            stackState.Push(newState);
        }

        public void PopState(){
            stackState.Pop();
        }
        public void Update(){
            stackState.Peek().Update();
        }
        public void Render(){
            Thread.Sleep((int)(Console.TargetRenderPeriod*1000));
            stackState.Peek().Render();
        }

        public bool IsRunning(){
            return (stackState.Peek().IsRunning()) && Console.WindowUpdate();
        }

    }
}