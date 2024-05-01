//the Task properties and informantion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetAPI.Models
{
    [Table("Task", Schema = "dbo")]
    public class Task
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Task ID")]
        public int Id { get; set; } //the id for the Task

        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Title")]
        public string? Title { get; set; }//the Task Title

        [Column(TypeName = "varchar(150)")]
        [Display(Name = "Task Description")]
        public string? Description { get; set; }

        [Column(TypeName = "int")]
        public int AssignedTo { get; set; } //!! Foreign key referencing DeveloperID, indicating the developer to whom the Task is assigned

        [Required]
        [ForeignKey("Project")]
        [Display(Name = "Project ID")]
        public int ProjectId { get; set; } // a foreign key on the project table (model)

        [Column(TypeName = "varchar(15)")]
        [Display(Name = "Status")]
        public Status Status { get; set; } = Status.notStarted;
    }


    public enum Status
    {
        accepted,
        rejected,
        notStarted,
        inProgress,
        done
    }
}