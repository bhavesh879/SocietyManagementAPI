using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using SocietyAPI.Global;
using SocietyAPI.Models;

namespace SocietyAPI.Repository
{
    public class SocietyRepository
    {
        //DataResult Result = new DataResult();
        GlobalFunction Gb = new GlobalFunction();

        public DataResult<AddSocietyCustomModel> AddSociety(AddSocietyCustomModel objSociety)
        {
            DataResult<AddSocietyCustomModel> Result = new DataResult<AddSocietyCustomModel>();
            try
            {
                using (var db = new SocietyDBEntities())
                {
                    SocietyDetail objSocetyExists = db.SocietyDetails.Where(x => x.societyCode == objSociety.societyCode).FirstOrDefault();

                    if (objSocetyExists == null)
                    {
                        MembersDetail objMemberUsernameExist = db.MembersDetails.Where(x => x.userName == objSociety.userName).FirstOrDefault();

                        if (objMemberUsernameExist == null)
                        {
                            DataResult<NumRange> ResultSocietyID = Gb.GetNumRange("SC");

                            if (ResultSocietyID.MsgType == "S")
                            {
                                var societyId = ResultSocietyID.StringResult;

                                DataResult<NumRange> ResultMemberID = Gb.GetNumRange("MB");

                                if (ResultMemberID.MsgType == "S")
                                {
                                    var memberId = ResultMemberID.StringResult;
                                    SocietyDetail objSocietyDetail = new SocietyDetail();
                                    objSocietyDetail.societyId = societyId;
                                    objSocietyDetail.societyCode = objSociety.societyCode;
                                    objSocietyDetail.societyName = objSociety.societyName;
                                    objSocietyDetail.secretory = memberId;
                                    objSocietyDetail.address = objSociety.address;
                                    objSocietyDetail.createdBy = objSociety.createdBy;
                                    objSocietyDetail.createdDate = DateTime.Now;
                                    objSocietyDetail.isDeleted = false;
                                    db.SocietyDetails.Add(objSocietyDetail);
                                    db.SaveChanges();

                                    MembersDetail objMembersDetail = new MembersDetail();
                                    objMembersDetail.memberId = memberId;
                                    objMembersDetail.memberName = objSociety.memberName;
                                    objMembersDetail.userName = objSociety.userName;
                                    objMembersDetail.password = objSociety.password;
                                    objMembersDetail.mobileNo = objSociety.mobileNo;
                                    objMembersDetail.memberType = objSociety.memberType;
                                    objMembersDetail.flatNo = objSociety.flatNo;
                                    objMembersDetail.email = objSociety.email;
                                    objMembersDetail.societyId = societyId;
                                    objMembersDetail.createdBy = objSociety.createdBy;

                                    MemberRepository objMemberRepo = new MemberRepository();
                                    DataResult<MembersDetail> ResultMember = objMemberRepo.AddMember(objMembersDetail);

                                    if (ResultMember.MsgType == "S")
                                    {
                                        Result.Message = "Data Saved Successfully.";
                                        Result.MsgType = "S";
                                    }
                                    else
                                    {
                                        Result.Message = ResultMember.Message;
                                        Result.MsgType = "E";
                                        return Result;
                                    }
                                }
                                else
                                {
                                    Result.Message = ResultMemberID.Message;
                                    Result.MsgType = "E";
                                }
                            }
                            else
                            {
                                Result.Message = ResultSocietyID.Message;
                                Result.MsgType = "E";
                            }
                        }
                        else
                        {
                            Result.Message = "Username Already Exists.";
                            Result.MsgType = "E";
                        }
                    }
                    else
                    {
                        Result.Message = "Society Code Already Exists.";
                        Result.MsgType = "E";
                    }
                }
            }
            catch (Exception ex)
            {
                Result.Message = ex.Message;
                Result.MsgType = "E";
            }
            return Result;
        }

        public DataResult<SP_GetSociety_Result> GetSociety()
        {
            DataResult<SP_GetSociety_Result> Result = new DataResult<SP_GetSociety_Result>();
            try
            {
                using (var db = new SocietyDBEntities())
                {
                    List<SP_GetSociety_Result> objSP_GetSociety = db.SP_GetSociety().ToList();

                    string SocietyString = Newtonsoft.Json.JsonConvert.SerializeObject(objSP_GetSociety);

                    Result.Data = objSP_GetSociety;
                    Result.Message = "Data Viewed Succcessfully.";
                    Result.MsgType = "S";
                }
            }
            catch (Exception ex)
            {
                Result.Message = ex.Message;
                Result.MsgType = "E";
            }
            return Result;
        }
    }
}