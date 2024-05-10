using Base_Framework.Domain.Services;
using Microsoft.Extensions.Logging;
using System;


namespace Base_Framework.LogError
{
    public interface IOperationResultLogging
    {
        Task LogOperationResult(OperationResult operation, string methodName, string methodNameSpace, CancellationToken cancellationToken);
    }

    public class OperationResultLogging : IOperationResultLogging
    {
        private readonly ILogger _logger;

        public OperationResultLogging(ILogger logger)
        {
            
        }

        public async Task LogOperationResult(OperationResult operation, string methodName, string methodNameSpace, CancellationToken cancellationToken)
        {
            _logger.LogError("OperationResult Exception occurred :{Message} {RecordReferenceType} {RecordReferenceId} {MethodName} {MethodNameSpace}", operation.Message, operation.RecordReferenceType, operation.RecordReferenceId, methodName, methodNameSpace);
        }
    }
}
