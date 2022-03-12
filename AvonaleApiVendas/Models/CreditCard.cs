﻿using System.ComponentModel.DataAnnotations;

namespace AvonaleApiVendas.Models
{
    public class CreditCard
    {
        [Key]
        [MaxLength(16, ErrorMessage = "Precisa ter 16 caracteres")]
        [MinLength(16, ErrorMessage = "Precisa ter 16 caracteres")]
        public long CardNumber { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string CardHolder { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(3, ErrorMessage = "Precisa ter 3 caracteres")]
        [MinLength(3, ErrorMessage = "Precisa ter 3 caracteres")]
        public int VerifyCode { get; set; }

        public string CardFlag { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [DisplayFormat(DataFormatString = "mm/aaaa")]
        public DataType DueDate { get; set; }
    }
}