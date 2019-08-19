//Created by Sai Nay Lynn
//Created date is 21.6.2019

using System;
using System.Collections.Generic;

namespace  Hr_Management_final_api.Domain.Models{
    //Tasked class
    public class Tasked {
        //column=id,Name,Start_Time,End_Time,Status,Remark
        //Primary key=id
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }

        public IList<Performance> performance { get; set; }=new List<Performance>();
    }
}