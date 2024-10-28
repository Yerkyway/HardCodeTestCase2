﻿namespace DeliveryServiceApp.Dto;

public class UpdateDeliveryRequestDto
{
    public string City { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int OrderId { get; set; }
}