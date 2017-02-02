using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace handling_projects.Models
{
    [Serializable]
    public class UserProfileSessionData
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string NameSurname { get; set; }
       
    }
}