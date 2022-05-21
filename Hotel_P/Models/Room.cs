namespace Hotel_P.Models
{
    public class Room
    {

        public int Id { get; set; }
        public bool free { get; set; }
        public string room_type { get; set; }
        public int capacity { get; set; }
        public int floor { get; set; }
        public Room()
        {

        }

    }
}
