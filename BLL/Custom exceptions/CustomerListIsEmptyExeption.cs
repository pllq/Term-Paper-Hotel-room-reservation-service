namespace BLL.Custom_exceptions
{
    public class CustomerListIsEmptyExeption : Exception
    {
        public CustomerListIsEmptyExeption() => throw new CustomerListIsEmptyExeption("ERROR: List of customers is empty. In order to create/remove/view data, first create at least one customer.");
            
        public CustomerListIsEmptyExeption(string message): base(String.Format($"{message}\n")) {}

        public CustomerListIsEmptyExeption(string message, Exception inner): base(message, inner){}
    }
}
