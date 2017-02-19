using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Data.Models
{
    public class Workingtime
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid WorkingtimeId { get; set; }

        public Boolean MoDayOff { get; set; }
        public TimeSpan MoStartFrom { get; set; }
        public TimeSpan MoWorkTo { get; set; }

        public Boolean TuDayOff { get; set; }
        public TimeSpan TuStartFrom { get; set; }
        public TimeSpan TuWorkTo { get; set; }

        public Boolean WeDayOff { get; set; }
        public TimeSpan WeStartFrom { get; set; }
        public TimeSpan WeWorkTo { get; set; }

        public Boolean ThDayOff { get; set; }
        public TimeSpan ThStartFrom { get; set; }
        public TimeSpan ThWorkTo { get; set; }

        public Boolean FrDayOff { get; set; }
        public TimeSpan FrStartFrom { get; set; }
        public TimeSpan FrWorkTo { get; set; }

        public Boolean SaDayOff { get; set; }
        public TimeSpan SaStartFrom { get; set; }
        public TimeSpan SaWorkTo { get; set; }

        public Boolean SuDayOff { get; set; }
        public TimeSpan SuStartFrom { get; set; }
        public TimeSpan SuWorkTo { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}