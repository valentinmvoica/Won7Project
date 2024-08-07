using System.Runtime.Serialization;

namespace Won7Project.Exceptions
{
    [Serializable]
    internal class IdNotFoundException : Exception
    {
        public IdNotFoundException()
        {
        }

        public IdNotFoundException(string? message) : base(message)
        {
        }

        public IdNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected IdNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}