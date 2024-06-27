namespace Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("account.Account")]
    public partial class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UUID { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        public string Surname { get; set; }

        [StringLength(5)]
        public string Title { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime UTCCreatedDateTime { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UTCUpdatedDateTime { get; set; }

        public Account()
        {
        }

        public Account(string email, string password, string name, string surname, string title)
        {
            Email = email;
            Password = password;
            Name = name;
            Surname = surname;
            Title = title;
        }
    }
}
