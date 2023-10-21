using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyView.Models
{
    /// <summary>
    /// 可以當成模型來做處理，這種通常都稱為DataModel
    /// 會有一些規則可以做資料驗證
    /// </summary>
    public class NightMarket
    {
        public string? Id { get; set; }
        [DisplayName("夜市名稱123465")]
        public string? Name { get; set; }
        [DisplayName("地址")]
        public string? Address { get; set; }
    }
}
