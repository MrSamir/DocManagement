using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.Service.Models
{

    //Just public inside my class library (Internal)
    public class Keyword
    {


        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
