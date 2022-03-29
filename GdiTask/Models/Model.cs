using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GdiTask.Models
{
   
    public class Model
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public Guid Id { get; set; }

        //črka ki je vpisana v prvem stolpcu predstavlja obseg identifikacije
        //P=atipični davčni zavezanec, O=zavezanci ki nimajo stalnega prebivališča v Slovenija
        public bool? ObsegIdentifikacije { get; set; }
        //če je * pove ali gre za davčnega zavezanca ki ima omejen obseg identifikacije
        public bool OmejenObsegIdentifikacije { get; set; }
        
        [Required]
        public long DavcnaStevilka { get; set; }

        public string MaticnaStevilka { get; set; }

        //datum s katerim je pravna oseba identificirana za namene DDV
        public DateTime? DatumPO { get; set; }

        //šifra ki zajema dejavnosti in in storitve dejavnosti
        [Required]
        public String Skd { get; set; }
        [Required]
        public String ImePodjetja { get; set; }
        [Required]
        public String NaslovPodjetja { get; set; }
      
        [Required]
        public short ObcinskaEnota { get; set; }

    }
}
