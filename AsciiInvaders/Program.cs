using AsciiInvaders.GameObjects.GameStates;

namespace AsciiInvaders
{
    class Program
    {

        private static GameStateManager _gsm;

        private static void Main()
        {
            _gsm = new GameStateManager();
            _gsm.PushState(new PlayState(_gsm));
            do
            {
                _gsm.Update();
                _gsm.Render();
            } while (_gsm.IsRunning());
        }
    }
}