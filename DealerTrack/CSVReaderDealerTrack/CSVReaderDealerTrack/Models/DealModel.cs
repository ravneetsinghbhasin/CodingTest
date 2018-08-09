using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSVReaderDealerTrack.Models
{
    public class DealModel
    {
        ///<summary>
        /// Gets or sets DealNumber.
        ///</summary>
        public string DealNumber { get; set; }

        ///<summary>
        /// Gets or sets CustomerName.
        ///</summary>
        public string CustomerName { get; set; }

        ///<summary>
        /// Gets or sets DealershipName.
        ///</summary>
        public string DealershipName { get; set; }

        ///<summary>
        /// Gets or sets Vehicle.
        ///</summary>
        public string Vehicle { get; set; }

        ///<summary>
        /// Gets or sets Price.
        ///</summary>
        public string Price { get; set; }

        ///<summary>
        /// Gets or sets Date.
        ///</summary>
        public string Date { get; set; }
    }
}