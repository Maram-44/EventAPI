using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EventAPI.Models;

public partial class Comment
{
    public long Id { get; set; }
    [Required]
    public string Comment1 { get; set; } = null!;
    [Required]
    public int UserId { get; set; }
    [Required]
    public int? EventId { get; set; }
    [JsonIgnore]
    public virtual Event? Event { get; set; }

    public virtual User User { get; set; } = null!;
}
