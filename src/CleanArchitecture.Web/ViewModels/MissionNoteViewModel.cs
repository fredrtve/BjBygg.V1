using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ViewModels
{
    public class MissionNoteViewModel
    {
        public MissionNoteViewModel() { }
        public MissionNoteViewModel(MissionNote note)
        {
            Id = note.Id;
            MissionId = note.MissionId;
            Title = note.Title;
            Content = note.Content;
            CreatedAt = note.CreatedAt;
            CreatedBy = note.CreatedBy;
            Pinned = note.Pinned;
        }

        public int Id { get; set; }

        [Required]       
        public int MissionId { get; set; }

        [StringLength(75, ErrorMessage = "{0} kan maks være på {1} tegn.")]
        [Display(Name = "Tittel")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "{0} må fylles ut.")]
        [StringLength(400, ErrorMessage = "{0} kan maks være på {1} tegn.")]
        [Display(Name = "Innhold")]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        [Display(Name = "Marker som viktig")]
        public bool Pinned { get; set; }
    }
}
