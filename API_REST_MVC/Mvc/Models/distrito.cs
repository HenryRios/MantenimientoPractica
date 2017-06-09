using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{

    using System;
    using System.Collections.Generic;

    public partial class distrito
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public distrito()
        {
            this.cliente = new HashSet<cliente>();
        }

        public int id_distrito { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> id_provincia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cliente> cliente { get; set; }
        public virtual provincia provincia { get; set; }
    }
}