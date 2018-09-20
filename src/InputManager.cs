using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using WinApi.User32;
using XSharp;

namespace TestWolfCurses
{
    public class InputManager
    {
        public class KeyStatus
        {
            public bool isPressed;
            public bool isPressedInThisFrame;
            public bool isReleasedInThisFrame;
        }


        private readonly Dictionary<ConsoleKey, KeyStatus> _inputs;


        private readonly XWindow _mainWin;

        private readonly XEvent _xevent;

        public InputManager()
        {
            _inputs = new Dictionary<ConsoleKey, KeyStatus>();

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var display = new XDisplay(":0.0");
                _mainWin = new XWindow(display);
                _xevent = new XEvent(display);
                bool a = false;
                _mainWin.SelectInput(XEventMask.KeyPressMask | XEventMask.KeyReleaseMask);
                XDisplay.XkbSetDetectableAutoRepeat(display.Handle, true, ref a);

                _xevent.KeyPressHandlerEvent += (ev, window, root, subwindow) =>
                {
                    //Console.WriteLine("Pressed:" + ev.keycode);
                    HandleGenericKeyStatus(X11ToConsoleKey(ev), new KeyState() {IsPressed = true});
                };
                _xevent.KeyReleaseHandlerEvent += (ev, window, root, subwindow) =>
                {
                    //Console.WriteLine("Released:" + ev.keycode);
                    HandleGenericKeyStatus(X11ToConsoleKey(ev), new KeyState() {IsPressed = false});
                };
            }
        }


        public void RegisterInput(ConsoleKey key)
        {
            _inputs.Add(key, new KeyStatus());

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return;
            
            var x11Key = ConsoleToX11XKeySym(key);
            _mainWin.GrabKey(x11Key, XModMask.None, true, XGrabMode.GrabModeAsync,
                XGrabMode.GrabModeAsync);
        }

        public KeyStatus GetInputState(ConsoleKey key)
        {
            return _inputs[key];
        }


        public void EventLoop()
        {
            //ciclo sugli input "richiesti", assegnando i valori corretti
            for (int i = 0; i < _inputs.Keys.Count; i++)
            {
                var input = _inputs.Keys.ElementAt(i);


                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    var windowsVirtualKey = ConsoleToWindowsVirtualKey(input);

                    //aggiorno gli input
                    var state = User32Methods.GetKeyState(windowsVirtualKey);

                    HandleGenericKeyStatus(input, state);
                }
                else
                {
                    // do something else here
                    _xevent.NoBlockingLoop();
                }
            }
        }

        private void HandleGenericKeyStatus(ConsoleKey key, KeyState state)
        {
            if (_inputs.ContainsKey(key))
            {

                var old = _inputs[key];

                if (state.IsPressed && !old.isPressed)
                {
                    old.isPressedInThisFrame = true;
                    old.isReleasedInThisFrame = false;
                }
                else if (!state.IsPressed && old.isPressed)
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


        private VirtualKey ConsoleToWindowsVirtualKey(ConsoleKey key) => (VirtualKey) key;


        private XKeySym ConsoleToX11XKeySym(ConsoleKey key) => (XKeySym) key;


        private ConsoleKey X11ToConsoleKey(XKeyEvent ev)
        {
            var intKeySym = (int)_mainWin.LookupKeysym(ref ev);
            if (intKeySym >= (int)XKeySym.XK_a)
            {
                intKeySym -= (int) XKeySym.XK_a - (int) XKeySym.XK_A;
            }
            return (ConsoleKey) intKeySym;
        }
    }
}