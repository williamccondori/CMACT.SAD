﻿using System.Web;
using System.Web.Mvc;

namespace CMACT.SAD.Distribucion.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}