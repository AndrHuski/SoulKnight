using System;
using System.Collections.Generic;
using System.Drawing;

namespace SoulKnight.Enemies
{
    public class Enemies
    {
        public float posX, posY, oldPosX, oldPosY;
        public int sizeid1, sizeid2, sizeid3, sizeid4, sizeid5, sizeid6, sizeid10W, sizeid10H;
        public float EnemySpeedX = 1;
        public float EnemySpeedY = 1;
        public bool isMoving, enemyDead = false;
        public Image mobSheet;
        public int flip, curFrame, curLimit, EnemyIdleFrames, EnemyRunFrames, BossAttack, BossDeath, curAnimation, id, HP;
        
        public Enemies(int posx, int posy, int id, int EnemyIdleFrames, int EnemyRunFrames, Image mobSheet)
        {
            this.id = id;
            oldPosX = posx;
            oldPosY = posy;
            posX = posx;
            posY = posy;
            this.EnemyIdleFrames = EnemyIdleFrames;
            this.EnemyRunFrames = EnemyRunFrames;
            this.mobSheet = mobSheet;
            sizeid1 = 16;
            sizeid2 = 34;
            sizeid3 = 24;
            sizeid4 = 16;
            sizeid5 = 16;
            sizeid6 = 16;

            isMoving = false;
            enemyDead = false;
            curFrame = 0;
            curLimit = EnemyIdleFrames;
            flip = 1;

            if (id == 1)
                HP = 20;
            if (id == 2)
                HP = 110;
            if (id == 3)
                HP = 40;
            if (id == 4)
                HP = 30;
            if (id == 5)
                HP = 20;
            if (id == 6)
                HP = 60;
        }

        public Enemies(int posx, int posy, int id, int BossIdle, int BossRun, int BossAttack, int BossDeath, Image Sheet)
        {
            this.id = id;
            oldPosX = posx;
            oldPosY = posy;
            posX = posx;
            posY = posy;
            EnemyIdleFrames = BossIdle;
            EnemyRunFrames = BossRun;
            this.BossAttack = BossAttack;

            this.BossDeath = BossDeath;
            enemyDead = false;
            mobSheet = Sheet;
            sizeid10W = 97;
            sizeid10H = 97;
            curFrame = 0;
            curLimit = BossIdle;
            flip = 1;
            if (id == 10)
                HP = 1500;
            isMoving = false;
        }

        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

        public void HitPlayer(Entity.Entity player)
        {
            if (!SoulKnight.enemies[SoulKnight.newBossIndex].enemyDead)
            {
                double distance = GetDistance(player.posX, player.posY, posX, posY);
                if (id == 10)
                {
                    if (distance <= 50)
                    {
                        if (player.HP > 0)
                        {
                            SoulKnight.hitPlayer = true;
                            player.countDamage++;
                            player.HP -= 20;
                            player.SetAnimationConfiguration(1);
                            if (player.countDamage % 5 == 0)
                                player.ih++;
                        }
                        else
                        {
                            player.countDamage = 0;
                            player.ih = 0;
                            player.dead = true;
                        }
                    }
                    else
                        SoulKnight.hitPlayer = false;

                    IfPlayerDead(player);
                }

                else
                {
                    if (distance <= 15)
                    {
                        SoulKnight.hitPlayer = true;
                        if (player.HP > 0)
                        {
                            player.countDamage++;
                            player.HP -= 20;
                            player.SetAnimationConfiguration(1);
                            if (player.countDamage % 5 == 0)
                                player.ih++;
                        }
                        else
                        {
                            player.countDamage = 0;
                            player.ih = 0;
                            player.dead = true;
                        }
                    }
                    else
                        SoulKnight.hitPlayer = false;
                }

                IfPlayerDead(player);
            }
        }

