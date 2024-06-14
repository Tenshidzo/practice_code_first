using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_code_first.models
{
    public class Library
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LibraryId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
