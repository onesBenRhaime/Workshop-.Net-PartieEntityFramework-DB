using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Reservation
    {
        public DateTime DateReservation {  get; set; }
        [Range(1, 30)]
        public int DureeJours { get; set; }
        public virtual Vehicule Vehicule { get; set; }
        public virtual Locataire Locataire { get; set; }
        public int VehiculeKey { get; set; }
        public int LocataireKey { get; set; }

    }
}
