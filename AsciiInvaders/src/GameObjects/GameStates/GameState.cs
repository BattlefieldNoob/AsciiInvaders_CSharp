namespace AsciiInvaders.GameObjects.GameStates
{
    public class GameState:GameObject
    {
        public virtual void Init(){}
        public virtual bool IsRunning() => false;
        public virtual void Dispose(){}
    }
}