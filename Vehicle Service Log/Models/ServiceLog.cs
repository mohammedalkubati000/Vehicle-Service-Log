using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Service_Log.Models
{
    public class ServiceLog
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "حقل نوع الخدمة مطلوب")]
        [Display(Name = "نوع الخدمة / الصيانة")]
        public decimal Cost { get; set; }
        [Required(ErrorMessage = "حقل التاريخ مطلوب")]
        [Display(Name = "تاريخ الخدمة")]

        public DateTime ServiceDate { get; set; }
        [Display(Name = "ملاحظات إضافية")]

        public string Notes { get; set; }
        [Required]
        [Display(Name = "السيارة")]

        public int VehicleId { get; set; }
        [ForeignKey("VehicleId")]

        public string ServiceType { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}
