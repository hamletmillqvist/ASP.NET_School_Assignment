
using Databaskonstrukltion;

using Databaskonstruktion.Models;

using Microsoft.AspNetCore.Mvc;

namespace Databaskonstruktion.Controllers {
	public class WishlistController : Controller {
		public IActionResult Index ()
		{
			WishModel wishModel = new WishModel();
			ViewBag.WishlistTable = wishModel.GetTable();

			ErrorManager.WriteError(ViewBag);
			return View();
		}

		public IActionResult SetAdmitted (string wishId, string wishYear, string admitStr)
		{
			wishId = StringSanitizer.Sanitize(wishId);
			wishYear = StringSanitizer.Sanitize(wishYear);
			admitStr = StringSanitizer.Sanitize(admitStr);

			admitStr = (admitStr == "Admit" ? "1" : (admitStr == "Deny" ? "0" : null));

			if (admitStr != null) {
				WishModel wishModel = new WishModel();
				wishModel.SetAdmitted(wishId, wishYear, admitStr);
			} else {
				ErrorManager.SetError("Invalid argument passed to 'SetAdmitted' in WishlistController.");
			}

			return RedirectToAction("Index");
		}
	}
}
