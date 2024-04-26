﻿using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.ServiceAgg.Entities
{
    public class Proposal : BaseEntity
    {
        public Proposal(string description, DateTime suggestedTime, double suggestedPrice, long helpRequestId, long providerId)
        {
            Description = description; 
            SuggestedPrice = suggestedPrice;
            SuggestedTime = suggestedTime;
            HelpRequestId = helpRequestId; 
            ProviderId = providerId;
            IsConfirmed = false;
        }

        public string Description { get; private set; }
        public DateTime SuggestedTime { get; private set; }
        public double SuggestedPrice { get; private set; }
        public bool IsConfirmed { get; private set; }
        public long HelpRequestId { get; private set; }
        public long ProviderId { get; private set; }

        public void Edit(string description, DateTime suggestedTime, double suggestedPrice)
        {
            Description = description;
            SuggestedPrice = suggestedPrice;
            SuggestedTime = suggestedTime;
        }

        public void Confirm()
        {
            IsConfirmed = true;
        }
    }
}