using IdentityServer4.Models;
using System.ComponentModel.DataAnnotations;

namespace LocVoiture.Models
{
    public class VoitureMarque
    {
        public int Id { get; set; }

        public string Matricule { get; set; }

        public int Nbr_portes { get; set; }

        public int Nbr_places { get; set; }

        public string Photo_1 { get; set; }
        public string Couleur { get; set; }

        public string Libelle { get; set; }


    }
}
