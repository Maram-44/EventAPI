using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventAPI.Models;

public partial class Reservation
{
    public int IdNumber { get; set; }

    public DateTime BookingDate { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }
    [Required]
    public int EventId { get; set; }
    [Required]
    public int UserId { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
