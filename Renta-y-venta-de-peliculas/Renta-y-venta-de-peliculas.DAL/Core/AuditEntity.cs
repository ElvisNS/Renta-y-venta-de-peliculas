using System;

namespace Renta_y_venta_de_peliculas.DAL.Core
{
    public abstract class AuditEntity
    {
        public AuditEntity()
        {
            this.create_date = DateTime.Now;
            this.deleted = false;
        }
        public int? create_user { get; set; }
        public DateTime? create_date { get; set; }
        public int? modify_user { get; set; }
        public DateTime? modify_date { get; set; }
        public int? deleted_user { get; set; }
        public DateTime? deleted_date { get; set; }
        public bool? deleted { get; set; }
    }
}
