namespace Hr_Management_final_api.Domain.Resource
{
    public class RoleResource
    {//represents a Role containing only its name.
       public int Role_Id { get; set; }
        public string Name { get; set; }
         public string Priority { get; set; }
         public string Salary_range {get; set; }
    }
}