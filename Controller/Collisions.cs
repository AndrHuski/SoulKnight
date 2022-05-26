namespace SoulKnight.Controllers
{
    public class Collisions
    {
        public static void Collision(Entity.Entity entity)
        {
            for (int j = (int)entity.posX / MapControllers.cellSize; j < (entity.posX - 15 + MapControllers.cellSize) / MapControllers.cellSize; j++)
                for (int i = (int)entity.posY / MapControllers.cellSize; i < (entity.posY - 3 + MapControllers.cellSize) / MapControllers.cellSize; i++)
                {
                    if (MapControllers.map[i, j] == 0)
                    {
                        SoulKnight.collide = true;
                        entity.collideDead = true;
                        entity.countDamage = 0; 
                    }
                    else
                    {
                        entity.isMove = true;
                        SoulKnight.collide = false;
                        entity.collideDead = false;
                    }
                }
        }
    }
}