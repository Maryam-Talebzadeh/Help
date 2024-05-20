using Microsoft.AspNetCore.Mvc;

namespace Help.EndPoints.RazorPage.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public MenuViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
