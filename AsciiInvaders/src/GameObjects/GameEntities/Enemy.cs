using AsciiInvaders.GameObjects.GameStates;
using OpenTK.Graphics;

namespace AsciiInvaders.GameObjects.GameEntities
{
    public class Enemy:DrawableObject
    {
        public Enemy(int id, int x, int y) : base(x, y,true,id)
        {
            
        }

        public override void Render()
        {
            var console = GameStateManager.Console;
            if(Visible)
                console.Write(Y,X,"(#)",Color4.White);
        }
    }
}