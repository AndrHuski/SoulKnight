using System;
using System.Drawing;
using System.Windows.Forms;

namespace SoulKnight
{
    public partial class Contrl : Form
    {
        public Contrl()
        {
            InitializeComponent();
            button_exit.MouseEnter += (s, e) => {
                button_exit.ForeColor = Color.White;
            };
            button_exit.MouseLeave += (s, e) => {
                button_exit.ForeColor = Color.Aqua;
            };
        }

        private void ContrlLoad(object sender, EventArgs e)
        {

        }

        private void BackToMenu(object sender, EventArgs e)
        {
            var menu1 = Application.OpenForms[0];
            menu1.Show();
            this.Hide();
        }
    }
}
