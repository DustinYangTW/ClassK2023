namespace MyView.Models
{
    /// <summary>
    /// 可以當成模型來做處理，這種通常都稱為DataModel
    /// 會有一些規則可以做資料驗證
    /// </summary>
    public class NightMarket
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}
