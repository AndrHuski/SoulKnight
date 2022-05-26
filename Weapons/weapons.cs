using System.Collections.Generic;
using System.Drawing;

namespace SoulKnight.weapons
{
    public class Weapons
    {
        public int id, damage;
        public float posX, posY;
        public int posXforHit, posYforHit;
        public Image weaponSheet;
        public bool isDropped;

        public Weapons(float posX, float posY, int Id, Image weaponSh)
        {
            this.posX = posX;
            this.posY = posY;
            id = Id;
            isDropped = true;
            weaponSheet = weaponSh;

            if (id == 1)
                damage = 20;
            if (id == 2)
                damage = 150;
            if (id == 3)
                damage = 40;
            if (id == 4)
                damage = 60;
            if (id == 5)
                damage = 20;
            if (id == 6)
                damage = 80;
        }

        public void Hits(Graphics g, Entity.Entity player)
        {
            foreach (Weapons weapon in SoulKnight.weapons)
            {
                if (player.hitPressed && weapon.id == 1)
                {
                    if (player.flip == 1)
                    {
                        if (id != 6 && id != 5)
                        {
                            g.TranslateTransform(player.posX - 6 + SoulKnight.camera.X + 14, player.posY + 44 / 2.0f + SoulKnight.camera.Y);
                            g.RotateTransform(90);
                            g.TranslateTransform(-(player.posX - 6 + SoulKnight.camera.X + 14), -(player.posY + 44 / 2.0F + SoulKnight.camera.Y));
                        }
                        if (id == 6)
                        {
                            g.TranslateTransform(player.posX + 3 + SoulKnight.camera.X + 14, player.posY + 48 / 2.0f + SoulKnight.camera.Y);
                            g.RotateTransform(90);
                            g.TranslateTransform(-(player.posX - 6 + SoulKnight.camera.X + 14), -(player.posY + 44 / 2.0F + SoulKnight.camera.Y));
                        }
                        if (id == 5)
                        {
                            g.TranslateTransform(player.posX + 1 + SoulKnight.camera.X + 14, player.posY + 52 / 2.0f + SoulKnight.camera.Y);
                            g.RotateTransform(90);
                            g.TranslateTransform(-(player.posX - 6 + SoulKnight.camera.X + 14), -(player.posY + 44 / 2.0F + SoulKnight.camera.Y));
                        }
                    }
                    else if (player.flip == -1)
                    {
                        if (id != 6 && id != 5)
                        {
                            g.TranslateTransform(player.posX + 6 + SoulKnight.camera.X + 14, player.posY + 66 / 2.0f + SoulKnight.camera.Y);
                            g.RotateTransform(-90);
                            g.TranslateTransform(-(player.posX - 6 + SoulKnight.camera.X + 14), -(player.posY + 50 / 2.0F + SoulKnight.camera.Y));
                        }
                        if (id==6)
                        {
                            g.TranslateTransform(player.posX - 3 + SoulKnight.camera.X + 14, player.posY + 70 / 2.0f + SoulKnight.camera.Y);
                            g.RotateTransform(-90);
                            g.TranslateTransform(-(player.posX - 6 + SoulKnight.camera.X + 14), -(player.posY + 44 / 2.0F + SoulKnight.camera.Y));
                        }
                        if (id == 5)
                        {
                            g.TranslateTransform(player.posX - 2 + SoulKnight.camera.X + 14, player.posY + 72 / 2.0f + SoulKnight.camera.Y);
                            g.RotateTransform(-90);
                            g.TranslateTransform(-(player.posX - 6 + SoulKnight.camera.X + 14), -(player.posY + 44 / 2.0F + SoulKnight.camera.Y));
                        }
                    }
                }
            }
        }

