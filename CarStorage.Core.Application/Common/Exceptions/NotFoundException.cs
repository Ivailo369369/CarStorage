namespace CarStorage.Core.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(object key)
            :base($"Object with ({key}) does not exist.")
            => Error = base.Message;

        public string Error { get; set; }
    }
}
