using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models;

public class Contacts
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; }

    [Phone]
    public string PhoneNumber { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string Notes { get; set; }  
    
    public bool IsFavorite { get; set; }
}