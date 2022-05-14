using CommonLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositary_Layer.FundooContext;
using RepositaryLayer.Entites;
using RepositaryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryLayer.Services
{
    public class LabelRL: ILabelRL
    {
        FundooContextDB fundooContext;
        public IConfiguration configuraion { get; }

        public LabelRL(FundooContextDB fundooContext, IConfiguration configuraion)
        {
            this.fundooContext = fundooContext;
            this.configuraion = configuraion;
        }

        public async Task AddLabel(int UserId,int NoteId,string LableName)
        {
            try
            {
                Label label = new Label();
                label.UserId = UserId;
                label.LabelName = LableName;
                label.NoteId = NoteId;
                fundooContext.Add(label);
                await fundooContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task DeleteLabel(int LabelId, int UserId)
        {
            try
            {
                var result = fundooContext.Label.FirstOrDefault(e =>e.LabelId == LabelId && e.UserId==UserId);
                fundooContext.Label.Remove(result);
                if(result != null)
                {
                    fundooContext.Remove(result);
                    await fundooContext.SaveChangesAsync();
                }
            }catch(Exception ex)
            {
                throw  ex;
            }
        }

        public async Task<Entites.Label> UpdateLabel(int UserId, int LabelId, string LabelName)
        {
            try
            {

                Entites.Label reuslt = fundooContext.Label.FirstOrDefault(u => u.LabelId == LabelId && u.UserId == UserId);

                if (reuslt != null)
                {
                    reuslt.LabelName = LabelName;
                    await fundooContext.SaveChangesAsync();
                    var result = fundooContext.Label.Where(u => u.LabelId == LabelId).FirstOrDefaultAsync();
                    return reuslt;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Entites.Label>> Getlabel(int UserId)
        {
            try
            {
                List<Entites.Label> reuslt = await fundooContext.Label.Where(u => u.UserId == UserId).Include(u => u.User).Include(u => u.Note).ToListAsync();
                return reuslt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
