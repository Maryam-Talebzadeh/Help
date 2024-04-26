﻿using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.ServiceAgg.Entities
{
    public class Skill : BaseEntity
    {
        public Skill(string title, string? description, Int16 level, long serviceId, long categoryId)
        {
            Title = title; 
            Description = description; 
            Level = level; 
            ServiceId = serviceId; 
            CategoryId = categoryId;
            
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public Int16 Level { get; private set; }
        public long ServiceId { get; private set; }
        public long CategoryId { get; private set; }

        public void Edit(string title, string description, Int16 level, long serviceId, long categoryId)
        {
            Title = title;
            Description = description;
            Level = level;
            ServiceId = serviceId;
            CategoryId = categoryId;
        }
    }
}