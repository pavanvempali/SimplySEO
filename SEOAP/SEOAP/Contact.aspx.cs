using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;

namespace SEOAP
{
	public partial class Contact : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{
			using (WebClient client = new WebClient())
			{
				client.Headers["User-Agent"] =
					"Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";


				client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

				Stream data = client.OpenRead("https://www.google.com/search?sxsrf=ALeKk02MxIsGrMhkx8gMqYVZLQktxDYyBg%3A1615188576229&source=hp&ei=YNJFYMe7C4HB3LUP77OckA0&iflsig=AINFCbYAAAAAYEXgcO7yvrOKWpgdMFhlKS7tcqqoHiTH&q=" + TxtSearch.Text +"&oq="+ TxtSearch.Text+"&gs_lcp=Cgdnd3Mtd2l6EAMyBAgjECcyBAgAEEMyBAgAEEMyCggAEIcCELEDEBQyBAgAEEMyDQgAEIcCELEDEIMBEBQyBAgAEEMyBQgAELEDMggIABCxAxCDATICCAA6BQgAEJECOgsIABCxAxCDARCLAzoKCAAQsQMQgwEQQzoHCAAQsQMQQ1DWClj1EmDJFGgAcAB4AIAB7gGIAdENkgEFMC43LjKYAQCgAQGqAQdnd3Mtd2l6uAEC&sclient=gws-wiz&ved=0ahUKEwjH69CqlqDvAhWBILcAHe8ZB9IQ4dUDCAo&uact=5");
				StreamReader reader = new StreamReader(data);
				string s = reader.ReadToEnd();
				int counter = 0;
				if (s.Contains("moneysmart"))
				{
					counter++;
				}
				Response.Write(s.ToString());

				data.Close();
				reader.Close();

			}
		}
	}
}