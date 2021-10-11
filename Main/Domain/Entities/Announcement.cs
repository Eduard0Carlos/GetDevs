﻿using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Announcement : EntityBase
    {
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public Skill SkillRequired { get; protected set; }
        public Language LanguagesRequired { get; protected set; }       
        public Degree degreesRequired { get; protected set; }
        public int AvaibleVacancy { get; protected set; }
        public int RequiredCandidates { 
            get 
            {
                return AvaibleVacancy * 2;
            }
        }   
        public DateTime AnnouncementDate { get; protected set; }
        public DateTime ExpiredDate { get; protected set; }
        public Company Company { get; protected set; }
        public int CompanyId { get; protected set; }
        public ICollection<CandidateAnnoucement> Candidates { get; protected set; }
    }
}
