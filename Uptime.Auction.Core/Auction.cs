using System;
using System.ComponentModel.DataAnnotations;

namespace Uptime.Auction.Core
{
    public class Auction
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Items name is required")]
        [StringLength(100)]
        public string Item { get; set; }
        public DateTime Start { get; set; }

        [DisplayFormat(DataFormatString = "yyyy-MM-dd hh:mm:ss")]
        public DateTime End { get; set; }

        [Range(1, 99, ErrorMessage = "Starting price must be between 0 and 100")]
        public double StartingPrice { get; set; }
        public double CurrentPrice { get; set; }


    }
}
