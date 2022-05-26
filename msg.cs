using System;
using System.Windows.Forms;

namespace SoulKnight
{
    public partial class Msg : Form
    {
        public Msg()
        {
            InitializeComponent();
            label1.Text = "Поздравляем!\n" +
                   "Вы выиграли!!\n" +
                   "Нажмите OKAY чтобы закрыть игру!";
        }

        private void Label1Click(object sender, EventArgs e)
        {
           
        }

        private void Button1Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.Exit();
            this.Close();
        }

        private void MsgLoad(object sender, EventArgs e)
        {

        }
    }
}