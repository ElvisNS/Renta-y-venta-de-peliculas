using System;
namespace Renta_y_venta_de_peliculas.DAL.Core
{
    public abstract class AuditEntity
    {
        public AuditEntity()
        {
            this.Create_date = DateTime.Now;
            this.Deleted = false;
        }
        public int Create_user { get; set; }
        public DateTime Create_date { get; set; }
        public int Modify_user { get; set; }
        public DateTime? Modify_date { get; set; }
        public int? Deleted_user { get; set; }
        public DateTime? Deleted_date { get; set; }
        public bool Deleted { get; set; }
    }
}
