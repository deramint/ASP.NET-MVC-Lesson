using System.ComponentModel.DataAnnotations;

namespace PersonWebApplication.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20,ErrorMessage = "最大文字数は20文字までです")]
        [Display(Name = "名前")]
        public string Name { get; set; }

        [Range(18,100,ErrorMessage = "年齢は18歳から１００歳までです")]
        [Display(Name = "年齢")]
        [DisplayFormat(DataFormatString = "{0}歳")]
        public int? Age { get; set; }

        [Display(Name = "出身地")]
        public int PerfectureId { get; set; }
        [Display(Name = "出身地")]
        public Perfecture? Perfecture { get; set; }

        [Display(Name = "入社日")]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
        [DataType(DataType.Date)]
        [ValidHireate]
        public DateTime? Hireate { get; set; }

        [Display(Name ="出社状態")]
        public bool IsAttendance { get; set; }

        [Display(Name = "メールアドレス")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "ブログのURL")]
        [Url]
        public string Blog {get; set;}

        [RegularExpression("[A-Z]{3}-[0-9]{4}")]
        [Display(Name = "社員番号")]
        public string EmployeeNo { get; set;}
    }
    //以下記述
    //[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]//サンプルコードにはある
    public class ValidHireate : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime date = Convert.ToDateTime(value);
                if(date > DateTime.Now)
                {
                    return new ValidationResult("入社日は本日以前を指定記述してください");
                }
            }
            return ValidationResult.Success;
        }
    }
}
