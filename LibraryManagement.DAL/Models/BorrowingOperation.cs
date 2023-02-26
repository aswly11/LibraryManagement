using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.Models
{
    public class BorrowingOperation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BorrowingOperationId { get; set; }
        public DateTime BorrowingStartDate { get; set; }
        public DateTime BorrowingEndDate { get; set; }


        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }


        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}
