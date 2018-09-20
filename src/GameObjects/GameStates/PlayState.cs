using System;
using AsciiInvaders.GameObjects.GameEntities;

namespace AsciiInvaders.GameObjects.GameStates
{
    public class PlayState:GameState
    {
        private GameStateManager gsm;
        BattleField gameField;

        
        public PlayState(GameStateManager gsm){
            this.gsm=gsm;
            Init();
        }

        void Init(){
            gameField=new BattleField();
        }

        public override void Update(){

            if (gsm._inputManager.GetInputState(ConsoleKey.A).isPressedInThisFrame)
            {
                gameField.PlayerLeft();
            }else if (gsm._inputManager.GetInputState(ConsoleKey.D).isPressed)
            {
                gameField.PlayerRight();
            }
/*
            break;
                    case ' ':
                        gameField->shootRocket();
                        break;
                    case 'p':
                        gsm->pushState(new PauseState(gsm));
                        break;
                }
            }*/
            gameField.Update();
        }

        public override void Render(){
            gameField.Render();
        }

        public override bool IsRunning(){
            return (gameField.IsRunning());
        }
   
    }
}