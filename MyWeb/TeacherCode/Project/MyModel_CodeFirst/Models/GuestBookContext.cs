using Microsoft.EntityFrameworkCore;

//1.2.2 撰寫GuestBookContext類別的內容
namespace MyModel_CodeFirst.Models
{
    //(1)須繼承DbContext類別
    public class GuestBookContext:DbContext
    {
        //(2)撰寫建構子(使用依賴注入DI)
        public GuestBookContext(DbContextOptions<GuestBookContext> options)
       : base(options)
        {
        }

        //(3)描述資料庫裡面的資料表
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<ReBook> ReBook { get; set; }

    }
}
