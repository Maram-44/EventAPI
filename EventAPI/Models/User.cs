using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EventAPI.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string? Six { get; set; }
    [Required]
    public string UserName { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    public UserDetails? userDetails { get; set; }
    [JsonIgnore]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    [JsonIgnore]
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    [JsonIgnore]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
