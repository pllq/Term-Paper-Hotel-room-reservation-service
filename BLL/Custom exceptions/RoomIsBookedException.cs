namespace BLL.Custom_exceptions
{
    public class RoomIsBookedException : Exception
    {
        public RoomIsBookedException() => throw new RoomIsBookedException("ERROR: The room, you have chosen, is already booked by someone.");
        
        public RoomIsBookedException(string message): base(String.Format($"{message}\n")) {}

        public RoomIsBookedException(string message, Exception inner): base(message, inner) {}
    }
}
