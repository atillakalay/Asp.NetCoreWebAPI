using System.Text.Json;

namespace Entities.LogModel
{
    public class LodDetails
    {
        public Object? ModelModel { get; set; }
        public Object? Controller { get; set; }
        public Object? Action { get; set; }
        public Object? Id { get; set; }
        public Object? CreateAt { get; set; }


        public LodDetails()
        {
            CreateAt = DateTime.UtcNow;
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
