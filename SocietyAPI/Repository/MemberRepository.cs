using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocietyAPI.Global;
using SocietyAPI.Models;

namespace SocietyAPI.Repository
{
    public class MemberRepository
    {
        GlobalFunction Gb = new GlobalFunction();

        public DataResult<MembersDetail> AddMember(MembersDetail objMembersDetail)
        {
            DataResult<MembersDetail> Result = new DataResult<MembersDetail>();
            try
            {
                using (var db = new SocietyDBEntities())
                {
                    MembersDetail objMemberExists = db.MembersDetails.Where(x => x.flatNo == objMembersDetail.flatNo && x.societyId == objMembersDetail.societyId && x.isDeleted == false).FirstOrDefault();

                    if (objMemberExists == null)
                    {
                        MembersDetail objMemberUsernameExist = db.MembersDetails.Where(x => x.userName == objMembersDetail.userName).FirstOrDefault();

                        if (objMemberUsernameExist == null)
                        {
                            if (objMembersDetail.memberType != "SC")
                            {
                                DataResult<NumRange> ResultMemberID = Gb.GetNumRange("MB");

                                if (ResultMemberID.MsgType == "S")
                                {
                                    objMembersDetail.memberId = ResultMemberID.StringResult;
                                }
                                else
                                {
                                    Result.Message = ResultMemberID.Message;
                                    Result.MsgType = "E";
                                    return Result;
                                }
                            }
                            objMembersDetail.createdDate = DateTime.Now;
                            objMembersDetail.isDeleted = false;
                            db.MembersDetails.Add(objMembersDetail);
                            db.SaveChanges();

                            Result.Message = "Data Saved Successfully.";
                            Result.MsgType = "S";
                        }
                        else
                        {
                            Result.Message = "Username Already Exists.";
                            Result.MsgType = "E";
                        }
                    }
                    else
                    {
                        Result.Message = "This Flat Is Owned By Another Member.";
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

        public DataResult<MembersDetail> GetAllMember(string societyId)
        {
            DataResult<MembersDetail> Result = new DataResult<MembersDetail>();
            using (var db = new SocietyDBEntities())
            {
                List<MembersDetail> objMembers = db.MembersDetails.Where(x => x.societyId == societyId).ToList();

                if (objMembers.Count > 0)
                {
                    Result.Message = "Data Viewed Successfully";
                    Result.MsgType = "S";
                    Result.Data = objMembers;
                }
                else
                {
                    Result.Message = "No Members in This Society.";
                    Result.MsgType = "E";
                }
            }

            return Result;
        }

        public DataResult<MembersDetail> GetMyProfile(string societyId, string MemberId)
        {
            DataResult<MembersDetail> Result = new DataResult<MembersDetail>();
            using (var db = new SocietyDBEntities())
            {
                MembersDetail objMembers = db.MembersDetails.Where(x => x.societyId == societyId && x.memberId == MemberId).FirstOrDefault();

                if (objMembers != null)
                {
                    List<MembersDetail> ObjMemberDetailsList = new List<MembersDetail>();
                    ObjMemberDetailsList.Add(objMembers);
                    Result.Data = ObjMemberDetailsList;
                    Result.Message = "Data Viewed Successfully";
                    Result.MsgType = "S";
                }
                else
                {
                    Result.Message = "Member Not Found.";
                    Result.MsgType = "E";
                }
            }

            return Result;
        }

        public DataResult<MembersDetail> UpdatePassword(MembersDetail objMembersDetail)
        {
            DataResult<MembersDetail> Result = new DataResult<MembersDetail>();

            try
            {
                using (var db = new SocietyDBEntities())
                {
                    //var transaction = db.Database.BeginTransaction();
                    MembersDetail objMember = db.MembersDetails.Where(x => x.memberId == objMembersDetail.memberId && x.societyId == objMembersDetail.societyId).FirstOrDefault();

                    if(objMember!=null)
                    {
                        objMember.password = objMembersDetail.password;
                        db.Entry(objMember).State = System.Data.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        Result.Message = "Member Not Found.";
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

        public DataResult<MembersDetail> UpdateMobile(MembersDetail objMembersDetail)
        {
            DataResult<MembersDetail> Result = new DataResult<MembersDetail>();

            try
            {
                using (var db = new SocietyDBEntities())
                {
                    //var transaction = db.Database.BeginTransaction();
                    MembersDetail objMember = db.MembersDetails.Where(x => x.memberId == objMembersDetail.memberId && x.societyId == objMembersDetail.societyId).FirstOrDefault();

                    if (objMember != null)
                    {
                        objMember.mobileNo = objMembersDetail.mobileNo;
                        db.Entry(objMember).State = System.Data.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        Result.Message = "Member Not Found.";
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

        public DataResult<MembersDetail> UpdateEmail(MembersDetail objMembersDetail)
        {
            DataResult<MembersDetail> Result = new DataResult<MembersDetail>();

            try
            {
                using (var db = new SocietyDBEntities())
                {
                    //var transaction = db.Database.BeginTransaction();
                    MembersDetail objMember = db.MembersDetails.Where(x => x.memberId == objMembersDetail.memberId && x.societyId == objMembersDetail.societyId).FirstOrDefault();

                    if (objMember != null)
                    {
                        objMember.email = objMembersDetail.email;
                        db.Entry(objMember).State = System.Data.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        Result.Message = "Member Not Found.";
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
    }
}