﻿using System.ComponentModel.DataAnnotations;

namespace GDS.Api.Model.Request
{
    public class CreateProfileRequest
    {
        [Required(ErrorMessage = "Propriedade 'Name' é obrigatória")]
        [Length(6, 99, ErrorMessage = "Propriedade 'Name' deve possuir de 6 a 99 caracteres")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Propriedade 'User' é obrigatória")]
        [Length(8, 8, ErrorMessage = "Propriedade 'User' deve possuir 8 caracteres")]
        public string User {  get; set; } = string.Empty;
        [Required(ErrorMessage = "Propriedade 'Password' é obrigatória")]
        [Length(8, 8, ErrorMessage = "Propriedade 'Password' deve possuir 8 caracteres")]
        public string Password { get; set; } = string.Empty;
        public string? ImgBase64 { get; set; } 
    }
}
