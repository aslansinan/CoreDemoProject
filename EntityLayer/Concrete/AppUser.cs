using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete;

public class AppUser : IdentityUser
{
    public string NameSurname { get; set; }
    public string ImageUrl { get; set; }
}