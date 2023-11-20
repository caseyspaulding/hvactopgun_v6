﻿namespace HVACTopGun.Domain.Features.Customers
{
    public class CustomerHistoryModel
    {
        public int CustomerHistoryId { get; set; }
        public int CustomerId { get; set; }
        public int TenantID { get; set; }
        public int JobTypeId { get; set; }
        public string? Notes { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime DateDeleted { get; set; }
    }
}