        public void WeaponsMove(List<Weapons> weapons, Entity.Entity player)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                if (!weapons[i].isDropped)
                {
                    if (id == 1)
                    {
                        posXforHit = (int)player.posX;
                        posYforHit = (int)player.posY;
                    }
                    if ((id == 2) || (id == 3) || (id == 5))
                    {
                        posXforHit = ((int)posX - player.flip * 22 / 2 + 14 + (int)player.posX - (int)posX + SoulKnight.camera.X);
                        posYforHit = ((int)posY - 3 - player.curFrame + (int)player.posY - (int)posY + SoulKnight.camera.Y);
                    }
                }
            }
        }

        public void DrawWeaponInHands(Graphics g, Entity.Entity player)
        {
            if (id == 1 && !isDropped)
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip * 18 / 2 + 14) + (int)player.posX - (int)posX + SoulKnight.camera.X, (int)posY - 1 - player.curFrame + (int)player.posY - (int)posY + SoulKnight.camera.Y), new Size(player.flip * 6, 30)), 0, 0, 6, 30, GraphicsUnit.Pixel);

            if (id == 2 && !isDropped)
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip * 22 / 2 + 14) + (int)player.posX - (int)posX + SoulKnight.camera.X, (int)posY - 3 - player.curFrame + (int)player.posY - (int)posY + SoulKnight.camera.Y), new Size(player.flip * 12, 30)), 0, 0, 12, 30, GraphicsUnit.Pixel);

            if (id == 3 && !isDropped)
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip * 22 / 2 + 14) + (int)player.posX - (int)posX + SoulKnight.camera.X, (int)posY - 3 - player.curFrame + (int)player.posY - (int)posY + SoulKnight.camera.Y), new Size(player.flip * 12, 30)), 0, 0, 12, 30, GraphicsUnit.Pixel);

            if (id == 4 && !isDropped)
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip * 22 / 2 + 14) + (int)player.posX - (int)posX + SoulKnight.camera.X, (int)posY - 2 - player.curFrame + (int)player.posY - (int)posY + SoulKnight.camera.Y), new Size(player.flip * 10, 30)), 0, 0, 10, 30, GraphicsUnit.Pixel);

            if (id == 5 && !isDropped)
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip * 18 / 2 + 14) + (int)player.posX - (int)posX + SoulKnight.camera.X  , (int)posY + 8 -  player.curFrame + (int)player.posY - (int)posY + SoulKnight.camera.Y), new Size(player.flip * 9, 21)), 0, 0, 9, 21, GraphicsUnit.Pixel);

            if (id == 6 && !isDropped)
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX - player.flip * 18 / 2 + 14) + (int)player.posX - (int)posX + SoulKnight.camera.X, (int)posY - 4 + (int)player.posY - (int)posY + SoulKnight.camera.Y), new Size(player.flip * 11, 37)), 0, 0, 11, 37, GraphicsUnit.Pixel);
        }

        public void DrawWeapon(Graphics g, Entity.Entity player)
        {
            if (id == 1 && isDropped)
                g.DrawImage(weaponSheet, new Rectangle(new Point(((int)posX) + SoulKnight.camera.X, (int)posY - player.curFrame + SoulKnight.camera.Y), new Size(6, 30)), 0, 0, 6, 30, GraphicsUnit.Pixel);

            if ((id == 2 || id == 3) && isDropped)
                g.DrawImage(weaponSheet, new Rectangle(new Point((int)posX + SoulKnight.camera.X, (int)posY - player.curFrame + SoulKnight.camera.Y), new Size(12, 30)), 0, 0, 12, 30, GraphicsUnit.Pixel);

            if (id == 4 && isDropped)
                g.DrawImage(weaponSheet, new Rectangle(new Point((int)posX + SoulKnight.camera.X, (int)posY - player.curFrame + SoulKnight.camera.Y), new Size(10,30)), 0, 0, 10, 30, GraphicsUnit.Pixel);

            if (id == 5 && isDropped )
                g.DrawImage(weaponSheet, new Rectangle(new Point((int)posX + SoulKnight.camera.X, (int)posY - player.curFrame + SoulKnight.camera.Y), new Size(9, 21)), 0, 0, 9, 21, GraphicsUnit.Pixel);

            if (id == 6 && isDropped)
                g.DrawImage(weaponSheet, new Rectangle(new Point((int)posX + SoulKnight.camera.X, (int)posY - player.curFrame + SoulKnight.camera.Y), new Size(10,37)), 0, 0, 10, 37, GraphicsUnit.Pixel);
        }

        public void HitEnemies(List<Enemies.Enemies> enemies, List<Weapons> weapons, Entity.Entity player)
        {
            for (int wp = 0; wp < weapons.Count; wp++)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    double distance1 = SoulKnight.GetDistance(weapons[wp].posXforHit, weapons[wp].posYforHit, enemies[i].posX, enemies[i].posY);
                    if (distance1 < 15 && player.hitPressed)
                    {
                        if (player.posX >= enemies[i].posX)
                        {
                            enemies[i].posX -= 10;
                            DamageEnemies(enemies, player, i);
                        }
                        else if (player.posX <= enemies[i].posX)
                        {
                            enemies[i].posX += 10;
                            DamageEnemies(enemies, player, i);
                        }
                        else if (player.posY >= enemies[i].posY)
                        {
                            enemies[i].posY -= 10;
                            DamageEnemies(enemies, player, i);
                        }
                        else if (player.posY <= enemies[i].posY)
                        {
                            enemies[i].posY += 10;
                            DamageEnemies(enemies, player, i);
                        }   
                    }
                }
            }
        }

        private static void DamageEnemies(List<Enemies.Enemies> enemies, Entity.Entity player, int i)
        {
            if (enemies[i].HP >= 0)
            {
                if (player.id == 1)
                    enemies[i].HP -= 20;
                if (player.id == 2)
                    enemies[i].HP -= 150;
                if (player.id == 3)
                    enemies[i].HP -= 40;
                if (player.id == 4)
                    enemies[i].HP -= 50;
                if (player.id == 5)
                    enemies[i].HP -= 20;
                if (player.id == 6)
                    enemies[i].HP -= 70;
            }

            else if (enemies[i].HP <= 0)
            {
                if (enemies[i].id != 10)
                {
                    player.SetAnimationConfiguration(0);
                    if (SoulKnight.newBossIndex != 0)
                        SoulKnight.newBossIndex--;
                    enemies.RemoveAt(i);
                }
            }
        }
    }
}