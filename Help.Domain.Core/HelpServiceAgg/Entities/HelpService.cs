using Base_Framework.Domain.Core.Entities;
using Help.Domain.Core.AccountAgg.Entities;

namespace Help.Domain.Core.HelpServiceAgg.Entities
{
    public class HelpService : BaseEntity
    {
        public HelpService(string title, string description, string slug, string tags, int categoryId, int pictureId)
        {
            Title = title;
            Description = description;
            Slug = slug;
            Tags = tags;
            CategoryId = categoryId;
            PictureId = pictureId;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Slug { get; private set; }
        public int PictureId { get; private set; }
        public string Tags { get; private set; }
        public int CategoryId { get; set; }


        #region Navigation Properties

        public Category Category { get; private set; }
        public List<Skill>? Skills { get; private set; }
        public List<HelpRequest> HelpRequests { get; private set; }
        public HelpServicePicture Picture { get; private set; }

        #endregion

        public void Edit(string title, string description, string slug, string tags)
        {
            Title = title;
            Description = description;
            Slug = slug;
            Tags = tags;
        }
    }
}
