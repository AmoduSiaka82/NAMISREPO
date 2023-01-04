using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class OfficialFile
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string DateReceived { get; set; }
        public string FileCode { get; set; }
        public string DateDispatched { get; set; }
        public string DocNumber { get; set; }
        public System.Guid FileIds { get; set; }
        public byte[] Attachment { get; set; }
        public string DateUsReceived { get; set; }
        public string TimeReceived { get; set; }
        public string StaffName { get; set; }

        public virtual CreateFile CreateFile { get; set; }
    }
}
