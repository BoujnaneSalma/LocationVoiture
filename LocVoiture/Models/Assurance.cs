using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocVoiture.Models
{
    public class Assurance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssuranceId { get; set; }
        public string Agence { get; set; }
       
        public DateTime Date_debut { get; set; }
        public DateTime Date_fin { get; set; }
        public int Prix { get; set; }

        public int? VoitureId { get; set; }
        public Voiture? Voiture { get; set; }
    }

    
}
