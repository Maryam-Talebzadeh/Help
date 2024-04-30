﻿using Base_Framework.Domain.Core.Entities;
using Help.Domain.Core.AccountAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Entities
{
    public class Proposal : BaseEntity
    {
        public Proposal(string? description, DateTime suggestedTime, double suggestedPrice, long helpRequestId, long customerId)
        {
            Description = description; 
            SuggestedPrice = suggestedPrice;
            SuggestedTime = suggestedTime;
            HelpRequestId = helpRequestId;
            CustomerId = customerId;
            IsConfirmed = false;
        }

        public string Description { get; private set; }
        public DateTime SuggestedTime { get; private set; }
        public double SuggestedPrice { get; private set; }
        public bool IsConfirmed { get; private set; }
        public long HelpRequestId { get; private set; }
        public long CustomerId { get; private set; }

        #region Navigation Properties

        public HelpRequest HelpRequest { get; private set; }
        public Customer Customer { get; private set; }

        #endregion

        public void Edit(string description, DateTime suggestedTime, double suggestedPrice)
        {
            Description = description;
            SuggestedPrice = suggestedPrice;
            SuggestedTime = suggestedTime;
            IsConfirmed = false;
        }

        public void Confirm()
        {
            IsConfirmed = true;
        }
    }
}
