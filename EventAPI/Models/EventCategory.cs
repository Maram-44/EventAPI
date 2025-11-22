using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EventAPI.Models;

public partial class EventCategory
{
    public int Id { get; set; }
    [Required]
    public string CategoryName { get; set; } = null!;

    public string? Icon { get; set; }
    [JsonIgnore]
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
