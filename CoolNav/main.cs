using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static CoolNav.Str;

namespace CoolNav
{
    public class ConsoleInformationEngine
    {
        public void Initialize(string about, string title, string[] authors)
        {
            Console.WriteLine($"=- {title} -=");
            Console.WriteLine(about);
            string auth = "";
            foreach (string aut in authors)
            {
                auth += aut + " ";
            }
            Console.WriteLine($"{auth}");
        }
    }
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
                ch = "o ";
            }
            else if (sr == Str.ConsoleNavStyle.space)
            {
                ch = " ";
            }
            else if (sr == Str.ConsoleNavStyle.dash)
            {
                ch = "-";
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
                ch = "o ";
                sch = "o  ";
            }
            else if (sty == Str.ConsoleNavStyle.space)
            {
                ch = " ";
                sch = "   ";
            }
            else if (sty == Str.ConsoleNavStyle.dash)
            {
                ch = "-";
                sch = "- ";
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
    }
    public class ConsoleSealedInputEngine
    {
        public bool isbroken = false;
        public string Initialize(int desired, ConsoleSealedInputKeys ky)
        {
            string pass = "";
            int h = 0;
            Console.Write("<");
            while (true)
            {
                if (h == desired)
                {
                    break;
                }
                else
                {
                    h += 1;
                    ConsoleKeyInfo ck = Console.ReadKey(true);
                    if (ck.Key != ConsoleKey.Enter && ck.Key != ConsoleKey.Backspace && ck.Key != ConsoleKey.Delete)
                    {
                        Console.Write("*");
                        pass += ck.KeyChar;
                    }
                }
            }
            Console.Write(">");
            Console.WriteLine();
            return pass;
        }
    }
    public class ConsoleSearchEngine
    {
        public string Initialize(string[] choices, ConsoleColor backcolor)
        {
            List<string> parsed = new List<string>();
            foreach (string choice in choices)
            {
                Console.WriteLine($"- {choice}");
            }
            string ans = Console.ReadLine();
            if (choices.Contains<string>(ans))
            {
                Console.Clear();
                foreach (string choice in choices)
                {
                    if (choice.Equals(ans))
                    {
                        Console.BackgroundColor = backcolor;
                        Console.WriteLine($"-   {choice}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"- {choice}");
                    }
                }
            }
            return ans;
        }
    }
    public class ConsoleLoadingEngine
    {
        public void Initialize()
        {
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.White;
        }
        public void Add(int value, int delay)
        {
            Util.RepeatAction(value / 10, () => { Thread.Sleep(delay); Console.Write(" "); });
        }
        public void Close()
        {
            Console.ResetColor();
            Console.Write("|");
        }
    }
    public class Util
    {
        public static void RepeatAction(int repeatCount, Action action)
        {
            for (int i = 0; i < repeatCount; i++)
                action();
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
            bullets,
            space,
            dash
        }
        public struct ConsoleSealedInputKeys
        {
            public ConsoleKey enter { get; set; }
            public ConsoleSealedInputKeys(ConsoleKey en)
            {
                enter = en;
            }
        }
    }
}
