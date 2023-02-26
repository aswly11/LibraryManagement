using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.Models
{
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<Book> Books { get; set;} = new List<Book>();
    }
}
