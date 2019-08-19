using System;
using System.Collections.Generic;
using Hr_Management_final_api.Domain.Models;
using Hr_Management_final_api.Domain.ENumType;
namespace Hr_Management_final_api.Domain.SaveResources
{
    //represents a attendence containing only its name.
    public class SaveAttendenceResource
    {
        
        public DateTime date{get;set;}
        public DateTime start_time{get;set;}
        public DateTime end_time { get;set; }

        //EAttendenceType is enum class type
        public EAttendenceType attendenceType{get;set;}
        public string remark{get;set;} 
    }
}