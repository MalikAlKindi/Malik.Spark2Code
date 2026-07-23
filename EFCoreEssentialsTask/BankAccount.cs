using System.ComponentModel.DataAnnotations;

namespace EFCoreEssentialsTask;

public class BankAccount
{
    [Key]
    public int AccountId { get; set; }

    [Required]
    [MaxLength(100)]
    public string HolderName { get; set; } = string.Empty;

    public decimal Balance { get; set; }
}
