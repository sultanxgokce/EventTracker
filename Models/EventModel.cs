using System;
using System.ComponentModel.DataAnnotations;

namespace EventTracker.Models;

public class EventModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Etkinlik başlığı zorunludur")]
    [StringLength(100, ErrorMessage = "Başlık 100 karakterden uzun olamaz")]
    public string? Title { get; set; }

    public string? Description { get; set; }

    [Required(ErrorMessage = "Etkinlik tarihi zorunludur.")]
    public DateTime Date { get; set; } // Etkinlik tarihi (ve saati)

}

