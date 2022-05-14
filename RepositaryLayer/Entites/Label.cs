﻿using Repositary_Layer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositaryLayer.Entites
{
    public class Label
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LabelId { get; set; }
        public string LabelName { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public int? NoteId { get; set; }
        public virtual Note Note { get; set; }
    }
}