using AsciiInvaders.GameObjects.GameStates;
using OpenTK.Graphics;

namespace AsciiInvaders.GameObjects.GameEntities
{
    public class Player:DrawableObject
    {
        public bool Canshoot { get; set; }

        public Player(int id,int x,int y):base(x, y, true,id){
            Canshoot=true;
            X=x;
            Y=y;
        }

        public override void Render()
        {
            //Console.WriteLine("render");
            var console = GameStateManager.Console;
            if(Visible)
                console.Write(Y,X,"<^>",Color4.White);
        }
    }
}