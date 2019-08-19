namespace Hr_Management_final_api.Domain.Resources
{
    public class TaskedResource
    {//represents a Task containing only its name.
        public int Id { get; set; }
        public string Name { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }

    }
}