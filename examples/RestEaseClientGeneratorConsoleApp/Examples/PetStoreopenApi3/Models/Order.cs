using System;
using System.Collections.Generic;

namespace RestEaseClientGeneratorConsoleApp.Examples.PetStoreOpenApi3.Models
{
    public class Order
    {
        public long Id { get; set; }

        public long PetId { get; set; }

        public int Quantity { get; set; }

        public DateTime ShipDate { get; set; }

        public string Status { get; set; }

        public bool Complete { get; set; }
    }
}
