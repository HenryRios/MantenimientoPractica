using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    using System;
    using System.Collections.Generic;

    public partial class cliente
    {
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public Nullable<int> id_distrito { get; set; }
        public string estado { get; set; }

        public virtual distrito distrito { get; set; }
    }
}
