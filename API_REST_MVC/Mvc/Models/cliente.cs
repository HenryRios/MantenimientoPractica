using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class cliente
    {
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public Nullable<int> id_departamento { get; set; }

        public virtual departamento departamento { get; set; }
    }
}