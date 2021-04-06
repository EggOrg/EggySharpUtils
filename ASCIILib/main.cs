using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ASCIILib
{
    public class Artii
    {
        public static async Task<string> Get(string txt)
        {
            return await new HttpClient().GetStringAsync($"https://artii.herokuapp.com/make?text={txt.Replace(' ', '+')}");
        }
    }
}

namespace PrintLib
{
    public class Print
    {
        private Font printFont;
        private string topr;
        private Brush brt;
        private void prapi(object sender, PrintPageEventArgs ev)
        {
            float yPos = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            ev.Graphics.DrawString(topr, printFont, brt, leftMargin, yPos, new StringFormat());
        }
        private void Get(Font fnt, string topri, Brush br)
        {
            printFont = fnt;
            topr = topri;
            brt = br;
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(prapi);
            printDoc.Print();
        }
    }
}