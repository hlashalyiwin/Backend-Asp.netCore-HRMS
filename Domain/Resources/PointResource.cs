namespace Hr_Management_final_api.Domain.Resources
{
    public class PointResource
    {//represents a Point containing only its name.
        public int? Id { get; set;}

          public string Name {get;set;}
          public int? Price {get;set;}
          public string Remark {get;set;}
    }
}