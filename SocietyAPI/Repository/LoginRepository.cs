using SocietyAPI.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SocietyAPI.Models;

namespace SocietyAPI.Repository
{
    public class LoginRepository
    {
        public DataResult<MembersDetail> CheckLogin(string userName, string password,string societyId)
        {
            DataResult<MembersDetail> Result = new DataResult<MembersDetail>();

            try
            {
                using (var db = new SocietyDBEntities())
                {
                    MembersDetail objMembersDetail = db.MembersDetails.Where(x => x.userName == userName && x.password == password && x.societyId == societyId).FirstOrDefault();
                    
                    if(objMembersDetail !=null)
                    {
                        Result.Message = "Login Successfull.";
                        Result.MsgType = "S";
                    }
                    else
                    {
                        Result.Message = "Incorrect Username/Password.";
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