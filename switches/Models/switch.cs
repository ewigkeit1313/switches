using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Switches.Models
{
    public class Switch
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите модель маршрутизатора")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Модель маршрутизатора")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Введите Ip-адрес")]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "Длина строки должна быть от 7 до 20 символов")]
        [Display(Name = "Ip-адрес")]
        public string Ip { get; set; }


        [Required(ErrorMessage = "Введите Mac-адрес")]
        [StringLength(70, MinimumLength = 15, ErrorMessage = "Длина строки должна быть от 15 до 70 символов")]
        [Display(Name = "Mac-адрес")]
        public string Mac { get; set; }


        [Required(ErrorMessage = "VLan")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 4 символов")]
        [Display(Name = "VLan")]
        public string VLan { get; set; }


        [Required(ErrorMessage = "Серийный номер")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 50 символов")]
        [Display(Name = "Серийный номер")]
        public string Serial { get; set; }


        [Required(ErrorMessage = "Дата покупки")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата покупки")]
        public DateTime DateBuy { get; set; }


        [Required(ErrorMessage = "Дата установки")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата установки")]
        public DateTime DateInstallation{ get; set; }


        [Required(ErrorMessage = "Этаж")]
        [Range(-5, 256)]
        [Display(Name = "Этаж")]
        public int Floor { get; set; }


        public string Сomment { get; set; }
    }
}