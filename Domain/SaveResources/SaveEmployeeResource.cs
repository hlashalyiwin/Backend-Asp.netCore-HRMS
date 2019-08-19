using System;

namespace Hr_Management_final_api.Domain.SaveResources
{
    public class SaveEmployeeResource
    {
      public string employee_No{get;set;}
      public string employee_Name{get;set;}
      public  string email{get;set;}
      public DateTime dob{get;set;}

      public string nrc{get;set;}

      public string phone_no_work {get;set;}
      public string phone_no_personal{get;set;}

      public string gender{get;set;}

      public string marital_status{get;set;}
      public string nationality{get;set;}
      public string religion{get;set;}

      public string permanent_address{get;set;}

      public string education_background{get;set;}
      public DateTime joined_date{get;set;}
      public string employee_state{get;set;}
       public int? addressId{get;set;}
    }
}