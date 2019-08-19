//Developed by Nang Ah: Mon(Lashio)
//Edited By NiNiWinMay(28.6.2019)


namespace Hr_Management_final_api.Domain.Models{
    public class Product_Performance
    {//column=id,attendence_id,unit_d,finished_goods,dutyRoster_id
    //primary key=id,foreign key=attendence_id,duty_Roster_id
        public int id{get; set;}
        
        public int attendence_id{get; set;}
        public Attendence Attendence {get; set; }
        public int unit_id{get; set;}
        public Point Point { get; set; }
        public string finished_goods{get; set;}

        public int duty_roster_id{get; set;}
        public DutyRoster DutyRoster {get; set;}
        
    }
}