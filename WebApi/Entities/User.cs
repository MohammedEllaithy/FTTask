namespace WebApi.Entities;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class User : IdentityUser<Guid>
{
    //public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required(ErrorMessage = "The Email field is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public override string Email { get; set; }
    public string Phone { get; set; }
    public string Website { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
}