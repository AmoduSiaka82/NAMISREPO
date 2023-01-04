using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class CreateFile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CreateFile()
        {
            this.OfficialFiles = new HashSet<OfficialFile>();
        }
        [Column(TypeName = "varchar(500)")]
        public string FileName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FileCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OfficialFile> OfficialFiles { get; set; }
    }
}
