using System;
using AsciiInvaders.GameObjects.GameStates;
using OpenTK.Graphics;
using SunshineConsole;

namespace AsciiInvaders.GameObjects.GameEntities
{
    public class Player:DrawableObject
    {
        public bool _canshoot { get; set; }

        public Player(int id,int x,int y):base(x, y, true,id){
            _canshoot=true;
            X=x;
            Y=y;
        }

        void CanShoot(bool canshoot){
            _canshoot=canshoot;
        }

        public override void Render()
        {
            //Console.WriteLine("render");
            var console = GameStateManager.Console;
            if(visible)
                console.Write((int)Y,(int)X,"<^>",Color4.White);
        }
    }
}