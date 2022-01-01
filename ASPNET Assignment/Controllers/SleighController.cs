using System.Data;

using Databaskonstruktion.Models;

using Microsoft.AspNetCore.Mvc;

namespace Databaskonstruktion.Controllers {
	public class SleighController : Controller {
		public IActionResult Index ()
		{
			SleighModel sleighModel = new SleighModel();

			ViewBag.SleighTable = sleighModel.GetTable();

			ErrorManager.WriteError(ViewBag);

			return View();
		}

		public IActionResult SelectSleigh (string sleighNr)
		{
			SleighModel sleighModel = new SleighModel();
			RegionModel regionModel = new RegionModel();

			if (int.TryParse(sleighNr, out int nr)) {
				ViewBag.SelectedSleigh = (sleighModel.GetSleigh(nr) as DataTable).Rows[0];
				ViewBag.RegionTable = regionModel.GetTable();
			} else {
				ErrorManager.SetError("The value of 'sleighNr' is NOT A NUMBER!");
			}

			ErrorManager.WriteError(ViewBag);

			return View();
		}

		public IActionResult MoveSleigh (string sleighNr, string regionCode, string submit)
		{
			if (submit.Equals("OK")) {
				SleighModel sleighModel = new SleighModel();

				if (int.TryParse(sleighNr, out int nr) && int.TryParse(regionCode, out int code)) {
					sleighModel.MoveSleigh(nr, code);
				} else {
					ErrorManager.SetError("The value of 'sleighNr' or 'regionCode' is NOT A NUMBER!");
				}

				return RedirectToAction("SelectSleigh", new { sleighNr = sleighNr });
			}

			return RedirectToAction("Index");
		}
	}
}
