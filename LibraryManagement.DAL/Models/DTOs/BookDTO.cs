using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.Models.DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public bool IsBorrowed { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public DateTime DateOfPublish { get; set; }
    }
}
