
using Databaskonstrukltion;

using Databaskonstruktion.Models;

using Microsoft.AspNetCore.Mvc;

namespace Databaskonstruktion.Controllers {
	public class ChildController : Controller {
		private static string _searchText = null;

		public IActionResult Index ()
		{
			ChildModel childModel = new ChildModel();
			ViewBag.ChildTable = childModel.GetTable(_searchText);
			ViewBag.SearchText = _searchText ?? "";

			ErrorManager.WriteError(ViewBag);

			return View();
		}

		public IActionResult LimitBySearch (string searchText)
		{
			_searchText = StringSanitizer.Sanitize(searchText);
			return RedirectToAction("Index");
		}
	}
}