        private static void IfPlayerDead(Entity.Entity player)
        {
            if (player.dead)
            {
                player.posX = player.oldPosX;
                player.posY = player.oldPosY;

                if (SoulKnight.newCheckPoint == 0)
                {
                    SoulKnight.camera.X = 0;
                    SoulKnight.camera.Y = 0;
                }
                else if (SoulKnight.newCheckPoint == 1)
                {
                    SoulKnight.camera.X = 0;
                    SoulKnight.camera.Y = -3;
                }
                else if (SoulKnight.newCheckPoint == 2)
                {
                    SoulKnight.camera.X = -165;
                    SoulKnight.camera.Y = -459;
                }
                else if (SoulKnight.newCheckPoint == 3)
                {
                    SoulKnight.camera.X = -3;
                    SoulKnight.camera.Y = -1074;
                }
                else if (SoulKnight.newCheckPoint == 4)
                {
                    SoulKnight.camera.X = -636;
                    SoulKnight.camera.Y = -960;
                }
                SoulKnight.hearts.currentAnimation = 0;
                player.SetAnimationConfiguration(0);
                player.HP = 1000;
                player.ih = 0;
                player.dead = false;
            }
        }

        public void IfEnemiesCollide(List<Enemies> enemies)
        {
            for (int i = 0; i < enemies.Count - 1; i++)
            {
                double distance = GetDistance(enemies[i].posX, enemies[i].posY, enemies[i + 1].posX, enemies[i + 1].posY);
                if (distance <= 20)
                {
                    if (enemies[i].posX < enemies[i + 1].posX)
                        enemies[i + 1].posX += 2;

                    else if (enemies[i].posX > enemies[i + 1].posX)
                        enemies[i + 1].posX -= 2;

                    if (enemies[i].posY < enemies[i + 1].posY)
                        enemies[i + 1].posY -= 2;

                    else if (enemies[i].posY > enemies[i + 1].posY)
                        enemies[i + 1].posY += 2;
                }
            }
        }

