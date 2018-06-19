using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace JDMovies.DAL
{    

        public class FilmMetadata
        {

            public int ID_filmu { get; set; }

            [Required(ErrorMessage = "Podaj tytuł!")]
            public string Tytul { get; set; }

            [DataType(DataType.Date)]
            [Required(ErrorMessage = "Podaj datę premiery!")]
            public System.DateTime Data_premiery { get; set; }

            [Required(ErrorMessage = "Wybierz ograniczenie wiekowe!")]
            public string Ogr_wiekowe { get; set; }

            [Required(ErrorMessage = "Podaj czas trwania!")]
            [RegularExpression("^[1-9]*$",ErrorMessage = "Czas trwania musi być liczbą!")]
            public int Czas_trwania { get; set; }


            [Required(ErrorMessage = "Wybierz nośnik!")]
            public string Nosnik { get; set; }

            public byte[] Zdjecie { get; set; }

        }
    

}
