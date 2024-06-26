namespace Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("account.Account")]
    public partial class Account
    {
        [Key]
        [Column(Order = 0)]
        public Guid UUID { get; set; }

        [Key]
        [Column(Order = 1)]
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
    }
}
