using System.Drawing;

namespace SoulKnight
{
    public class Hearts
    {
        public Image heartsImage;
        public int posX, posY, curLimit, curFrame, curState, fullHearts, i;
        public float currentAnimation;

        public Hearts(int posX, int posY, int fullHearts, int curState, Image heartsImage)
        {
            this.posX = posX;
            this.posY = posY;
            this.heartsImage = heartsImage;
            this.fullHearts = fullHearts;
            curLimit = fullHearts;
            currentAnimation = 0;
            curFrame = 0;
        }

        public void DrawHearts(Graphics g, Entity.Entity entity)
        {
            if (curFrame < curLimit - 1)
                curFrame++;
            else
            {
                if (entity.countDamage > 0 && !entity.dead )
                    if (entity.countDamage % 5 == 0)
                        currentAnimation = entity.ih;

                else if (entity.HP < 1000 && entity.collideDead)
                    currentAnimation = 0;

                curFrame = 5;
            }
            g.DrawImage(heartsImage, new Rectangle(new Point(posX ,posY ), new Size(350, 30)), 0, 16*currentAnimation, 200, 17, GraphicsUnit.Pixel);
        }

        public void SetAnimation(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 0:
                    curLimit = fullHearts;
                    break;
                case 1:
                    curLimit = curState;
                    break;
            }
        }
    }
}