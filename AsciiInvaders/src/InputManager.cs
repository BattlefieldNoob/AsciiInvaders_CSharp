using System;
using System.Collections.Generic;
using System.Linq;
using AsciiInvaders.GameObjects;
using AsciiInvaders.GameObjects.GameStates;
using OpenTK.Input;
using SunshineConsole;

namespace AsciiInvaders
{
    public class InputManager : GameObject
    {
        public class KeyStatus
        {
            public bool IsPressed;
            public bool IsPressedInThisFrame;
            public bool IsReleasedInThisFrame;

            public static KeyStatus Pressed()
            {
                return new KeyStatus() {IsPressedInThisFrame = true};
            }

            public static KeyStatus Released()
            {
                return new KeyStatus() {IsReleasedInThisFrame = true};
            }
        }


        private Dictionary<Key, KeyStatus> _inputs;

        private readonly ConsoleWindow _consoleWindow;

        public InputManager()
        {
            _consoleWindow = GameStateManager.Console;
            _inputs = new Dictionary<Key, KeyStatus>();
        }
        
        public void RegisterInput(Key key)
        {
            _inputs.Add(key, KeyStatus.Released());
        }

        public KeyStatus GetInputState(Key key)
        {
            return _inputs[key];
        }


        private KeyStatus HandleGenericKeyStatus(Key key, KeyStatus state)
        {
            if (_inputs.ContainsKey(key))
            {
                var old = _inputs[key];

                if (state.IsPressedInThisFrame && !old.IsPressed)
                {
                    //Console.WriteLine("Pressed this frame:"+key);
                    //Se è stato premuto ma prima non lo era
                    old.IsPressedInThisFrame = true;
                    old.IsReleasedInThisFrame = false;
                    old.IsPressed = true;
                }
                else if (!state.IsPressedInThisFrame && old.IsPressed)
                {
                    //Console.WriteLine("released this frame:"+key);
                    //Se non è premuto ma prima lo era
                    old.IsReleasedInThisFrame = true;
                    old.IsPressedInThisFrame = false;
                    old.IsPressed = false;
                }
                else
                {
                    //Console.WriteLine("Constant this frame:"+key);
                    //Se è premuto ed lo è ancora, Se non è premuto e non lo è ancora
                    old.IsPressedInThisFrame = false;
                    old.IsReleasedInThisFrame = false;
                }

                old.IsPressed = (old.IsPressed && !old.IsReleasedInThisFrame) || (old.IsPressedInThisFrame);
                return old;
            }
            else
            {
                Console.WriteLine("Error!!!");
                return KeyStatus.Released();
            }
        }

        public override void Update()
        {
            _inputs=_inputs
                .ToDictionary(pair => pair.Key,
                    pair => HandleGenericKeyStatus(pair.Key,
                        _consoleWindow.KeyIsDown(pair.Key) ? KeyStatus.Pressed() : KeyStatus.Released()));

        }
    }
}