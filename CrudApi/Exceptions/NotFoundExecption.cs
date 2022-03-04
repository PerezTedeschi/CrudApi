namespace CrudApi.Exceptions
{
    public class NotFoundExecption : Exception
    {
        public NotFoundExecption()
        {            
        }

        public NotFoundExecption(string message)
            : base(message)
        {
        }

        public NotFoundExecption(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
