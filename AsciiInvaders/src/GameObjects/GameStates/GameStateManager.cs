using System.Collections.Generic;
using System.Threading;
using OpenTK;
using OpenTK.Input;
using SunshineConsole;

namespace AsciiInvaders.GameObjects.GameStates
{
    public class GameStateManager
    {
        private readonly Stack<GameState> _stackState;

        public readonly InputManager InputManager;
        public static ConsoleWindow Console;
        
        
        public GameStateManager()
        {
            Console = new ConsoleWindow(26, 70, "Ascii Invaders")
            {
                VSync = VSyncMode.On,
                TargetRenderFrequency = 60
            };

            _stackState=new Stack<GameState>();
            InputManager=new InputManager();
            InputManager.RegisterInput(Key.A);
            InputManager.RegisterInput(Key.D);
            InputManager.RegisterInput(Key.Space);
            InputManager.RegisterInput(Key.P);
        }
        
        public void PushState(GameState newState){
            _stackState.Push(newState);
        }

        public void PopState(){
            _stackState.Pop();
        }
        public void Update(){
            InputManager.Update();
            _stackState.Peek().Update();
        }
        public void Render(){
            Thread.Sleep((int)(Console.TargetRenderPeriod*1000));
            _stackState.Peek().Render();
        }

        public bool IsRunning(){
            return (_stackState.Peek().IsRunning()) && Console.WindowUpdate();
        }

    }
}