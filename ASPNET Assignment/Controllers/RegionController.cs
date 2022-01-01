
using Databaskonstrukltion;

using Databaskonstruktion.Models;

using Microsoft.AspNetCore.Mvc;

namespace Databaskonstruktion.Controllers {
	public class RegionController : Controller {
		private static bool _showInsertRegion = false;

		public IActionResult Index ()
		{
			RegionModel regionModel = new RegionModel();

			ViewBag.RegionTable = regionModel.GetTable();
			ViewBag.ShowInsertRegion = _showInsertRegion;

			ErrorManager.WriteError(ViewBag);

			return View();
		}

		public IActionResult InsertRegion (string code, string countryName, string climate, string submit)
		{
			if (submit.Equals("OK")) {
				code = StringSanitizer.Sanitize(code);
				countryName = StringSanitizer.Sanitize(countryName);

				if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(countryName) && !string.IsNullOrEmpty(climate)) {
					RegionModel regionModel = new RegionModel();

					if (regionModel.InsertRegion(code, countryName, climate[0]) != 0) {
						_showInsertRegion = false;
					} else {
						ErrorManager.SetError("No rows changed.");
					}
				} else {
					ErrorManager.SetError("One or more fields are empty/invalid!");
				}
			} else {
				_showInsertRegion = false; // Disable "Insert Region" 
			}

			return RedirectToAction("Index");
		}

		public IActionResult ActivateMode_InsertRegion ()
		{
			_showInsertRegion = true;
			return RedirectToAction("Index");
		}
	}
}
