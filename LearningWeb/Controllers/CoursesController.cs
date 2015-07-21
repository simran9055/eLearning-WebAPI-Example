using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eLearning.Context;
using eLearning.Entities;
using eLearning.Repository;
using LearningWeb.Models;

namespace LearningWeb.Controllers
{
    public class CoursesController : BaseApiController
    {
        public CoursesController(ILearningRepository repo)
            : base(repo)
        {
        }

        public IEnumerable<CourseModel> Get()
        {
            IQueryable<Course> query;

            query = TheRepository.GetAllCourses();

            var results = query
            .ToList()
            .Select(s => TheModelFactory.Create(s));

            return results;
        }

        public HttpResponseMessage GetCourse(int id)
        {
            try
            {
                var course = TheRepository.GetCourse(id);
                if (course != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(course));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
