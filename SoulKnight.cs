using SoulKnight.Models;
using System.IO;
using SoulKnight.Controllers;
using SoulKnight.weapons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace SoulKnight
{
    public partial class SoulKnight : Form
    {

        public static Point camera;

        public Image weaponSheet, weaponSheet1, weaponSheet2, weaponSheet4, weaponSheet5, weaponSheet6;
        public Image mobSheet, mobSheet2, mobSheet3, mobSheet4, mobSheet5, mobSheet6;
        public Image heartsImage, dwarfSheet, bossSheet, flaskSheet;
       
        public static Hearts hearts;

        public Weapons weapon, weapon1, weapon2, weapon4, weapon5, weapon6;

        public static List<Weapons> weapons = new List<Weapons>();
        public static List<Enemies.Enemies> enemies;
        public static List<Staff.Staff> flasks;
        public Entity.Entity player;
        public Staff.Staff Staff;
        public static bool Wpressed, Apressed, Spressed, Dpressed;
        public static bool collide, hitPlayer, redrawHearts, escPressed = false;
        public static int newCheckPoint, oldCheckPoint = 0;
        public int newDeltaX, newDeltaY;
        
        public static int newBossIndex = 0;

        public SoulKnight()
        {
            BackColor = Color.FromArgb(47, 47, 46);

            InitializeComponent();

            timer1.Interval = 30;
            timer2.Interval = 30;
            timer3.Interval = 10;
            timer4.Interval = 10;

            timer1.Tick += new EventHandler(PlayerUpdate);
            timer2.Tick += new EventHandler(EnemiesUpdate);
            timer3.Tick += new EventHandler(CheckCollision);
            timer4.Tick += new EventHandler(Fight);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);
            this.FormClosing += new FormClosingEventHandler(LevelFormClosing);
            camera = new Point(0, 0);

            Init();
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.Y = 0;
                    Wpressed = false;
                    break;

                case Keys.S:
                    player.Y = 0;
                    Spressed = false;
                    break;

                case Keys.A:
                    player.X = 0;
                    Apressed = false;
                    break;

                case Keys.D:
                    player.X = 0;
                    Dpressed = false;
                    break;

                case Keys.E:
                    player.hitPressed = false;
                    if (enemies[newBossIndex].enemyDead)
                    {
                        player.isMove = false;
                        player.SetAnimationConfiguration(0);
                        //this.IsMdiContainer = true;
                        Msg msg = new Msg();
                        //msg.MdiParent = this;
                        //msg.Show();
                        msg.ShowDialog();
                    }
                    break;
            }

            if (player.X == 0 && player.Y == 0 && !hitPlayer)
            {
                player.isMove = false;
                player.SetAnimationConfiguration(0);
            }
        }

        public void WeaponCollision(Entity.Entity player, List<Weapons> weapons)
        {
            foreach (Weapons weapon in weapons)
            {
                double distance = GetDistance(weapon.posX + camera.X - camera.X, weapon.posY + camera.Y - camera.Y, player.posX + camera.X - camera.X, player.posY + camera.Y - camera.Y);
                if (player.isFreeHands == true)
                {
                    if (distance < 15)
                    {
                        weapon.isDropped = false;
                        player.id = weapon.id;
                        player.isFreeHands = false;
                    }
                }
            }
        }

        public void Qpressed(Entity.Entity player, List<Weapons> weapons)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                if (!weapons[i].isDropped)
                {
                    weapons[i].isDropped = true;
                    if (player.posX > player.oldPosX + 5)
                        weapons[i].posX = player.posX - 5;
                    else
                        weapons[i].posX = player.posX + 5;

                    if (player.posY > player.oldPosY + 5)
                        weapons[i].posY = player.posY - 5;
                    else
                        weapons[i].posY = player.posY + 5;
                }
            }
            player.id = 0;
            player.isFreeHands = true;
        }
        public void Init()
        {
            MapControllers.Init();

            this.Width = MapControllers.GetWidth();
            this.Height = MapControllers.GetHeight();

            bossSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\Minotaur - Sprite Sheet.png"));
            heartsImage = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\hearts2.png"));
            flaskSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\flask_big_blue.png"));

            dwarfSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\playerred2.png"));
            weaponSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\weapon3_1.png"));
            weaponSheet1 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\weapon2.png"));
            weaponSheet2 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\weapon_knight_sword.png"));
            weaponSheet5 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\weapon_axe.png"));
            weaponSheet4 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\weapon_big_gold.png"));
            weaponSheet6 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\weapon_big_hammer.png"));
            mobSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\Enemy1.png"));
            mobSheet2 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\enemy2.png"));
            mobSheet3 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\enemy3.png"));
            mobSheet4 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\enemy4.png"));
            mobSheet5 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\enemy5.png"));
            mobSheet6 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\BOSS.png"));

            enemies = new List<Enemies.Enemies>
            {
                new Enemies.Enemies(1007, 836, 10, Hero.bossIdleFrames, Hero.bossRunFrames, Hero.bossAttackFrames, Hero.bossDeathFrames, bossSheet),    
                new Enemies.Enemies(200, 520, 1, Hero.enemyIdleFrames, Hero.enemyRunFrames, mobSheet),
                new Enemies.Enemies(248, 341, 1, Hero.enemyIdleFrames, Hero.enemyRunFrames, mobSheet),
                new Enemies.Enemies(38, 185, 1, Hero.enemyIdleFrames, Hero.enemyRunFrames, mobSheet),
                new Enemies.Enemies(290, 1241, 1, Hero.enemyIdleFrames, Hero.enemyRunFrames, mobSheet),
                new Enemies.Enemies(491, 40, 1, Hero.enemyIdleFrames, Hero.enemyRunFrames, mobSheet),
                new Enemies.Enemies(134, 540, 1, Hero.enemyIdleFrames, Hero.enemyRunFrames, mobSheet),

                new Enemies.Enemies(542, 701, 2, Hero.enemy2IdleFrames, Hero.enemy2RunFrames, mobSheet2),
                new Enemies.Enemies(143, 1184, 2, Hero.enemy2IdleFrames, Hero.enemy2RunFrames, mobSheet2),
                new Enemies.Enemies(191, 1718, 2, Hero.enemy2IdleFrames, Hero.enemy2RunFrames, mobSheet2),
                new Enemies.Enemies(698, 1757, 2, Hero.enemy2IdleFrames, Hero.enemy2RunFrames, mobSheet2),

                new Enemies.Enemies(300, 500, 3, Hero.enemy2IdleFrames, Hero.enemy2RunFrames, mobSheet3),
                new Enemies.Enemies(323, 317, 3, Hero.enemy2IdleFrames, Hero.enemy2RunFrames, mobSheet3),
                new Enemies.Enemies(530, 242, 3, Hero.enemy2IdleFrames, Hero.enemy2RunFrames, mobSheet3),

                new Enemies.Enemies(266, 242, 4, Hero.enemyIdleFrames, Hero.enemyRunFrames, mobSheet4),
                new Enemies.Enemies(257, 149, 4, Hero.enemyIdleFrames, Hero.enemyRunFrames, mobSheet4),
                new Enemies.Enemies(527, 449, 4, Hero.enemyIdleFrames, Hero.enemyRunFrames, mobSheet4),
                new Enemies.Enemies(473, 1001, 4, Hero.enemyIdleFrames, Hero.enemyRunFrames, mobSheet4),
                new Enemies.Enemies(290, 1370, 4, Hero.enemyIdleFrames, Hero.enemyRunFrames, mobSheet4),
                new Enemies.Enemies(464, 1757, 4, Hero.enemyIdleFrames, Hero.enemyRunFrames, mobSheet4),

                new Enemies.Enemies(38, 302, 5, Hero.enemy5IdleFrames, Hero.enemy5RunFrames, mobSheet5),
                new Enemies.Enemies(53, 464, 5, Hero.enemy5IdleFrames, Hero.enemy5RunFrames, mobSheet5),
                new Enemies.Enemies(353, 40, 5, Hero.enemy5IdleFrames, Hero.enemy5RunFrames, mobSheet5),
                new Enemies.Enemies(62, 977, 5, Hero.enemy5IdleFrames, Hero.enemy5RunFrames, mobSheet5),
                
                new Enemies.Enemies(533, 860, 6, Hero.enemy2IdleFrames, Hero.enemy2RunFrames, mobSheet6),
                new Enemies.Enemies(260, 962, 6, Hero.enemy2IdleFrames, Hero.enemy2RunFrames, mobSheet6),
                new Enemies.Enemies(92, 1577, 6, Hero.enemy2IdleFrames, Hero.enemy2RunFrames, mobSheet6),
                new Enemies.Enemies(974, 1757, 6, Hero.enemy2IdleFrames, Hero.enemy2RunFrames, mobSheet6),
                new Enemies.Enemies(671, 1364, 6, Hero.enemy2IdleFrames, Hero.enemy2RunFrames, mobSheet6),
            };

            flasks = new List<Staff.Staff>
            {
                new Staff.Staff(125, 1622, 1, flaskSheet),
                new Staff.Staff(764, 845, 1, flaskSheet),
                new Staff.Staff(995, 635, 1, flaskSheet),
                new Staff.Staff(1244, 830, 1, flaskSheet),
                new Staff.Staff(1001, 1109, 1, flaskSheet),
            };

            player = new Entity.Entity(32, 32, Hero.idleFrames, Hero.runFrames, Hero.attackFrames, Hero.deathFrames, Hero.redFrames, dwarfSheet);
           
            hearts = new Hearts(580, 10, Hero.fullHearts, Hero.heartsFrames, heartsImage);

            weapon = new Weapons(90, 50, 1, weaponSheet);
            weapon1 = new Weapons(995, 1079, 2, weaponSheet1);
            weapon2 = new Weapons(485, 533, 3, weaponSheet2);
            weapon5 = new Weapons(60, 50, 5, weaponSheet5);
            weapon4 = new Weapons(41, 1139, 4, weaponSheet4);
            weapon6 = new Weapons(1127, 1760, 6, weaponSheet6);
            weapons.Add(weapon);
            weapons.Add(weapon1);
            weapons.Add(weapon2);
            weapons.Add(weapon5);
            weapons.Add(weapon4);
            weapons.Add(weapon6);

            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.Y = -player.speed;
                    Wpressed = true;
                    player.isMove = true;
                    player.SetAnimationConfiguration(0);
                    break;

                case Keys.A:
                    Apressed = true;
                    player.X = -player.speed;
                    player.flip = -1;
                    player.isMove = true;
                    player.SetAnimationConfiguration(0);
                    break;

                case Keys.S:
                    player.Y = player.speed;
                    Spressed = true;
                    player.isMove = true;
                    player.SetAnimationConfiguration(0);
                    break;

                case Keys.D:
                    Dpressed = true;
                    player.X = player.speed;
                    player.flip = 1;
                    player.isMove = true;
                    player.SetAnimationConfiguration(0);
                    break;

                case Keys.E:
                    player.hitPressed = true;
                    if (enemies[newBossIndex].enemyDead)
                    {
                        player.isMove = false;
                        player.SetAnimationConfiguration(0);
                        //this.IsMdiContainer = true;
                        Msg msg = new Msg();
                        //msg.MdiParent = this;
                        //msg.Show();
                        msg.ShowDialog();
                    }
                    break;

                case Keys.Q:
                    Qpressed(player, weapons);
                    break;

                case Keys.F:
                    WeaponCollision(player, weapons);
                    break;

                case Keys.Escape:
                    timer1.Stop();
                    timer2.Stop();
                    timer3.Stop();
                    timer4.Stop();
                    string message = "Весь прогресс не будет сохранён, вы уверены?";
                    string title = "Выйти в главное меню";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        this.Hide();
                        weapons.Clear();
                        enemies.Clear();
                        player.hitPressed = false;
                        player.id = 0;
                        player.isFreeHands = true;
                        Menu fm = new Menu();
                        if (checkBox1.Checked == false)
                            fm.checkSound.Checked = false;
                        else
                            fm.checkSound.Checked = true;
                        axWindowsMediaPlayer1.Ctlcontrols.stop();
                        axWindowsMediaPlayer2.Ctlcontrols.stop();
                        axWindowsMediaPlayer3.Ctlcontrols.stop();
                        
                        fm.ShowDialog();

                        escPressed = true;
                        this.Close();
                        this.Dispose();
                    }
                    else
                    {
                        timer1.Start();
                        timer2.Start();
                        timer3.Start();
                        timer4.Start();
                    }
                    break;
            }
        }

        public void Fight(object sender, EventArgs e)
        {
            foreach (Weapons weapon in weapons)
                weapon.HitEnemies(enemies, weapons, player);

            foreach (Weapons weapon in weapons)
                weapon.WeaponsMove(weapons, player);
        }

        public void CheckCollision(object sender, EventArgs e)
        {
            Collisions.Collision(player);

            for (int j = (int)player.posX / MapControllers.cellSize; j < (player.posX + MapControllers.cellSize) / MapControllers.cellSize; j++)
            {
                for (int i = (int)player.posY / MapControllers.cellSize; i < (player.posY + MapControllers.cellSize) / MapControllers.cellSize; i++)
                {
                    if (MapControllers.map[i, j] == 50)
                    {
                        newCheckPoint = 1;
                        player.oldPosX = j * 32;
                        player.oldPosY = i * 32;
                    }
                    else if (MapControllers.map[i, j] == 51)
                    {
                        newCheckPoint = 2;
                        player.oldPosX = j * 32;
                        player.oldPosY = i * 32;
                    }
                    else if (MapControllers.map[i, j] == 52)
                    {
                        newCheckPoint = 3;
                        player.oldPosX = j * 32;
                        player.oldPosY = i * 32;
                    }
                    else if (MapControllers.map[i, j] == 53)
                    {
                        newCheckPoint = 4;
                        player.oldPosX = j * 32;
                        player.oldPosY = i * 32;
                    }
                }
            }
            if (player.collideDead)
            {
                player.posX = player.oldPosX;
                player.posY = player.oldPosY;
                if (newCheckPoint == 0)
                {
                    camera.X = 0;
                    camera.Y = 0;
                }
                else if (newCheckPoint == 1)
                {
                    camera.X = 0;
                    camera.Y = -3;
                }
                else if (newCheckPoint == 2)
                {
                    camera.X = -165;
                    camera.Y = -459;
                }
                else if (newCheckPoint == 3)
                {
                    camera.X = -3;
                    camera.Y = -1074;
                }
                else if (newCheckPoint == 4)
                {
                    camera.X = -636;
                    camera.Y = -960;
                }

                player.HP = 1000;
                player.ih = 0;
                hearts.currentAnimation = 0;
                redrawHearts = true;
            }

            for (int i = 0; i < flasks.Count; i++)
            {
                double distancetoflask = GetDistance((double)player.posX, (double)player.posY, (double)flasks[i].posX, (double)flasks[i].posY);
                if (distancetoflask <= 15)
                {
                    player.HP = 1000;
                    player.SetAnimationConfiguration(2);
                    hearts.SetAnimation(0);
                   
                    player.ih = 0;
                    flasks.RemoveAt(i);
                }
            }
        }
        
        public void EnemiesUpdate(object sedner,EventArgs e)
        {
            for (int i = 0; i < enemies.Count; i++)
                enemies[i].HitPlayer(player);

            for(int i = 0;i < enemies.Count;i++)
                enemies[i].FlipEnemies(player, enemies);

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].HP == 0 || enemies[i].HP <= 0)
                    enemies[i].enemyDead = true;

                double distance1 = GetDistance(player.posX, player.posY, enemies[i].posX, enemies[i].posY);
                double distanceBoss = GetDistance(enemies[i].posX, enemies[i].posY, enemies[i].oldPosX, enemies[i].oldPosY);

                if (distanceBoss > 5)
                {
                    if (distance1 < 10)
                        enemies[i].isMoving = false;
                    else
                        enemies[i].isMoving = true;
                }
                else
                    enemies[i].isMoving = false;

                enemies[i].PlayerMove(player);
            }
        }

        public void PlayerUpdate(object sender, EventArgs e)
        {
            if (player.isMove)
            {
                player.Move();

                if (Wpressed)
                    if (player.posY > ((this.Height / 2) - 260) && player.posY < MapControllers.cellSize * 60 - ((this.Height) / 2))
                        if (!collide && !hitPlayer)
                        {
                            camera.Y += player.playerSpeed;
                            newDeltaY -= 2;
                        }

                if (Apressed)
                    if (player.posX > ((this.Width / 2)) && player.posX < MapControllers.cellSize * 60 - this.Width / 2)
                        if (!collide && !hitPlayer)
                        {
                            camera.X += player.playerSpeed;
                            newDeltaX -= 2;
                        }

                if (Spressed)
                    if (player.posY > ((this.Height / 2) - 260) && player.posY < MapControllers.cellSize * 60 - (this.Height + 50) / 2)
                        if (!collide && !hitPlayer)
                        {
                            camera.Y -= player.playerSpeed;
                            newDeltaY += 2;
                        }

                if (Dpressed)
                    if (player.posX > ((this.Width / 2)) && player.posX < MapControllers.cellSize * 60 - this.Width / 2)
                        if (!collide && !hitPlayer)
                        {
                            camera.X -= player.playerSpeed;
                            newDeltaX += 2;
                        }

            }
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            MapControllers.DrawMap(graphics);

            for (int i = 0; i < enemies.Count; i++)
                enemies[i].PlayEnemyAnimation(graphics);

            for (int i = 0; i < flasks.Count; i++)
                flasks[i].PlayFlask(graphics, player);

            player.PlayAnimation(graphics);
            hearts.DrawHearts(graphics, player);
            
            for (int i = 0; i < weapons.Count; i++)
                weapons[i].DrawWeapon(graphics, player);

            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i].isDropped == false)
                    weapons[i].Hits(graphics, player);
            }

            if (player.id == 1)
                weapon.DrawWeaponInHands(graphics, player);
            else if (player.id == 2)
                weapon1.DrawWeaponInHands(graphics, player);
            else if (player.id == 3)
                weapon2.DrawWeaponInHands(graphics, player);
            else if (player.id == 5)
                weapon5.DrawWeaponInHands(graphics, player);
            else if (player.id == 4)
                weapon4.DrawWeaponInHands(graphics, player);
            else if (player.id == 6)
                weapon6.DrawWeaponInHands(graphics, player);
        }

        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

        private void LevelClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void LevelLoad(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                axWindowsMediaPlayer2.URL = Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Resources\\sound_battle.wav");
                axWindowsMediaPlayer2.settings.volume = 5;
                axWindowsMediaPlayer2.settings.setMode("loop", true);
            }
        }

        private void LevelFormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
            
        private void Timer4Ticks(object sender, EventArgs e)
        {

        }

        private void WindowsMediaPlayer1Enter(object sender, EventArgs e)
        {

        }

        private void Label1Click(object sender, EventArgs e)
        {

        }
    }
}