using NAMIS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class StaffTabViewModel
    {
        
        public Tab ActiveTab { get; set; }
    }
    public enum Tab
    {
        PreparePromotion,
        Qaulified,
        Promoted
    }
}
