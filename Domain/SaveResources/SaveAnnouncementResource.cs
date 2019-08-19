using System;
using System.ComponentModel.DataAnnotations;

namespace Hr_Management_final_api.Domain.SaveResources
{
    //represents a attendence containing only its name.
    public class SaveAnnouncementResource
    {
         [Required]
        public string description{get;set;}
        public string title{get;set;}
        public DateTime date{get;set;}
    }
}