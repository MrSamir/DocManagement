using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.Service.Models
{
    public class Mapping
    {

        public int MappingID { get; set; }
        [Required]
        public int DocumentID { get; set; }
        [Required]
        public int KeywordID { get; set; }

        public string? DocumentName { get; set; }
        public string? KeywordName { get; set; }
    }
}
