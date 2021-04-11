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
        public string[] c;
        public Str.ConsoleNavKeys k;
        public ConsoleColor bg;
        public int sel = 0;
        public Str.ConsoleNavStyle cns;
        public void Initialize(Str.ConsoleNavKeys keys, string[] choices, ConsoleColor selbg, Str.ConsoleNavStyle sr)
        {
            cns = sr;
            int sel = 0;
            string ch = "";
            if (sr == Str.ConsoleNavStyle.arrows)
            {
                ch = ">";
            }
            else if (sr == Str.ConsoleNavStyle.bullets)
            {
                ch = "•";
            }
            foreach (string choice in choices)
            {
                Console.WriteLine($"{ch} {choice}");
            }
            c = choices;
            k = keys;
            bg = selbg;
        }
        public void Break()
        {
            isbroken = true;
        }
        private void Rewrite(string[] choices, int choiced, ConsoleColor selbg, Str.ConsoleNavStyle sty)
        {
            string ch = "";
            string sch = "";
            if (sty == Str.ConsoleNavStyle.arrows)
            {
                ch = ">";
                sch = "<";
            }
            else if (sty == Str.ConsoleNavStyle.bullets)
            {
                ch = "o";
                sch = "•";
            }
            Console.Clear();
            ConsoleColor origbg = Console.BackgroundColor;
            foreach (var item in choices.Select((value, i) => new { i, value }))
            {
                var value = item.value;
                var index = item.i;
                if (index == choiced)
                {
                    Console.BackgroundColor = selbg;
                    Console.WriteLine(sch + value);
                    Console.BackgroundColor = origbg;
                }
                else
                {
                    Console.WriteLine(ch + value);
                }
            }
        }
        public string Listen(ConsoleNavEngine cn)
        {
            while (isbroken == false)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == k.up)
                {
                    if (sel != 0)
                    {
                        sel -= 1;
                        Rewrite(c, sel, bg, cns);
                    }
                }
                else if (Console.KeyAvailable && Console.ReadKey(true).Key == k.down)
                {
                    if (sel < c.Length)
                    {
                        sel += 1;
                        Rewrite(c, sel, bg, cns);
                    }
                    else if (sel == c.Length)
                    {
                        sel = c.Length;
                    }
                }
                else if (Console.KeyAvailable && Console.ReadKey(true).Key == k.enter)
                {
                    return c[sel];
                }
            }
            return "broken";
        }
        private static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
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
        public enum ConsoleNavStyle
        {
            arrows,
            bullets
        }
    }
}