        public void FlipEnemies(Entity.Entity player,List<Enemies>enemies)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                double distance = GetDistance((double)player.posX, (double)player.posY, (double)enemies[i].posX, (double)enemies[i].posY);
                if (enemies[i].isMoving)
                {
                    if (enemies[i].id != 10)
                    {
                        if (distance <= 30)
                        {
                            FlipEnemies(player, enemies, i);

                            if (distance <= 15)
                                SoulKnight.hitPlayer = true;
                        }
                        else
                            FlipEnemies(player, enemies, i);
                    }

                    else
                    {
                        if (distance <= 100)
                        {
                            player.speed = 4;
                            FlipEnemies(player, enemies, i);

                            if (distance <= 50)
                                SoulKnight.hitPlayer = true;
                        }
                        else
                        {
                            player.speed = 3;
                            FlipEnemies(player, enemies, i);
                        }
                    }
                }
            }
        }

        private static void FlipEnemies(Entity.Entity player, List<Enemies> enemies, int i)
        {
            if (player.posX < enemies[i].posX)
                enemies[i].flip = -1;

            if (player.posX > enemies[i].posX)
                enemies[i].flip = 1;
        }

        public void PlayerMove(Entity.Entity player)
        {
            if (!SoulKnight.enemies[SoulKnight.newBossIndex].enemyDead)
            {
                double distance = GetDistance((double)player.posX, (double)player.posY, (double)posX, (double)posY);

                if (id != 10)
                {
                    if (distance <= 30)
                    {
                        if (isMoving)
                            SetEnemyAnimationConfiguration(1);
                        else
                            SetEnemyAnimationConfiguration(0);

                        ReturnEnemiesAwayFromHero(player);
                    }
                    else
                        MoveEnemies();
                }
                else
                {
                    if (distance <= 100)
                    {
                        if (isMoving)
                        {
                            SetEnemyAnimationConfiguration(1);
                            if (SoulKnight.hitPlayer)
                                SetEnemyAnimationConfiguration(6);
                        }
                        else
                        {
                            SetEnemyAnimationConfiguration(0);
                            if (SoulKnight.hitPlayer)
                                SetEnemyAnimationConfiguration(6);
                        }

                        ReturnEnemiesAwayFromHero(player);
                    }
                    else
                        MoveEnemies();
                }
            }
            
            if (SoulKnight.enemies[SoulKnight.newBossIndex].enemyDead)
            {
                SoulKnight.enemies[SoulKnight.newBossIndex].SetEnemyAnimationConfiguration(9);
                SoulKnight.enemies[SoulKnight.newBossIndex].isMoving = false;
                SoulKnight.hitPlayer = false;
            }
        }

        private void ReturnEnemiesAwayFromHero(Entity.Entity player)
        {
            if (player.posX > posX)
                posX += EnemySpeedX;
            else
                posX -= EnemySpeedX;

            if (player.posY > posY)
                posY += EnemySpeedY;
            else
                posY -= EnemySpeedY;
        }

        private void MoveEnemies()
        {
            if (isMoving)
                SetEnemyAnimationConfiguration(1);
            else
                SetEnemyAnimationConfiguration(0);

            if (posX < oldPosX)
                posX += EnemySpeedX;
            else
                posX -= EnemySpeedX;

            if (posY < oldPosY)
                posY += EnemySpeedY;
            else
                posY -= EnemySpeedY;
        }

        public void PlayEnemyAnimation(Graphics g)
        {
            if (id != 10 )
            {
                if (curFrame < curLimit - 1)
                    curFrame++;
                else
                    curFrame = 0;
            }
            else
            {
                if (curAnimation == 9)
                {
                    if (curFrame < curLimit - 1)
                        curFrame++;
                    else
                        curFrame = 5;
                }
                else
                {
                    if (curFrame < curLimit - 2)
                        curFrame++;
                    else
                        curFrame = 0;
                }
            }
            if (id == 1)
                g.DrawImage(mobSheet, new Rectangle(new Point((int)posX - flip * sizeid1 / 2 + SoulKnight.camera.X+14, (int)posY + SoulKnight.camera.Y + 5), new Size(flip * sizeid1, sizeid1)), 16 * curFrame,  curAnimation, sizeid1, sizeid1, GraphicsUnit.Pixel);
            
            if (id == 2)
                g.DrawImage(mobSheet, new Rectangle(new Point((int)posX - flip * sizeid2 / 2 + SoulKnight.camera.X+14, (int)posY + SoulKnight.camera.Y + 5), new Size(flip * sizeid2, sizeid2)), 32 * curFrame, 40 * curAnimation, sizeid2, sizeid2, GraphicsUnit.Pixel);

            if(id == 3)
                g.DrawImage(mobSheet, new Rectangle(new Point((int)posX - flip * 24 / 2 + SoulKnight.camera.X + 14, (int)posY + SoulKnight.camera.Y + 5), new Size(flip * 24, 29)),20 * curFrame,29* curAnimation, 24, 29, GraphicsUnit.Pixel);

            if(id == 4)
                g.DrawImage(mobSheet, new Rectangle(new Point((int)posX - flip * sizeid4 / 2 + SoulKnight.camera.X + 14, (int)posY + SoulKnight.camera.Y + 5), new Size(flip * 21, 33)), 16 * curFrame,  curAnimation, 21, 33, GraphicsUnit.Pixel);

            if(id == 5)
                g.DrawImage(mobSheet, new Rectangle(new Point((int)posX - flip * 21 / 2 + SoulKnight.camera.X + 14, (int)posY + SoulKnight.camera.Y + 5), new Size(flip * 23, 30)), 20 * curFrame, 30 * curAnimation, 23, 30, GraphicsUnit.Pixel);

            if(id == 6)
                g.DrawImage(mobSheet, new Rectangle(new Point((int)posX - flip * 32 / 2 + SoulKnight.camera.X + 14, (int)posY + SoulKnight.camera.Y + 5), new Size(flip * 32, 33)), 31 * curFrame, 50 * curAnimation, 32, 33, GraphicsUnit.Pixel);

            if(id == 10)
                g.DrawImage(mobSheet, new Rectangle(new Point((int)posX - flip * sizeid10W / 2 + SoulKnight.camera.X +14, (int)posY -30 + SoulKnight.camera.Y + 5), new Size(flip * sizeid10W, sizeid10H)), 95 * curFrame, 95 * curAnimation, sizeid10W, sizeid10H, GraphicsUnit.Pixel);
        }

        public void SetEnemyAnimationConfiguration(int currentAnimation)
        {
            this.curAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 0:
                    curLimit = EnemyIdleFrames;
                    break;
                case 1:
                    curLimit = EnemyRunFrames;
                    break;
                case 6:
                    curLimit = BossAttack;
                    break;
                case 9:
                    curLimit = BossDeath;
                    break;
            }
        }
    }
}