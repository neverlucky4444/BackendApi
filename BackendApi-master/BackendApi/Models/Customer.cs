using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public virtual ICollection<Loyaltyprogram> Loyaltyprograms { get; set; } = new List<Loyaltyprogram>();

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual ICollection<Race> Races { get; set; } = new List<Race>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
