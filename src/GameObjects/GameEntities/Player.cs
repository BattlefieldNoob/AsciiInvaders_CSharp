using System;

namespace AsciiInvaders.GameObjects.GameEntities
{
    public class Player:DrawableObject
    {
        public bool _canshoot { get; set; }

        public Player(){
            _canshoot=true;
        }

        public Player(int id,float x,float y):base(x, y, true,id){
            _canshoot=true;
            X=x;
            Y=y;
        }

        void CanShoot(bool canshoot){
            _canshoot=canshoot;
        }

        public override void Render(){
            Console.SetCursorPosition((int)X,(int)Y);
            Console.Write("<^>");
        }
    }
}