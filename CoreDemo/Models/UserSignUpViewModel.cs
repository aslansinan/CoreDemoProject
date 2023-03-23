using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models;

public class UserSignUpViewModel
{
    [Display(Name = "Ad Soyad")]
    [Required(ErrorMessage = "Lütfen Ad Soyad Giriniz")]
    public string? NameSurname { get; set; }
    
    [Display(Name = "Şifre")]
    [Required(ErrorMessage = "Lütfen ŞifreGiriniz")]
    public string Password { get; set; } = null!;

    [Display(Name = "Şifre Tekrar")]
    [Compare("Password",ErrorMessage = "Şifreler Uyuşmuyor!")]
    public string? ConfirmPassword { get; set; }
    
    [Display(Name = "Mail")]
    [Required(ErrorMessage = "Lütfen Mail Giriniz")]
    public string? Mail { get; set; }
    
    [Display(Name = "Kullanıcı Adı")]
    [Required(ErrorMessage = "Lütfen kullanıcı adınızı Giriniz")]
    public string? UserName { get; set; }
    
}