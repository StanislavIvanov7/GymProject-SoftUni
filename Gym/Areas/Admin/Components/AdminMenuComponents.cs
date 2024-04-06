using Microsoft.AspNetCore.Mvc;

namespace Gym.Areas.Admin.Components
{
    public class AdminMenuComponents : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }

    }
}
