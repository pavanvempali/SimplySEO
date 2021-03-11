using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;

namespace SimplySEO.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SearchController : ControllerBase
	{
		private string strUrl;
		const string BING = "bing";
		const string GOOGLE = "google";
		readonly string URL = "www.sympli.com.au";

		//Open the search based on parameters get results and count the parameter occurance in the search result
		private int GetSEOData(string searchParam, string searchEngine)
		{
			switch (searchEngine.ToLower())
			{
				case GOOGLE:
					strUrl = "https://www.google.com.au/search?sxsrf=ALeKk02MxIsGrMhkx8gMqYVZLQktxDYyBg%3A1615188576229&source=hp&ei=YNJFYMe7C4HB3LUP77OckA0&iflsig=AINFCbYAAAAAYEXgcO7yvrOKWpgdMFhlKS7tcqqoHiTH&q=" + searchParam + "&oq=" + searchParam + "portfolio&gs_lcp=Cgdnd3Mtd2l6EAMyBAgjECcyBAgAEEMyBAgAEEMyCggAEIcCELEDEBQyBAgAEEMyDQgAEIcCELEDEIMBEBQyBAgAEEMyBQgAELEDMggIABCxAxCDATICCAA6BQgAEJECOgsIABCxAxCDARCLAzoKCAAQsQMQgwEQQzoHCAAQsQMQQ1DWClj1EmDJFGgAcAB4AIAB7gGIAdENkgEFMC43LjKYAQCgAQGqAQdnd3Mtd2l6uAEC&sclient=gws-wiz&ved=0ahUKEwjH69CqlqDvAhWBILcAHe8ZB9IQ4dUDCAo&uact=5";
					break;
				case BING:
					strUrl = "https://www.bing.com/search?q="+searchParam+ "&qs=HS&sk=HS1&sc=7-0&cvid=0F30A48CA49A4C3EBAD6FA8036BE80E5&FORM=QBLH&sp=2";
					break;
				default:
					break;

			}

			// Create web client simulating browser
			using (WebClient client = new WebClient())
			{
				int count = 0;
				Stream data;
				StreamReader reader;
				try
				{
					client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
					data = client.OpenRead(strUrl);
					reader = new StreamReader(data);
					string htmlText = reader.ReadToEnd();
					count = Utility.ExtractParagraph(htmlText, URL);
					data.Close();
					reader.Close();
				}
				catch (Exception ex)
				{
					throw (ex.InnerException);
				}
				if (count > 0) count /= 2;
				return count;
			}
		}

		// GET api/search
		[HttpGet]	
		public string Get()
		{
			return "Custom web search server started.......";
		}

		// GET api/searchparam/searchengine
		[HttpGet("{searchparam}/{searchengine}")]
		[ResponseCache(VaryByHeader = "User-Agent", Duration = 3600)] //cache result for 60 minutes
		public ActionResult<int> Get(string searchparam, string searchengine)
		{
			//Do not process when the parameters are empty
			if (searchparam == "" || searchengine == "") return -1;
			return GetSEOData(searchparam, searchengine);
		}

	
	}
}
