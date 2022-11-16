namespace BIL.Custom_exceptions
{
    public class HotelListIsEmptyExeption : Exception
    {
        public HotelListIsEmptyExeption() => throw new HotelListIsEmptyExeption("List of hotels is empty. In order to remove/view data, first create at least one hotel.");

        public HotelListIsEmptyExeption(string message): base(String.Format($"{message}\n")) {}

        public HotelListIsEmptyExeption(string message, Exception inner): base(message, inner) {}
    }
}
