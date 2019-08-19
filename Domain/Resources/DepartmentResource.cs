namespace Hr_Management_final_api.Domain.Resources
{//create view table = DepartmentResource
    public class DepartmentResource
    {
      //columns name for view table=dept_id,dept_name,priority,branch_id,phone_no,remark
        public int? dept_id{get;set;}
        public string dept_name{get;set;}
        public string priority{get;set;}

        public string phone_no {get;set;}

        public string remark {get;set;} 
          public int? branch_id{get;set;}

        public BranchResource Branches{get;set;}  
    }
}