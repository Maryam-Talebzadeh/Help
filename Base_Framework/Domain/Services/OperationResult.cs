

namespace Base_Framework.Domain.Services
{
    public class OperationResult<T>
    {
        public OperationResult(T obj)
        {
            IsSuccedded = false;
            OperationReference = obj;
        }

        public bool IsSuccedded { get; set; }
        public string Message { get; set; }
        public T OperationReference { get; set; }

        public OperationResult<T> Succedded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSuccedded = true;
            Message = message;
            return this;
        }

        public OperationResult<T> Failed(string message)
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }
    }
}
