namespace Entities.Models
{
    public class ShapedEntity
    {
        public int Id { get; set; }
        public Entity Entity { get; set; }

        public ShapedEntity()
        {
            Entity = new Entity();
        }
    }
}