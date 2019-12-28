using System.Drawing;
using AsciiInvaders.GameObjects.GameStates;
using OpenTK.Graphics;

namespace AsciiInvaders.GameObjects.GameEntities
{
    public class Rocket:DrawableObject
    {
        private readonly Timer _movementTimer=new Timer(0.125f);

        public Rocket(int id, int x, int y) : base(x, y, true, id)
        {
            _movementTimer.Start();
        }
        
        public override void Update()
        {
            _movementTimer.Update();
            if (!_movementTimer.IsFinished()) return;
            
            Y -= 1;
            _movementTimer.Restart();
        }

        public override void Render()
        {
            var console = GameStateManager.Console;
            if(visible)
                console.Write(Y,X,'^',Color4.White);
        }
    }
}