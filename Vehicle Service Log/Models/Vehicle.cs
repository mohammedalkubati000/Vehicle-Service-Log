using System.ComponentModel.DataAnnotations;

namespace Vehicle_Service_Log.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "حقل الشركة المصنعة مطلوب")]
        [Display(Name = "الشركة المصنعة (Make)")]
        

        public string Make { get; set; }
        [Required(ErrorMessage = "حقل الموديل مطلوب")]
        [Display(Name = "الموديل (Model)")]

        public string Model { get; set; }
        [Required(ErrorMessage = "حقل سنة الصنع مطلوب")]
        [Display(Name = "سنة الصنع")]
        [Range(1900, 2100, ErrorMessage = "الرجاء إدخال سنة منطقية")]

        public int Year { get; set; }
        [Required(ErrorMessage = "حقل رقم اللوحة مطلوب")]
        [Display(Name = "رقم اللوحة")]

        public string LicensePlate { get; set; }
        [Display(Name = "قراءة العداد الحالية (كم)")]
        [Range(0, 2000000, ErrorMessage = "الرجاء إدخال قراءة عداد صحيحة")]

        public int CurrentOdometer { get; set; }

    }
}
