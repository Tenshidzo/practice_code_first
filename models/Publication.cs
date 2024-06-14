using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_code_first.models
{
    public class Publication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IssueId { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; } // Навигационное свойство

        public string ReaderName { get; set; }
        public DateTime IssueTime { get; set; }
        public DateTime? ReturnTime { get; set; }
    }
}
