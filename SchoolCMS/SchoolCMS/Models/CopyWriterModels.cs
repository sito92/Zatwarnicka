﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using System.Web.UI.WebControls;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;

namespace SchoolCMS.Models
{
        public class ChangePasswordModel
        {
            [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
            [Display(Name = "Nazwa użytkownika do zmiany danych")]
            public string UserName { get; set; }

            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Nowe hasło")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Potwierdz nowe hasło")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public class ChangePersonalDataModel
        {
            [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
            [Display(Name = "Nazwa użytkownika do zmiany danych")]
            public string UserName { get; set; }

            [Display(Name = "Nowy adres e-mail")]
            public string Email { get; set; }

            [Display(Name = "Nowa nazwa")]
            public string Name { get; set; }

            [Display(Name = "Nowe nazwisko")]
            public string Surname { get; set; }
        }

        public class RegisterModel
        {
            [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
            [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Nazwa użytkownika może składać się wyłącznie z liter i cyfr")]
            [Display(Name = "Nazwa użytkownika")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "Hasło jest wymagane")]
            [StringLength(100, ErrorMessage = "Hasło może mieć maksymalną długość {2} ", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Hasło")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Potwierdź hasło")]
            [Compare("Password", ErrorMessage = "Hasła nie pasują")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Adres e-mail jest wymagany")]
            //[EmailAddress(ErrorMessage = "Nieprawidłowy adres email")]
            [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu email")]
            [Display(Name = "E-mail")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Imie jest wymagane")]
            [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Imie może składać się wyłącznie z liter")]
            [Display(Name = "Imię")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Nazwisko jest wymagane")]
            [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Nazwisko może składać się wyłącznie z liter")]
            [Display(Name = "Nazwisko")]
            public string Surname { get; set; }
        }
    
}