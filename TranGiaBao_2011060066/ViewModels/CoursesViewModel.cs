using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranGiaBao_2011060066.Models;

namespace TranGiaBao_2011060066.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}