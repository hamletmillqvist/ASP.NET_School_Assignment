using Databaskonstrukltion;

using Databaskonstruktion.Models;

using Microsoft.AspNetCore.Mvc;

namespace Databaskonstruktion.Controllers {
	public class BannedWordsController : Controller {
		public IActionResult Index (string deletedWord = "")
		{
			BannedWordsModel bannedWordsModel = new BannedWordsModel();
			ViewBag.BannedWordsTable = bannedWordsModel.GetTable();

			if (!string.IsNullOrEmpty(deletedWord)) {
				ViewBag.PopupMessage = "Successfully removed the ban on: " + deletedWord;
			} else {
				ViewBag.PopupMessage = "";
			}

			ErrorManager.WriteError(ViewBag);
			return View();
		}

		public IActionResult LiftBan (string word)
		{
			word = StringSanitizer.Sanitize(word);

			BannedWordsModel bannedWordsModel = new BannedWordsModel();
			if (bannedWordsModel.DeleteBannedWord(word) > 0) {
				return RedirectToAction("Index", new { deletedWord = word });
			} else {
				ErrorManager.SetError("No such word exists!");
				return RedirectToAction("Index");
			}
		}
	}
}
