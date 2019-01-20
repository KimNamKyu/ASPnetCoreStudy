
namespace EntitiyFrameworkCore_3_.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Birth { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
