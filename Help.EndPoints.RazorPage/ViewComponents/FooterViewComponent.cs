using Microsoft.AspNetCore.Mvc;

namespace Help.EndPoints.RazorPage.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
