using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.Models.DTOs
{
    public class BorrowingOperationDTO
    {
        public int BorrowingOperationId { get; set; }
        public DateTime BorrowingStartDate { get; set; }
        public DateTime BorrowingEndDate { get; set; }
        public int BookId { get; set; }
        public int ClientId { get; set; }
    }
}
