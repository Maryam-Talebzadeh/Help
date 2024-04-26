﻿using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.ServiceAgg.Entities
{
    public class Comment : BaseEntity
    {
        public Comment(string message, Int16 score, long parentId, long helpRequestId, long applicantId, long expertId)
        {
            Message = message; 
            Score = score; 
            ParentId = parentId;
            IsConfirmed = false;
            HelpRequestId = helpRequestId;
            ApplicantId = applicantId;
            ExpertId = expertId;
        }

        public long HelpRequestId { get; private set; }
        public long ApplicantId { get; private set; }
        public long ExpertId { get; private set; }
        public string Message { get; private set; }
        public bool IsConfirmed { get; private set; }
        public Int16 Score { get; private set; }
        public long ParentId { get; private set; }

        #region Navigation Properties

        public HelpRequest HelpRequest { get; private set; }
        public Comment Parent { get; private set; }

        #endregion

        public void Edit(string message, Int16 score)
        {
            Message = message;
            Score = score;
        }

    }
}