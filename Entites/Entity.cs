using System.Drawing;

namespace SoulKnight.Entity
{
    public class Entity
    {
        public float posX, posY, oldPosX, oldPosY, countDamage, X, Y;
        public int HP, playerSpeed;
        public float speed = 3;
        public bool isMove, hitPressed, dead, collideDead;
        public int flip, curAnimation, curFrame, curLimit;
        public int idleFrames, runFrames, attackFrames, deathFrames, redFrames;
        public int size;
        public float height;
        public Image spriteSheet;
        public bool isFreeHands = true;
        public int id, ih;
   
        public Entity(float posX,float posY,int IdleFrames,int runFrames,int attackFrames,int deathFrames,int RedFrames,Image spriteSheet)
        {
            HP = 1000;
            this.oldPosX = posX;
            this.oldPosY = posY;
            this.posX = posX;
            this.posY = posY;
            this.idleFrames = IdleFrames;
            this.runFrames = runFrames;
            this.attackFrames = attackFrames;
            this.deathFrames = deathFrames;
            this.spriteSheet = spriteSheet;
            this.redFrames = RedFrames;
            size = 31;
            curAnimation = 0;
            curFrame = 0;
            curLimit = IdleFrames;
            flip = 1;
            playerSpeed = 3;
            dead = false;
            collideDead = false;
        }

        public void Move()
        {
            if (SoulKnight.Apressed || SoulKnight.Dpressed)
                posX += X;
            if (SoulKnight.Wpressed || SoulKnight.Spressed)
                posY += Y;
        }

        public void PlayAnimation(Graphics g)
        {
            if (curFrame < curLimit - 3)
                curFrame++;
            else
                curFrame = 0;
            
           g.DrawImage(spriteSheet, new Rectangle(new Point((int)posX - flip * size / 2 + SoulKnight.camera.X + 14, (int)posY + SoulKnight.camera.Y), new Size(flip * size, size)), 26 * curFrame, 32 * curAnimation, size, size, GraphicsUnit.Pixel);
        }

        public void SetAnimationConfiguration(int currentAnimation)
        {
            this.curAnimation = currentAnimation;

            switch(currentAnimation)
            {
                case 0:
                    if (isMove)
                        curLimit = runFrames;
                    else
                        curLimit = idleFrames;
                    break;
                case 1:
                    curLimit = redFrames;
                    break;
            }
        }
    }
}