namespace BIL.Custom_exceptions
{
    public class HotelListIsEmptyExeption : Exception
    {
        public HotelListIsEmptyExeption() => throw new HotelListIsEmptyExeption("ERROR: List of hotels is empty. In order to create/remove/view data, first create at least one hotel.");

        public HotelListIsEmptyExeption(string message): base(String.Format($"{message}\n")) {}

        public HotelListIsEmptyExeption(string message, Exception inner): base(message, inner) {}
    }
}
