﻿using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.ServiceAgg.Entities
{
    public class ServicePicture : BaseEntity
    {
        public ServicePicture(string name, string title, string alt, long serviceId)
        {
            Name = name; 
            Title = title; 
            Alt = alt; 
            ServiceId = serviceId;
        }

        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Alt { get; private set; }
        public long ServiceId { get; private set; }

        public void Edit(string name, string title, string alt)
        {
            Name = name;
            Title = title;
            Alt = alt;
        }
    }
}