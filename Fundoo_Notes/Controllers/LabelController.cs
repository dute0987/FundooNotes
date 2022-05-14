using Business_Layer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositary_Layer.FundooContext;
using RepositaryLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundoo_Notes.Controllers
{
    public class LabelController:ControllerBase
    {
        FundooContextDB fundooContext;
        ILabelBL labelBL;

        public LabelController(ILabelBL labelBL, FundooContextDB fundoos)
        {
            this.labelBL = labelBL;
            this.fundooContext = fundoos;
        }
        [Authorize]
        [HttpPost("LabelName{NoteId}")]

        public async Task<ActionResult>AddLabel(int NoteId,string LabelName)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                await this.labelBL.AddLabel(UserId,NoteId,LabelName);
                return this.Ok(new { success = true, message = "Label Added Successfully" });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpDelete("DeleteLabel/{LabelId}")]
        public async Task<ActionResult> DeleteLabel(int LabelId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                await this.labelBL.DeleteLabel(LabelId, userId);
                return this.Ok(new { success = true, message = $"Label Deleted successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpPut("UpdateLabel/{LabelId}/{LabelName}")]
        public async Task<ActionResult> UpdateLabel(string LabelName, int LabelId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                var result = await this.labelBL.UpdateLabel(userId, LabelId, LabelName);
                if (result == null)
                {
                    return this.BadRequest(new { success = true, message = "Updation of Label failed" });
                }
                return this.Ok(new { success = true, message = $"Label updated successfully", data = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("Getlabel")]
        public async Task<ActionResult> GetLabel()
        {
            try
            {
                List<Label> list = new List<Label>();
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                list = await this.labelBL.Getlabel(userId);
                if (list == null)
                {
                    return this.BadRequest(new { success = false, message = "Failed to get label" });
                }
                return this.Ok(new { success = true, message = $"Label get successfully", data = list });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
