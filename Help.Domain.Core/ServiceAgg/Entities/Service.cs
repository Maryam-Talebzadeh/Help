using Base_Framework.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Help.Domain.Core.ServiceAgg.Entities
{
    public class Service : BaseEntity
    {
        public Service(string title, string description, string slug, string keywords)
        {
            Title = title;
            Description = description;
            Slug = slug;
            KeyWords = keywords;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }

        public void Edit(string title, string description, string slug, string keywords)
        {
            Title = title;
            Description = description;
            Slug = slug;
            KeyWords = keywords;
        }
    }
}
