using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocietyAPI.Global;
using SocietyAPI.Models;

namespace SocietyAPI.Global
{
    public class GlobalFunction
    {
        DataResult<NumRange> Result = new DataResult<NumRange>();
        public DataResult<NumRange> GetNumRange(string NumRangeCode)
        {
            try
            {
                using (var db = new SocietyDBEntities())
                {
                    NumRange objNumRange = db.NumRanges.Where(x => x.numRangeCode == NumRangeCode && x.isDeleted==false).FirstOrDefault();

                    if (objNumRange != null)
                    {
                        var NewNumber = objNumRange.currentNumber + 1;

                        if (NewNumber > objNumRange.startNumber && NewNumber < objNumRange.endNumber)
                        {
                            objNumRange.currentNumber = NewNumber;
                            db.Entry(objNumRange).State = System.Data.EntityState.Modified;
                            db.SaveChanges();

                            var NewNumberString = NewNumber.ToString().PadLeft(8, '0');
                            NewNumberString = NumRangeCode + NewNumberString;

                            Result.StringResult = NewNumberString;
                            Result.Message = "NumRange Generated Successfully.";
                            Result.MsgType = "S";
                        }
                        else
                        {
                            Result.Message = "Numrange Exceeds.Kindly Contact Administration.";
                            Result.MsgType = "E";
                        }
                    }
                    else
                    {
                        Result.Message = "Numrange Not Found.Kindly Contact Administration.";
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