﻿using System.Web;
using System.Web.Mvc;

namespace Front_Office
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());           
        }
    }
}
