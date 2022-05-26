using SoulKnight.Entity;
using System.Drawing;

namespace SoulKnight.Staff
{
    public class Staff
    {
        public Image StaffSprite;
        public int posX;
        public int posY;
        public int openFrames;
        public int staffIdle;
        public int currentLimit;
        public int currentFrame;
        public int currentAnimation;
        public bool isOpened;
        public int id;

        public Staff(int posx,int posy,int ID,int chestIdle,int openFrames,Image chestSprite)
        {
            isOpened = false;
            posX = posx;
            posY = posy;
            id = ID;
            this.openFrames = openFrames;
            StaffSprite = chestSprite;
            currentFrame = 0;
            this.staffIdle = chestIdle;
            currentLimit = chestIdle;
        }

        public Staff(int posx,int posy,int ID,Image chestSprite)
        {
            posX = posx;
            posY = posy;
            id = ID;
            StaffSprite = chestSprite;
        }
        
        public void PlayFlask(Graphics g, Entity.Entity player)
        {
            g.DrawImage(StaffSprite, new Rectangle(new Point(((int)posX) + SoulKnight.camera.X, (int)posY - player.curFrame +SoulKnight.camera.Y), new Size(32, 32)), 0, 0, 32, 32, GraphicsUnit.Pixel);
        }
    }
}
