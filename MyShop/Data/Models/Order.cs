using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Models
{
    public class Order
    {
        [BindNever]         //не отображается
        public int id { get; set; }
        [Display(Name="Имя")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина имени не менее 3 символов")]
        public string name { get; set; }
        [Display(Name = "Фамилия")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина фамилии не менее 5 символов")]
        public string surname { get; set; }
        [Display(Name = "Адрес")]
        [StringLength(40)]
        [Required(ErrorMessage = "Длина адреса не менее 10 символов")]
        public string adress { get; set; }
        [Display(Name = "Номер телефона")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера телефона не менее 10 символов")]
        public string phone { get; set; }
        [Display(Name = "Email")]
        [StringLength(25)]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]     //не отображается в исходном коде
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
