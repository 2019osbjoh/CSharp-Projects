using System;
using System.Collections.Generic;

namespace Slalom {
    class MainClass {
        public static void Main (string[] args) {
            int gateX = 30;
            int skierX = 38;
            int gateInc = 1;
            int skierInc = 0;
            int slopeLength = 100;
            int gateNum = 0;
            int score = 0;
            int speed = 70;

            Random rnd = new Random();
            ConsoleKeyInfo info = new ConsoleKeyInfo();
            List<int> gates = new List<int>();

            Console.Clear();
            Console.CursorVisible = false;

            for (int i = 0; i < 23; i++) {
                gates.Add(gateX);
            }

            while (gateNum < slopeLength) {
                while (Console.KeyAvailable) {
                    info = Console.ReadKey(true);
                }

                switch (info.Key) {
                    case ConsoleKey.LeftArrow:
                        skierInc = -1;
                        break;
                    
                    case ConsoleKey.RightArrow:
                        skierInc = 1;
                        break;
                    
                    default:
                        break;
                }

                Console.SetCursorPosition(gateX, 23);
                skierX += skierInc;

                if (gateNum < slopeLength - 22) {
                    if (gateNum == 0) {
                        Console.Write("X     Start     X");
                    } else if (gateNum == slopeLength - 23) {
                        Console.Write("X     Goal      X");
                    } else {
                        Console.Write("X               X");
                    }

                    if (gates[0] < skierX && gates[0] + 15 > skierX || gateNum < 23) {
                        score++;
                        Console.WriteLine();
                    } else {
                        Console.WriteLine("          Missed!");
                    }
                } else {
                    Console.WriteLine();
                }

                Console.SetCursorPosition(skierX, 0);
                Console.Write("o");
                System.Threading.Thread.Sleep(speed);

                gateX += gateInc;

                if (rnd.Next(0, 6) == 0) {
                    gateInc = -gateInc;
                }

                if (gateX == 0) {
                    gateInc = 1;
                }

                if (gateX == 60) {
                    gateInc = -1;
                }

                gates.Add(gateX);
                gates.RemoveAt(0);
				gateNum++;
			}

            Console.WriteLine("\n\nSkier #1 (SWE) final score " + score + " out of " + slopeLength + " points");
        }
    }
}
