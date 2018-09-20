using System;
using System.Threading;
using AsciiInvaders.GameObjects.GameStates;
using TestWolfCurses;

namespace AsciiInvaders
{
    class Program
    {

        //  private static Vector2[] positions;
        private static ConsoleKey newRandom = ConsoleKey.A;


    private static InputManager inputManager;

        private static GameStateManager gsm;
        
        static void Main(string[] args)
        {
            gsm=new GameStateManager();
            gsm.PushState(new PlayState(gsm));
            do{
                //MAIN LOOP 			MAIN LOOP 		MAIN LOOP 		MAIN LOOP			MAIN LOOP
                gsm.Update();
                gsm.Render();
                Thread.Sleep(30);
            }while(gsm.IsRunning());
            
    /*        inputManager=new InputManager();
            
            inputManager.RegisterInput(newRandom);
            
            while (true)
            {
                inputManager.EventLoop();
                var state = inputManager.GetInputState(newRandom);
                if (state.isReleasedInThisFrame)
                {
                    Console.WriteLine("Cavallo!");
                }
                
                Thread.Sleep(30);
            }*/
        }

       /* static void Randomize()
        {
            var rand = new Random();
            for (var i = 0; i < positions.Length; i++)
            {
                positions[i].X = rand.Next(0, 20);
                positions[i].Y = rand.Next(0, 10);
            }
        }*/
    }
}