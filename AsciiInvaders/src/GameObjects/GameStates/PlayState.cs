using System;
using AsciiInvaders.GameObjects.GameEntities;
using OpenTK.Graphics;
using OpenTK.Input;
using SunshineConsole;

namespace AsciiInvaders.GameObjects.GameStates
{
    public class PlayState:GameState
    {
        private GameStateManager gsm;
        BattleField gameField;
        private ConsoleWindow _console;


        public PlayState(GameStateManager gsm){
            this.gsm=gsm;
            Init();
        }

        void Init(){
            _console = GameStateManager.Console;
            gameField=new BattleField();
        }

        public override void Update(){

            if (gsm._inputManager.GetInputState(Key.A).isPressed)
            {
                gameField.PlayerLeft();
            }else if (gsm._inputManager.GetInputState(Key.D).isPressed)
            {
                gameField.PlayerRight();
            }else if (gsm._inputManager.GetInputState(Key.Space).isPressedInThisFrame)
            {
                gameField.ShootRocket();
            }
/*
                    case 'p':
                        gsm->pushState(new PauseState(gsm));
                        break;
                }
            }*/
            gameField.Update();
        }

        public override void Render()
        {
            ClearScreen();
            gameField.Render();
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
            return (gameField.IsRunning());
        }
   
    }
}