﻿using CommonLayer;
using RepositaryLayer.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Interface
{
    public interface ILabelBL
    {
        Task AddLabel(int UserId,int NoteId,string LabelName);
        Task DeleteLabel(int LabelId, int UserId);
        Task<Label> UpdateLabel(int UserId, int LabelId, string LabelName);
        Task<List<Label>> Getlabel(int UserId);
    }
}
