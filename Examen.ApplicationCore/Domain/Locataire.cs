using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Locataire
    {
        [Required(ErrorMessage = "L'adresse est obligatoire.")]
        public string Adresse { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAdhesion { get; set; }
        public int Id { get; set; }
        public int PointBonus { get; set; }
        public string Telephone  { get; set; }
        public Agent Agent { get; set; }
       
        public IList<Vehicule> vehicules { get; set; }
        public virtual IList<Reservation> Reservations { get; set; }

    }
}
