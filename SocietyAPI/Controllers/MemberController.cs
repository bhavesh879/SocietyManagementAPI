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
    public class MemberController : ApiController
    {
        HttpResponseMessage Response = new HttpResponseMessage();        
        MemberRepository objMemberRepo = new MemberRepository();

        [HttpPost]
        public HttpResponseMessage AddMember(MembersDetail objMembersDetail)
        {
            DataResult<MembersDetail> Result = new DataResult<MembersDetail>();
            Result = objMemberRepo.AddMember(objMembersDetail);
            Response = Request.CreateResponse<DataResult<MembersDetail>>(HttpStatusCode.Created, Result);
            return Response;
        }

        [HttpGet]
        [Route("Api/Member/GetAllMember/{societyId}")]
        public HttpResponseMessage GetAllMember(string societyId)
        {
            DataResult<MembersDetail> Result = new DataResult<MembersDetail>();
            Result = objMemberRepo.GetAllMember(societyId);
            Response = Request.CreateResponse<DataResult<MembersDetail>>(HttpStatusCode.Created, Result);
            return Response;
        }

        [HttpGet]
        [Route("Api/Member/GetMyProfile/{societyId}/{memberId}")]
        public HttpResponseMessage GetMyProfile(string societyId, string memberId)
        {
            DataResult<MembersDetail> Result = new DataResult<MembersDetail>();
            Result = objMemberRepo.GetMyProfile(societyId, memberId);
            Response = Request.CreateResponse<DataResult<MembersDetail>>(HttpStatusCode.Created, Result);
            return Response;
        }

        [HttpPost]
        public HttpResponseMessage UpdatePassword(MembersDetail objMembersDetail)
        {
            DataResult<MembersDetail> Result = new DataResult<MembersDetail>();
            Result = objMemberRepo.UpdatePassword(objMembersDetail);
            Response = Request.CreateResponse<DataResult<MembersDetail>>(HttpStatusCode.Created, Result);
            return Response;
        }

        [HttpPost]
        public HttpResponseMessage UpdateMobile(MembersDetail objMembersDetail)
        {
            DataResult<MembersDetail> Result = new DataResult<MembersDetail>();
            Result = objMemberRepo.UpdateMobile(objMembersDetail);
            Response = Request.CreateResponse<DataResult<MembersDetail>>(HttpStatusCode.Created, Result);
            return Response;
        }

        [HttpPost]
        public HttpResponseMessage UpdateEmail(MembersDetail objMembersDetail)
        {
            DataResult<MembersDetail> Result = new DataResult<MembersDetail>();
            Result = objMemberRepo.UpdateEmail(objMembersDetail);
            Response = Request.CreateResponse<DataResult<MembersDetail>>(HttpStatusCode.Created, Result);
            return Response;
        }
    }
}
