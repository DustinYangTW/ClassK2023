using Microsoft.EntityFrameworkCore;

namespace MyModel_CodeFirst.Models
{
    //1.3.2 撰寫SeedData類別的內容
    public class SeedData
    {
        //(1)撰寫靜態方法 Initialize(IServiceProvider serviceProvider)
        //這個寫法是固定的，主要是寫入預設的資料
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (
                var context = new GuestBookContext(serviceProvider.GetRequiredService<DbContextOptions<GuestBookContext>>())
                )
            {

                if (!context.Book.Any()) //必須在資料庫全是空的狀態下才建立種子資料
                {
                    //(2)撰寫Book及ReBook資料表內的初始資料程式
                    context.Book.AddRange(
                        new Book
                        {
                            Title = "櫻桃鴨",
                            Description = "這看起來好好吃哦!!!",
                            Photo = getFileBytes("SeedSourcePhoto/1.JPG"),
                            ImageType = "image/jpeg",
                            Author = "Jack",
                            TimeStamp = DateTime.Now
                        },
                       new Book
                       {
                           Title = "鴨油高麗菜",
                           Description = "好像稍微有點油....",
                           Photo = getFileBytes("SeedSourcePhoto/2.JPG"),
                           ImageType = "image/jpeg",
                           Author = "Mary",
                           TimeStamp = DateTime.Now
                       },
                       new Book
                       {
                           Title = "鴨油麻婆豆腐",
                           Description = "這太下飯了！可以吃好幾碗白飯",
                           Photo = getFileBytes("SeedSourcePhoto/3.jpg"),
                           ImageType = "image/jpeg",
                           Author = "王小花",
                           TimeStamp = DateTime.Now
                       },
                       new Book
                       {
                           Title = "櫻桃鴨握壽司",
                           Description = "握壽司就是好吃！",
                           Photo = getFileBytes("SeedSourcePhoto/4.jpg"),
                           ImageType = "image/jpeg",
                           Author = "王小花",
                           TimeStamp = DateTime.Now
                       },
                       new Book
                       {
                           Title = "三杯鴨",
                           Description = "鴨肉鮮甜",
                           Photo = getFileBytes("SeedSourcePhoto/5.jpg"),
                           ImageType = "image/jpeg",
                           Author = "Jack",
                           TimeStamp = DateTime.Now
                       }

                    );
                    context.SaveChanges();

                    context.ReBook.AddRange(
                        new ReBook
                        {
                            Description = "我也覺得好吃！",
                            Author = "小蘭",
                            TimeStamp = DateTime.Now,
                            GId = 1
                        },
                       new ReBook
                       {
                           Description = "我不喜歡....",
                           Author = "柯南",
                           TimeStamp = DateTime.Now,
                           GId = 1
                       },
                       new ReBook
                       {
                           Description = "你最好餓死",
                           Author = "小蘭",
                           TimeStamp = DateTime.Now,
                           GId = 1
                       },
                       new ReBook
                       {
                           Description = "高麗菜這樣超好吃啊～",
                           Author = "小英",
                           TimeStamp = DateTime.Now,
                           GId = 2
                       },
                       new ReBook
                       {
                           Description = "口味似乎偏辣",
                           Author = "阿狗",
                           TimeStamp = DateTime.Now,
                           GId = 3
                       },
                       new ReBook
                       {
                           Description = "我還是喜歡生魚片的握壽司",
                           Author = "嫩嫩",
                           TimeStamp = DateTime.Now,
                           GId = 4
                       },
                       new ReBook
                       {
                           Description = "我也是喜歡生魚片的握壽司，但這個也不錯",
                           Author = "王小花",
                           TimeStamp = DateTime.Now,
                           GId = 4
                       },
                       new ReBook
                       {
                           Description = "三杯雞比較對味",
                           Author = "芷若",
                           TimeStamp = DateTime.Now,
                           GId = 5
                       });
                    context.SaveChanges();


                }


            }
            // (3)撰寫getFileBytes，功能為將照片轉成二進位資料

            byte[] getFileBytes(string path)
            {   //開啟檔案的照片
                FileStream fileOnDisk = new FileStream(path, FileMode.Open);

                byte[] fileBytes;
                //讀取相關資料的方法
                using (BinaryReader br = new BinaryReader(fileOnDisk))
                {
                    //把讀到Byte存入陣列裡面
                    fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                }

                return fileBytes;


            }


        }

    }
}
