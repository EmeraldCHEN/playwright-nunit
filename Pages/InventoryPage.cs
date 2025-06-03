using Microsoft.Playwright;
using System.Threading.Tasks;

namespace playwright_nunit.pages
{
    public class InventoryPage
    {
        private readonly IPage _page;

        public InventoryPage(IPage page)
        {
            _page = page;
        }

        private ILocator InventoryList => _page.Locator(".inventory_list");

        public async Task<bool> IsLoadedAsync()
        {
            return await InventoryList.IsVisibleAsync();
        }
    }
}
