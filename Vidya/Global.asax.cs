using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Vidya.App_Start;
using Vidya.Dtos;
using Vidya.Models;

namespace Vidya
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // Register Automapper
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<CustomerDto, Customer>();
                cfg.CreateMap<Video, VideoDto>();
                cfg.CreateMap<VideoDto, Video>();
                cfg.CreateMap<MembershipType, MembershipTypeDto>();
                cfg.CreateMap<MembershipTypeDto, MembershipType>();
            });

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
