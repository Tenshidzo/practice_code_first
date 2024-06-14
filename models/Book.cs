using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_code_first.models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }

        public bool Available { get; set; }
        [ForeignKey("Library")]
        public int LibraryId { get; set; }
        public Library Library { get; set; } 

        public ICollection<Publication> Publications { get; set; }
    }
}
