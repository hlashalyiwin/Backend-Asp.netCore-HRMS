using System;
namespace Hr_Management_final_api.Domain.Models 
{
        //table="DutyRosterDetail"
    public class DutyRosterDetail
    {
        //column="DutyRosterDetail_id,description,title,date"
        //primaryKey=DutyRosterDetail_id,foreign key=employee_id,dutyRoster_id
       
        public int? dutyRosterDetail_id{get;set;}
       
        public int? dutyRoster_id{get;set;}

        public DutyRoster DutyRosters {get;set;}
        public int? employee_id{get;set;}
        public Employee Employees {get;set;}
    }
}