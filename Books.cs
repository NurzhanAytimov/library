using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks
{
    public class Books
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }


        public Books() { }
    }
   
}
