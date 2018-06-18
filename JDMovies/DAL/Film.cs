using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace JDMovies.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Film()
        {
            this.Gatuneks = new HashSet<Gatunek>();
        }
    
        public int ID_filmu { get; set; }
        public string Tytul { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime Data_premiery { get; set; }
        public string Ogr_wiekowe { get; set; }

        public int Czas_trwania { get; set; }
        public string Nosnik { get; set; }
        public byte[] Zdjecie { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gatunek> Gatuneks { get; set; }
    }
}
