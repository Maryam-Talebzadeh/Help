using Base_Framework.Domain.Core.Entities;

namespace Base_Framework.Domain.Services
{
    public class OperationResult
    {
        public OperationResult(Type recordReferenceType, int recordReferenceId)
        {
            IsSuccedded = false;
            RecordReferenceType = recordReferenceType;
            RecordReferenceId = recordReferenceId;
        }

        public bool IsSuccedded { get; set; }
        public string Message { get; set; }
        public Type RecordReferenceType { get; set; }
        public int RecordReferenceId { get; set; }

        public OperationResult Succedded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSuccedded = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message)
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }
    
}
}
