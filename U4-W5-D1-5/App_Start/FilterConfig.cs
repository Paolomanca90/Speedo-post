﻿using System.Web;
using System.Web.Mvc;

namespace U4_W5_D1_5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
