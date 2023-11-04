using Microsoft.EntityFrameworkCore;

namespace MyModel_CodeFirst.Models
{
    public class GuestBookContext : DbContext
    {
        //6.1.3 將步驟1.2.4在dbStudentsContext中所寫的空建構子註解掉(也可留著只是用不到)
        public GuestBookContext(DbContextOptions<GuestBookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<ReBook> ReBook { get; set; }
    }
}
