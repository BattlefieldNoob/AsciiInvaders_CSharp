namespace AsciiInvaders.GameObjects.GameStates
{
    public class GameState:GameObject
    {
        public virtual bool IsRunning() => false;
        public virtual void Dispose(){}
    }
}