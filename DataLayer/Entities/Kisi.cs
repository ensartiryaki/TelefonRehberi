using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Kisi
    {
        [Key]
        public int KisiId { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [RegularExpression(@"[A-z^şŞıİçÇöÖüÜĞğ\s]*", ErrorMessage = "Geçersiz metin girişi")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [RegularExpression(@"[A-z^şŞıİçÇöÖüÜĞğ\s]*", ErrorMessage = "Geçersiz metin girişi")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(11, ErrorMessage = "Telefon numarası 11 haneli olmalıdır"), MinLength(11, ErrorMessage = "Telefon numarası 11 haneli olmalıdır")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Telefon numarası format dışı")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Format dışı email")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [MaxLength(11, ErrorMessage = "Kimlik numarası 11 haneli olmalıdır"), MinLength(11, ErrorMessage = "Kimlik numarası 11 haneli  olmalıdır")]
        public string TCKimlik { get; set; }

    }
}
