using System;
using System.ComponentModel.DataAnnotations;

namespace Hr_Management_final_api.Domain.Resources
{
    //represents a announcement containing only its name
    public class AnnouncementResource
    {
        [Required]
        public int? id {get;set;}
        public string description{get;set;}
        public string title{get;set;}
        public string date{get;set;}
    }
}