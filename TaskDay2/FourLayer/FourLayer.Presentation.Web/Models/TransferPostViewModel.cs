using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourLayer.Presentation.Web.Models {
    public class TransferPostViewModel {
        public string AccountFrom { get; set; }
        public string AccountTo { get; set; }
        public decimal Amount { get; set; }
    }
}