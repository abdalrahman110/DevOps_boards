using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace dotnetAPI.Models
{
    [Table("Developer", Schema = "dbo")]
    public class Developer
    {

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Developer ID")]
        public int Id { get; set; } = 0;//the id

        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Developer Name")]
        public string? Name { get; set; } //name of the developer

        [Display(Name = "title")]
        [Column(TypeName = "varchar(50)")]
        public string? Title { get; set; }//e.g. frontend , backend ,DBA

        [Column(TypeName = "varchar(10)")]
        [Display(Name = "Salary")]
        public string? Salary { get; set; }// total salary

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Starting Date")]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyy}")]
        public DateTime StartingDate { get; set; } //the date of statring accept the project

        [Required]
        [ForeignKey("Project")]
        [Display(Name = "Project ID")]
        public int ProjectId { get; set; } // a foreign key on the project table (model)

        [Display(Name = "Project Name")]
        [NotMapped]
        public string? ProjectName { get; set; }

        //[Display(Name = "Project Data")]
        //public virtual Project? Project { get; set; }
    }
}
