using System;

namespace API.Entities
{
    public class Player
    {
        public int PlayerKey { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public int? PositionKey { get; set; }
    }
}