using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MCUtils.Hookins;

namespace MCUtils
{
    public partial class Head : UserControl
    {
        public Head()
        {
            InitializeComponent();
        }
        public void Init(MCUUID uid)
        {
            this.BackgroundImage = Image.FromFile($"https://crafatar.com/avatars/{uid.UUID}");
        }
        public void Init(MCNAME nme)
        {
            this.BackgroundImage = Image.FromFile($"https://minotar.net/avatar/{nme.NAME}");
        }
    }
    public class Hookins
    {
        public struct MCUUID
        {
            public string UUID { get; set; }
            public MCUUID(string uuid)
            {
                UUID = uuid;
            }
        }
        public struct MCNAME
        {
            public string NAME { get; set; }
            public MCNAME(string name)
            {
                NAME = name;
            }
        }
    }
}
