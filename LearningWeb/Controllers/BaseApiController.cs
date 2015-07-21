using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eLearning.Repository;
using LearningWeb.Factory;

namespace LearningWeb.Controllers
{
    public class BaseApiController : ApiController
    {
        private ILearningRepository _repo;

        public BaseApiController(ILearningRepository repo)
        {
            _repo = repo;
        }

        protected ILearningRepository TheRepository
        {
            get
            {
                return _repo;
            }
        }

        private ModelFactory _modelFactory;

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(Request);
                }
                return _modelFactory;
            }
        }
    }
}
