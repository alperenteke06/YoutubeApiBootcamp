﻿using Microsoft.AspNetCore.Mvc;

namespace YoutubeApiBootcamp.WebUI.ViewComponents
{
	public class _FooterDefaultComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
