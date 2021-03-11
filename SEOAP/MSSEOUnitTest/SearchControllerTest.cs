using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimplySEO;
using SimplySEO.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MSSEOUnitTest
{
	[TestClass]
	public class SEOTest
	{
		const string BING = "bing";
		const string GOOGLE = "google";

		[TestMethod]
		public void GET_Check_EmptyParameters()
		{
			SearchController objSearch = new SearchController();
			ActionResult<int> res = objSearch.Get("", "");
			Assert.AreEqual(-1, res.Value);
		}

		[TestMethod]
		public void GET_Check_ReturnType()
		{
			SearchController objSearch = new SearchController();
			ActionResult<int> res = objSearch.Get("", "");
			Assert.IsInstanceOfType(res, typeof(ActionResult<int>));
		}

		[TestMethod]
		public void GET_Found_Results_InTop_Hundred_InGoogle()
		{
			SearchController objSearch = new SearchController();
			ActionResult<int> res = objSearch.Get("e-settlements", GOOGLE);
			Assert.IsTrue(res.Value > 0);
		}

		[TestMethod]
		public void GET_Found_Results_InTop_Hundred_InBing()
		{
			SearchController objSearch = new SearchController();
			ActionResult<int> res = objSearch.Get("e-settlements", BING);
			Assert.IsTrue(res.Value > 0);
		}
	}
}
