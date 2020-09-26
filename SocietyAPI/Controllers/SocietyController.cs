using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SocietyAPI.Global;
using SocietyAPI.Models;
using SocietyAPI.Repository;

namespace SocietyAPI.Controllers
{
    public class SocietyController : ApiController
    {
        HttpResponseMessage Response = new HttpResponseMessage();
        SocietyRepository objSocietyRepo = new SocietyRepository();

        [HttpPost]
        public HttpResponseMessage AddSociety(AddSocietyCustomModel objSociety)
        {
            DataResult<AddSocietyCustomModel> Result = new DataResult<AddSocietyCustomModel>();
            Result = objSocietyRepo.AddSociety(objSociety);
            Response = Request.CreateResponse<DataResult<AddSocietyCustomModel>>(HttpStatusCode.Created, Result);
            return Response;
        }

        [HttpGet]
        public HttpResponseMessage GetSociety()
        {
            DataResult<SP_GetSociety_Result> Result = new DataResult<SP_GetSociety_Result>();
            Result = objSocietyRepo.GetSociety();
            Response = Request.CreateResponse<DataResult<SP_GetSociety_Result>>(HttpStatusCode.Created, Result);
            return Response;
        }
    }
}
