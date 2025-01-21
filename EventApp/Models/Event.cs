using System.ComponentModel.DataAnnotations;

namespace EventApp.Models
{
    public class Event
    {
        [Required]
        public int EventId { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "The Name field is required")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The Location field is required")]
        public string Location { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The Type field is required")]
        public string Type { get; set; }

        [Required]
        public Decimal Budget { get; set; }

    }
}
