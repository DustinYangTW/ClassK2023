using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyView.Models
{
    public class NightMarket
    {
        [RegularExpression("[ABCM][0-9]{2}",ErrorMessage ="請輸入正確格式")]
        [Required(ErrorMessage ="必填")]
        [DisplayName("夜市編號")]
        public string Id { get; set; }


        [StringLength(30,ErrorMessage ="最多30字")]
        [Required(ErrorMessage = "必填")]
        [DisplayName("夜市名稱")]
        public string Name { get; set; }


        [StringLength(50, ErrorMessage = "最多50字")]
        [Required(ErrorMessage = "必填")]
        [DisplayName("夜市所在地址")]
        public string Address { get; set; }
    }
}
