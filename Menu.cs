using System;
using System.Drawing;
using System.Windows.Forms;

namespace SoulKnight
{
    public partial class Menu : Form
    {
        public SoulKnight level = new SoulKnight();
        public Contrl control = new Contrl();
        public Menu()
        {
            InitializeComponent();
            
            button_start.MouseEnter += (s, e) => 
            {
                button_start.ForeColor = Color.White;
            };

            button_start.MouseLeave += (s, e) => {
                button_start.ForeColor = Color.Aqua;
            };

            button_exit.MouseEnter += (s, e) => {
                button_exit.ForeColor = Color.White;
            };

            button_exit.MouseLeave += (s, e) => {
                button_exit.ForeColor = Color.Aqua;
            };

            button2.MouseEnter += (s, e) => {
                button2.ForeColor = Color.White;
            };

            button2.MouseLeave += (s, e) => {
                button2.ForeColor = Color.Aqua;
            };
           
            KeyDown += new KeyEventHandler(MenuKeyDown);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                Sound.DontPlayInMenu();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MenuLoad(object sender, EventArgs e)
        {
            if (checkSound.Checked)
                Sound.Play_menu();
        }

        private void ButtonExitClick(object sender, EventArgs e)
        {
            Sound.DontPlayInMenu();
            this.Close();
            this.Dispose();
        }
        
        private void StartLevel()
        {
            this.Hide();
            Sound.DontPlayInMenu();
            level.ShowDialog();  
            this.Close();
        }

        private void ButtonStartClick(object sender, EventArgs e)
        {
            StartLevel();
        }

        public void SoundCheckChanged(object sender, EventArgs e)
        {
            if (checkSound.Checked)
            {
                level.checkBox1.Checked = true;  
                Sound.Sound_on();
                checkSound.Text = "Звук ВКЛ";
                Sound.Play_menu(); 
            }
            else
            {
                level.checkBox1.Checked = false;             
                Sound.Sound_off();
                checkSound.Text = "Звук ВЫКЛ";
                Sound.DontPlayInMenu();           
            }
        }

        private void Label1Click(object sender, EventArgs e)
        {
            
        }

        private void MenuKeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void AxWindowsMediaPlayer1Enter1(object sender, EventArgs e)
        {
              
        }
        private void Button2Click(object sender, EventArgs e)
        {
            this.Hide();
            control.Show();
        }
    }
}