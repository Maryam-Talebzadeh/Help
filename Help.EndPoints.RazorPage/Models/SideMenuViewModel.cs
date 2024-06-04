using Help.Domain.Core.AccountAgg.DTOs.CustomerPicture;

namespace Help.EndPoints.RazorPage.Models
{
    public class SideMenuViewModel
    {
        public CustomerPictureDTO Picture { get; set; }
        public Int16 RateAsExpert { get; set; }
        public Int16 RateAsRequester { get; set; }
    }
}
