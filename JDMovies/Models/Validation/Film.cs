using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JDMovies.DAL
{

    [MetadataType(typeof(FilmMetadata))]
    public partial class Film
    {
    }
    public class FilmMetadata
    {
       
        public int ID_filmu { get; set; }

        [Required(ErrorMessage = "Podanie tytułu jest wymagane!")]
        [RegularExpression(@"^[^-\s][a-zA-Z0-9_\s-]+$",ErrorMessage = "Tytuł nie może zaczynać się znakiem białym!")]
        [MaxLength(50,ErrorMessage = "Maksymalna długość tytułu to 50 znaków!")]
        [Display(Name = "Tytuł")]
        public string Tytul { get; set; }

        
        [Required(ErrorMessage = "Podanie daty premiery jest wymagane!")]
        [DataType(DataType.Date)]     
        [Display(Name = "Data premiery")]
        public System.DateTime Data_premiery { get; set; }

        [Required(ErrorMessage = "Wybierz ograniczenie wiekowe!")]
        [Display(Name = "Ograniczenie wiekowe")]
        public string Ogr_wiekowe { get; set; }

        [Required(ErrorMessage = "Podanie czasu trwania jest wymagane")]        
        [Display(Name = "Czas trwania")]
        [Range(1, int.MaxValue, ErrorMessage = "Podanie czasu trwania jest wymagane")]
        public int Czas_trwania { get; set; }


        [Required(ErrorMessage = "Wybierz nośnik!")]
        [Display(Name = "Nośnik")]
        public string Nosnik { get; set; }


        public byte[] Zdjecie { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gatunek> Gatuneks { get; set; }

    }
}