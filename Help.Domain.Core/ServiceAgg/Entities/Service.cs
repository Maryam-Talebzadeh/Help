using Base_Framework.Domain.Core.Entities;

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
        public long PictureId { get; private set; }


        #region Navigation Properties

        public List<ServiceCategory> Categories { get; private set; }
        public List<Skill> Skills { get; private set; }
        public List<HelpRequest> HelpRequests { get; private set; }
        public ServicePicture Picture { get; private set; }

        #endregion

        public void Edit(string title, string description, string slug, string keywords)
        {
            Title = title;
            Description = description;
            Slug = slug;
            KeyWords = keywords;
        }
    }
}
