using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    using System;
    using System.Collections.Generic;

    public partial class provincia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public provincia()
        {
            this.distrito = new HashSet<distrito>();
        }

        public int id_provincia { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> id_departamento { get; set; }

        public virtual departamento departamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<distrito> distrito { get; set; }
    }
}