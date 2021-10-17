using CoreWebAppDeploy1.Models;
using CoreWebAppDeploy1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAppDeploy1.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;
        private readonly IConfiguration _iconfiguration;
        public CourseController(CourseService courseService,IConfiguration configuration)
        {
            _courseService = courseService;
            _iconfiguration = configuration;
        }
        public IActionResult Index()
        {
            IEnumerable<Course> crslist = _courseService.GetCourses(_iconfiguration.GetConnectionString("SqlConnection"));
            return View(crslist);
        }
    }
}
