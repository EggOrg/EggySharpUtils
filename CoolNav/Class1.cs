using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolNav
{
    public class ConsoleNavEngine
    {
        public bool isbroken = false;
        public string Initialize(Str.ConsoleNavKeys keys, string[] choices, ConsoleColor selbg)
        {
            int sel = 0;
            foreach (string choice in choices)
            {
                Console.WriteLine($"> {choice}");
            }
            while (isbroken == false)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == keys.up)
                {
                    if (sel != 0)
                    {
                        sel -= 1;
                        Rewrite(choices, sel, selbg);
                    }
                }
                else if (Console.KeyAvailable && Console.ReadKey(true).Key == keys.down)
                {
                    if (sel != choices.Length)
                    {
                        sel += 1;
                        Rewrite(choices, sel, selbg);
                    }
                }
                else if (Console.KeyAvailable && Console.ReadKey(true).Key == keys.enter)
                {
                    return choices[sel];
                }
            }
            return "Selection broken!";
        }
        public void Break()
        {
            isbroken = true;
        }
        private void Rewrite(string[] choices, int choiced, ConsoleColor selbg)
        {
            ConsoleColor origbg = Console.BackgroundColor;
            foreach (var item in choices.Select((value, i) => new { i, value }))
            {
                var value = item.value;
                var index = item.i;
                if (index == choiced)
                {
                    Console.BackgroundColor = selbg;
                    Console.WriteLine("<" + value);
                    Console.BackgroundColor = origbg;
                }
                else
                {
                    Console.WriteLine(">" + value);
                }
            }
        }
    }
    public class Str
    {
        public struct ConsoleNavKeys
        {
            public ConsoleKey up { get; set; }
            public ConsoleKey down { get; set; }
            public ConsoleKey enter { get; set; }
            public ConsoleNavKeys(ConsoleKey u, ConsoleKey d, ConsoleKey r)
            {
                up = u;
                down = d;
                enter = r;
            }
        }
    }
}
