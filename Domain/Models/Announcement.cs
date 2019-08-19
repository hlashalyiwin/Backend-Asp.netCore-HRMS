using System;
using System.Collections.Generic;

namespace Hr_Management_final_api.Domain.Models
{   //table name=Announcement
    public class Announcement
    {
        //announcement(id , description , title , date) 
        //primaryKey=id
        //colum count=4
        public int? id {get;set;}
        public string description{get;set;}
        public string title{get;set;}
        public DateTime date{get;set;}
        public IList<CV_Form> CV_Forms { get; set; } = new List<CV_Form>();
    }
}