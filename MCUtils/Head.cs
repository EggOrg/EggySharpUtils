using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCUtils
{
    public partial class Head : UserControl
    {
        public static string UUID { get; set; }
        public Head()
        {
            InitializeComponent();
        }
        private void GetHead(object sender, EventArgs e)
        {
            if (UUID != string.Empty)
            {
            this.BackgroundImage = Image.FromFile($"https://crafatar.com/avatars/{UUID}");
            }
        }
    }
}
