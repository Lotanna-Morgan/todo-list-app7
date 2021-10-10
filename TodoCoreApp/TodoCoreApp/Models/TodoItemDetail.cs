using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoCoreApp.Models
{
    public class TodoItemDetail
    {
        [Key]
        public int TodoItemId { get; set; }

        [Column(TypeName = "nvarchar(70)")]
        public string TodoItemTitle { get; set; }

        [Column(TypeName = "nvarchar(170)")]
        public string TodoItemDescription { get; set; }

        [Column(TypeName = "bit")]
        public bool IsCompleted { get; set; }
    }
}
