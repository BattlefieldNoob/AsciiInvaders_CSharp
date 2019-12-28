using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using AsciiInvaders.GameObjects.GameStates;
using OpenTK.Input;
using SunshineConsole;
using WinApi.User32;

namespace TestWolfCurses
{
    public class InputManager
    {
        public class KeyStatus
        {
            public bool isPressed;
            public bool isPressedInThisFrame;
            public bool isReleasedInThisFrame;

            public static KeyStatus Pressed()
            {
                return new KeyStatus() {isPressedInThisFrame = true};
            }
            
            public static KeyStatus Released()
            {
                return new KeyStatus() {isReleasedInThisFrame = true};
            }
        }


        private readonly Dictionary<Key, KeyStatus> _inputs;

        private readonly ConsoleWindow _consoleWindow;
        
        public InputManager()
        {
            _consoleWindow = GameStateManager.Console;
            _inputs = new Dictionary<Key, KeyStatus>();
            _consoleWindow.KeyDown+=ConsoleWindowOnKeyDown;
            _consoleWindow.KeyUp+=ConsoleWindowOnKeyUp;
        }

        private void ConsoleWindowOnKeyUp(object? sender, KeyboardKeyEventArgs e)
        {
            if(_inputs.Keys.All(key => key != e.Key))
                return;
            //Console.WriteLine("Key Up:"+e.Key);
            HandleGenericKeyStatus(e.Key,KeyStatus.Released());
        }

        private void ConsoleWindowOnKeyDown(object? sender, KeyboardKeyEventArgs e)
        {
            if(_inputs.Keys.All(key => key != e.Key))
                return;
            //Console.WriteLine("Key Down:"+e.Key);
            HandleGenericKeyStatus(e.Key,KeyStatus.Pressed());
        }


        public void RegisterInput(Key key)
        {
            _inputs.Add(key, new KeyStatus());
        }

        public KeyStatus GetInputState(Key key)
        {
            return _inputs[key];
        }
        

        private void HandleGenericKeyStatus(Key key, KeyStatus state)
        {
            if (_inputs.ContainsKey(key))
            {
                var old = _inputs[key];

                if (state.isPressedInThisFrame && !old.isPressed)
                {
                    old.isPressedInThisFrame = true;
                    old.isReleasedInThisFrame = false;
                }
                else if (!state.isPressedInThisFrame && old.isPressed)
                {
                    old.isReleasedInThisFrame = true;
                    old.isPressedInThisFrame = false;
                }
                else
                {
                    old.isPressedInThisFrame = false;
                    old.isReleasedInThisFrame = false;
                }

                _inputs[key].isPressed = (old.isPressed && !old.isReleasedInThisFrame) || (old.isPressedInThisFrame );
            }
            else
            {
                Console.WriteLine("Error!!!");
            }
        }

    }
}