using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EventAPI.Models;

public partial class Event
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime? FinishDate { get; set; }

    public TimeSpan? StartTime { get; set; }

    public TimeSpan? FineshTime { get; set; }

    public string? PlaceName { get; set; }

    public string? City { get; set; }

    public string Discription { get; set; } = null!;

    public int? UserId { get; set; }

    public int Category { get; set; }

    public int? Price { get; set; }

    public string? Image { get; set; }

    public string? ConstraintAge { get; set; }
    [JsonIgnore]
    public virtual EventCategory? CategoryNavigation { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; } = new List<Comment>();
    [JsonIgnore]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    [JsonIgnore]
    public virtual User? User { get; set; }
}
