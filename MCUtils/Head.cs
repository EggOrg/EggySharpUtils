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
    /// <summary>
    /// Head control.
    /// </summary>
    public partial class Head : UserControl
    {
        public Head()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Initializes the head control with a UUID
        /// </summary>
        /// <param name="uid">MCUUID</param>
        public void Init(MCUUID uid)
        {
            this.BackgroundImage = Image.FromFile($"https://crafatar.com/avatars/{uid.UUID}");
        }
        /// <summary>
        /// Initializes the head control with a name.
        /// </summary>
        /// <param name="nme">MCNAME</param>
        public void Init(MCNAME nme)
        {
            this.BackgroundImage = Image.FromFile($"https://minotar.net/avatar/{nme.NAME}");
        }
    }
}
