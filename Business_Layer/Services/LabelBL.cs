using Business_Layer.Interface;
using CommonLayer;
using RepositaryLayer.Entites;
using RepositaryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public class LabelBL : ILabelBL
    {
        ILabelRL labelRL;
        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }

        public async Task AddLabel(int UserId, int NoteId, string LabelName)
        {
            try
            {
                await labelRL.AddLabel(UserId,NoteId,LabelName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteLabel(int LabelId, int UserId)
        {
            try
            {
                await labelRL.DeleteLabel(LabelId, UserId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Label> UpdateLabel(int UserId, int LabelId, string LabelName)
        {
            try
            {
                return await this.labelRL.UpdateLabel(UserId, LabelId, LabelName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Label>> Getlabel(int UserId)
        {
            try
            {
                return await this.labelRL.Getlabel(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
        
}
