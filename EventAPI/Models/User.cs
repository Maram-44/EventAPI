using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventAPI.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    public string? Six { get; set; }
    [Required]
    public string UserName { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
