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
    public class LoginController : ApiController
    {
        HttpResponseMessage Response = new HttpResponseMessage();
        LoginRepository objLoginRepo = new LoginRepository();

        [HttpGet]
        [Route("Api/Login/CheckLogin/{userName}/{password}/{societyId}")]
        public HttpResponseMessage CheckLogin(string userName, string password,string societyId)
        {
            DataResult<MembersDetail> Result = new DataResult<MembersDetail>();
            Result = objLoginRepo.CheckLogin(userName, password, societyId);
            Response = Request.CreateResponse<DataResult<MembersDetail>>(HttpStatusCode.Created, Result);
            return Response;
        }
    }
}
