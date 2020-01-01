using OpenTK.Graphics;
using OpenTK.Input;
using SunshineConsole;

namespace AsciiInvaders.GameObjects.GameStates
{
    public class PauseState:GameState
    {
        private readonly GameStateManager _gsm;
        private readonly GameState _battleField;
        private readonly ConsoleWindow _consoleWindow;
        private readonly Timer _blinkTimer=new Timer(0.5f);

        private bool _renderText = true;
        public PauseState(GameStateManager gsm,GameState gameState){
            _gsm=gsm;
            _battleField = gameState;
            _consoleWindow = GameStateManager.Console;
            _blinkTimer.Start();
        }

        public override void Update()
        {
            if (_gsm.InputManager.GetInputState(Key.P).IsPressedInThisFrame)
            {
                _gsm.PopState();
            }
            _blinkTimer.Update();
            
            if (!_blinkTimer.IsFinished()) return;
            
            _blinkTimer.Restart();
            _renderText = !_renderText;
        }
        
        public override void Render(){
            _battleField.Render();
            if(_renderText)
                _consoleWindow.Write(20,32,"PAUSE",Color4.White);
        }

        public override bool IsRunning()
        {
            return _battleField.IsRunning();
        }

        public override void Dispose()
        {
            _battleField.Dispose();
        }
    }
}