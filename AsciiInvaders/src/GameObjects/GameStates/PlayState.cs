using System;
using AsciiInvaders.GameObjects.GameEntities;
using OpenTK.Graphics;
using OpenTK.Input;
using SunshineConsole;

namespace AsciiInvaders.GameObjects.GameStates
{
    public class PlayState:GameState
    {
        private readonly GameStateManager _gsm;
        BattleField _gameField;
        private ConsoleWindow _console;


        public PlayState(GameStateManager gsm){
            _gsm=gsm;
            Init();
        }

        void Init(){
            _console = GameStateManager.Console;
            _gameField=new BattleField();
        }

        public override void Update(){

            if (_gsm.InputManager.GetInputState(Key.A).IsPressed)
            {
                _gameField.PlayerLeft();
            }else if (_gsm.InputManager.GetInputState(Key.D).IsPressed)
            {
                _gameField.PlayerRight();
            }
            
            if (_gsm.InputManager.GetInputState(Key.Space).IsPressedInThisFrame)
            {
                _gameField.ShootRocket();
            }
            
            _gameField.Update();
            
            if (_gsm.InputManager.GetInputState(Key.P).IsPressedInThisFrame)
            {
                Console.WriteLine("Pause");
                _gsm.PushState(new PauseState(_gsm,this));
            }
            
            
        }

        public override void Render()
        {
            ClearScreen();
            _gameField.Render();
        }

        private void ClearScreen()
        {
            for (var i = 0; i < _console.Cols; i++)
            {
                for (var j = 0; j < _console.Rows; j++)
                {
                    _console.Write(j, i, " ", Color4.Black);
                }
            }
        }

        public override bool IsRunning(){
            return (_gameField.IsRunning());
        }
   
    }
}