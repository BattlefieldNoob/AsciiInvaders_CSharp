namespace AsciiInvaders.GameObjects
{
    public class DrawableObject : GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Visible { get; set; }
        public int Id { get; private set; }
       
        protected DrawableObject()
        {
        }

        protected DrawableObject(int x, int y, bool visible, int id)
        {
            this.X = x;
            this.Y = y;
            this.Visible = visible;
            this.Id = id;
        }
        
    }
}