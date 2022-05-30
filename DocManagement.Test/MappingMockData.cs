using DocManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.Test
{
    public class MappingMockData
    {
        public static Mapping newMapping()
        {
            return new Mapping
            {
                MappingID=1,
                DocumentID = 1,
                KeywordID = 1
            };
        }

        public static List<Mapping> GetMappings()
        {
            return new List<Mapping>{
             new Mapping{
                MappingID=1,
                DocumentID = 1,
               KeywordID=1
             },
             new Mapping{
                 MappingID=2,
                 DocumentID = 2,
               KeywordID=2
             },
             new Mapping{
                 MappingID=3,
                  DocumentID = 3,
               KeywordID=3
             }
         };
        }
    }
}
