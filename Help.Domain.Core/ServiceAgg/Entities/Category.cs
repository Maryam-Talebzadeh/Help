﻿using Base_Framework.Domain.Core.Entities;

namespace Help.Domain.Core.ServiceAgg.Entities
{
    public class Category : BaseEntity
    {
        public Category(string title, string description, long parentId)
        {
            Title = title;
            Description = description;
            ParentId = parentId;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public long ParentId { get; private set; }

        #region Navigation Properties

        public List<ServiceCategory> Services { get; private set; }
        public Category Parent { get; private set; }
        public List<Category> Children { get; private set; }

        #endregion

        public void Edit(string title, string description, long parentId)
        {
            Title = title;
            Description = description;
            ParentId = parentId;
        }
    }
}
