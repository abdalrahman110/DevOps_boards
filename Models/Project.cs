//the project properties and informantion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetAPI.Models
{
    [Table("Project", Schema = "dbo")]
    public class Project
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Project ID")]
        public int Id { get; set; } //the id for the project

        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Project Name")]
        public string? PName { get; set; }//the project name

        //[Column(TypeName = "int")]
        //public int AssignedTo { get; set; } //!! Foreign key referencing DeveloperID, indicating the developer to whom the project is assigned


    }

}