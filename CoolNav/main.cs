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
    public class ConsoleVerticalNavEngine
    {
        private bool isbroken = false;
        private string[] c;
        private Str.ConsoleNavKeys k;
        private ConsoleColor bg;
        private int sel = 0;
        private Str.ConsoleVerticalNavStyle cns;
        private int cho;
        public void Initialize(Str.ConsoleNavKeys keys, string[] choices, ConsoleColor selbg, Str.ConsoleVerticalNavStyle sr)
        {
            cns = sr;
            int sel = 0;
            string ch = "";
            if (sr == Str.ConsoleVerticalNavStyle.arrows)
            {
                ch = ">";
            }
            else if (sr == Str.ConsoleVerticalNavStyle.bullets)
            {
                ch = "o ";
            }
            else if (sr == Str.ConsoleVerticalNavStyle.space)
            {
                ch = " ";
            }
            else if (sr == Str.ConsoleVerticalNavStyle.dash)
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
            cns = sr;
        }
        public void Break()
        {
            isbroken = true;
        }
        private void Rewrite()
        {
            string ch = "";
            string sch = "";
            if (cns == Str.ConsoleVerticalNavStyle.arrows)
            {
                ch = ">";
                sch = "<";
            }
            else if (cns == Str.ConsoleVerticalNavStyle.bullets)
            {
                ch = "o ";
                sch = "o  ";
            }
            else if (cns == Str.ConsoleVerticalNavStyle.space)
            {
                ch = " ";
                sch = "   ";
            }
            else if (cns == Str.ConsoleVerticalNavStyle.dash)
            {
                ch = "-";
                sch = "- ";
            }
            Console.Clear();
            ConsoleColor origbg = Console.BackgroundColor;
            foreach (var item in c.Select((value, i) => new { i, value }))
            {
                var value = item.value;
                var index = item.i;
                if (index == cho)
                {
                    Console.BackgroundColor = bg;
                    Console.WriteLine(sch + value);
                    Console.BackgroundColor = origbg;
                }
                else
                {
                    Console.WriteLine(ch + value);
                }
            }
        }
        public string Listen(ConsoleVerticalNavEngine cn)
        {
            while (isbroken == false)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == k.up)
                {
                    if (sel != 0)
                    {
                        sel -= 1;
                        cho = sel;
                        Rewrite();
                    }
                }
                else if (Console.KeyAvailable && Console.ReadKey(true).Key == k.down)
                {
                    if (sel < c.Length)
                    {
                        sel += 1;
                        cho = sel;
                        Rewrite();
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
        public string Initialize(string[] choices, ConsoleColor backcolor, ConsoleSearchMethod csm)
        {
            List<string> parsed = new List<string>();
            foreach (string choice in choices)
            {
                Console.WriteLine($"- {choice}");
            }
            string h = Console.ReadLine();
            if (choices.Contains<string>(h))
            {
                Console.Clear();
                if (csm == ConsoleSearchMethod.Contains)
                {
                    foreach (string choice in choices)
                    {
                        if (choice.Contains(h))
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
                else if (csm == ConsoleSearchMethod.Equals)
                {
                    foreach (string choice in choices)
                    {
                        if (choice.Equals(h))
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
            }
            return h;
        }
    }
    public class ConsoleHorizontalNavEngine
    {
        private bool isbroken = false;
        private  string[] c;
        private Str.ConsoleNavKeys k;
        private ConsoleColor bg;
        private int sel = 0;
        private int cho;
        private string bfc = "";
        private string afc = "";
        public void Initialize(Str.ConsoleNavKeys keys, string[] choices, ConsoleColor selbg, Str.ConsoleHorizontalNavStyle chns)
        {
            Console.WriteLine();
            int sel = 0;
            if (chns == ConsoleHorizontalNavStyle.dash)
            {
                bfc = "-";
                afc = "-";
                foreach (string choice in choices)
                {
                    Console.Write($"- {choice} -");
                }
            }
            else if (chns == ConsoleHorizontalNavStyle.space)
            {
                bfc = "  ";
                afc = "  ";
                foreach (string choice in choices)
                {
                    Console.Write($"  {choice}  ");
                }
            }
            c = choices;
            k = keys;
            bg = selbg;
        }
        public void Break()
        {
            isbroken = true;
        }
        private void Rewrite()
        {
            Console.Clear();
            ConsoleColor origbg = Console.BackgroundColor;
            foreach (var item in c.Select((value, i) => new { i, value }))
            {
                var value = item.value;
                var index = item.i;
                if (index == cho)
                {
                    Console.BackgroundColor = bg;
                    Console.Write($"{bfc} [{value}] {afc}");
                    Console.BackgroundColor = origbg;
                }
                else
                {
                    Console.Write($"{bfc} {value} {afc}");
                }
            }
        }
        public string Listen(ConsoleHorizontalNavEngine cn)
        {
            while (isbroken == false)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == k.left)
                {
                    if (sel != 0)
                    {
                        sel -= 1;
                        cho = sel;
                        Rewrite();
                    }
                }
                else if (Console.KeyAvailable && Console.ReadKey(true).Key == k.right)
                {
                    if (sel < c.Length)
                    {
                        sel += 1;
                        cho = sel;
                        Rewrite();
                    }
                    else if (sel == c.Length)
                    {
                        sel = c.Length;
                    }
                }
                else if (Console.KeyAvailable && Console.ReadKey(true).Key == k.enter)
                {
                    Console.WriteLine();
                    return c[sel];
                }
            }
            return "broken";
        }
    }
    public class ConsoleLoadingEngine
    {
        public void Initialize()
        {
            Console.Write("|");
            Console.BackgroundColor = ConsoleColor.White;
        }
        public void Add()
        {
            Console.Write(" ");
        }
        public void Add(int delay)
        {
            Thread.Sleep(delay);
            Console.Write(" ");
        }
        public void Add(int value, int delay)
        {
            Thread.Sleep(delay);
            Util.RepeatAction(value, () => { Console.Write(" "); });
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
            public ConsoleKey left { get; set; }
            public ConsoleKey right { get; set; }
            public ConsoleNavKeys(ConsoleKey u, ConsoleKey d, ConsoleKey r, ConsoleKey lk = ConsoleKey.NoName, ConsoleKey rk = ConsoleKey.NoName)
            {
                left = lk;
                right = rk;
                up = u;
                down = d;
                enter = r;
            }
        }
        public enum ConsoleVerticalNavStyle
        {
            arrows,
            bullets,
            space,
            dash
        }
        public enum ConsoleHorizontalNavStyle
        {
            dash,
            space
        }
        public struct ConsoleSealedInputKeys
        {
            public ConsoleKey enter { get; set; }
            public ConsoleSealedInputKeys(ConsoleKey en)
            {
                enter = en;
            }
        }
        public enum ConsoleSearchMethod
        {
            Contains,
            Equals
        }
    }
}
