using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using AsciiInvaders.GameObjects.GameStates;
using NetCoreEx.Geometry;
using OpenTK.Graphics;
using SunshineConsole;
using InputManager = TestWolfCurses.InputManager;

namespace AsciiInvaders
{
    class Program
    {

        private static GameStateManager gsm;

        static void Main(string[] args)
        {
            gsm = new GameStateManager();
            gsm.PushState(new PlayState(gsm));
            do
            {
                //MAIN LOOP 			MAIN LOOP 		MAIN LOOP 		MAIN LOOP			MAIN LOOP
                gsm.Update();
                gsm.Render();
            } while (gsm.IsRunning());
        }
    }
}