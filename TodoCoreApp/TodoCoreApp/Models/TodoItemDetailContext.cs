using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoCoreApp.Models
{
    public class TodoItemDetailContext : DbContext
    {
        public TodoItemDetailContext(DbContextOptions<TodoItemDetailContext> options)
            : base(options)
        {

        }

        public DbSet<TodoItemDetail> TodoItemDetails { get; set; }
    }
}
