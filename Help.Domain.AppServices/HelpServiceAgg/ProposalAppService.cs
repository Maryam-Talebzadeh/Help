﻿using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services;
using Base_Framework.LogError;
using Help.Domain.Core.HelpServiceAgg.AppServices;
using Help.Domain.Core.HelpServiceAgg.DTOs.Proposal;
using Help.Domain.Core.HelpServiceAgg.Services;

namespace Help.Domain.AppServices.HelpServiceAgg
{
    public class ProposalAppService : IProposalAppService
    {
        private readonly IProposalService _proposalService;
        private readonly IHelpRequestService _helpRequestService;
        private readonly IOperationResultLogging _operationResultLogging;
        private readonly IAuthHelper _authHelper;
        private readonly string _nameSpace = typeof(ProposalAppService).Namespace;
        private readonly Type _type = new ProposalDTO().GetType();

        public ProposalAppService(IProposalService proposalService, IOperationResultLogging operationResultLogging, IHelpRequestService helpRequestService, IAuthHelper authHelper)
        {
            _proposalService = proposalService;
            _operationResultLogging = operationResultLogging;
            _helpRequestService = helpRequestService;
            _authHelper = authHelper;
        }

        public async Task<OperationResult> Confirm(int id, int helpRequestId,  CancellationToken cancellationToken)
        {
            OperationResult operation;
            try
            {
                operation =  await _proposalService.Confirm(id, cancellationToken);
                operation = await _helpRequestService.ChangeStatus(helpRequestId,3, cancellationToken);
                return operation;
            }
            catch
            {
                operation = await _proposalService.Confirm(id, cancellationToken);
                operation = await _helpRequestService.ChangeStatus(helpRequestId, 3, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Confirm), _nameSpace, cancellationToken);
                return operation;
            }
        }


        public async Task<OperationResult> Create(CreateProposalDTO command, CancellationToken cancellationToken)
        {
            OperationResult operation = new OperationResult( _type, command.CustomerId);

            if (command.CustomerId == command.HelpRequestCustomerId)
                return operation.Failed("شما نمیتوانید پیشنهادی برای درخواست خودتان ارسال کنید.");

            try
            {
                return await _proposalService.Create(command, cancellationToken);
            }
            catch
            {
                operation = await _proposalService.Create(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Create), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<OperationResult> Edit(EditProposalDTO command, CancellationToken cancellationToken)
        {
            try
            {
                return await _proposalService.Edit(command, cancellationToken);
            }
            catch
            {
                var operation = await _proposalService.Edit(command, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Edit), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<ProposalDTO> GetBy(int helpRequestId, CancellationToken cancellationToken)
        {
            var detail = await _proposalService.GetBy(helpRequestId, cancellationToken);

            if (detail == null)
            {
                var operation = new OperationResult(_type, helpRequestId);
                _operationResultLogging.LogOperationResult(operation, nameof(GetBy), _nameSpace, cancellationToken);
            }

            return detail;

        }

        public async Task<EditProposalDTO> GetDetails(int id, CancellationToken cancellationToken)
        {
            var detail = await _proposalService.GetDetails(id, cancellationToken);

            if (detail == null)
            {
                var operation = new OperationResult(_type, id);
                _operationResultLogging.LogOperationResult(operation, nameof(GetDetails), _nameSpace, cancellationToken);
            }

            return detail;
        }

        public async Task<OperationResult> Reject(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _proposalService.Reject(id, cancellationToken);
            }
            catch
            {
                var operation = await _proposalService.Reject(id, cancellationToken);
                _operationResultLogging.LogOperationResult(operation, nameof(Reject), _nameSpace, cancellationToken);
                return operation;
            }
        }

        public async Task<List<ProposalDTO>> Search(SearchProposaltDTO searchModel, CancellationToken cancellationToken)
        {
            var requests = await _proposalService.Search(searchModel, cancellationToken);

            return requests;
        }

        public async Task<List<ProposalDTO>> SearchUnConfirmed(SearchProposaltDTO searchModel, CancellationToken cancellationToken)
        {
            return await _proposalService.SearchUnConfirmed(searchModel, cancellationToken);
        }
    }
}
