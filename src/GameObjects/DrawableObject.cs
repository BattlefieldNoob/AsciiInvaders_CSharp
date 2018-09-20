namespace AsciiInvaders.GameObjects
{
    public class DrawableObject : GameObject
    {
        public float X { get; set; }
        public float Y { get; set; }
        public bool visible { get; set; }
        public int id { get; private set; }
       
        protected DrawableObject()
        {
        }

        protected DrawableObject(float x, float y, bool visible, int id)
        {
            this.X = x;
            this.Y = y;
            this.visible = visible;
            this.id = id;
        }
        
    }
}