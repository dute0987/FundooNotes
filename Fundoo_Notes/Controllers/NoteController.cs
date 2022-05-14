using Business_Layer.Interface;
using CommonLayer;
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
    [ApiController]
    [Route("[controller]")]
    public class NoteController:ControllerBase
    {
        FundooContextDB fundooContext;
        INoteBL noteBL;

        public NoteController(FundooContextDB fundoos,INoteBL noteBL)
        {
            this.fundooContext = fundoos;
            this.noteBL = noteBL;
        }
        [Authorize]
        [HttpPost]

        public async Task<ActionResult>AddNote(NotePostModel notePostModel)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);

                await this.noteBL.AddNote(UserId, notePostModel);
                return this.Ok(new { success = true, message = "Note Added Successfully " });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpDelete("DeleteNote/{noteId}")]
        public async Task<ActionResult>DeleteNote(int noteId)
        {
            try
            {

                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);

                var note = fundooContext.Notes.FirstOrDefault(e => e.UserId == UserId && e.NoteId == noteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Please,This Note does not exist" });
                }
                await this.noteBL.DeleteNote(UserId, noteId);
                return this.Ok(new { success = true, message = "This Note Removed Successfully" });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPut("ChangeColour/{noteId}/{colour}")]
        public async Task<ActionResult> ChangeColour(int noteId, string colour)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);

                var note = fundooContext.Notes.FirstOrDefault(e => e.UserId == UserId && e.NoteId == noteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Colour is not found" });
                }

                await this.noteBL.ChangeColour(UserId, noteId, colour);
                return this.Ok(new { success = true, message = "Note Colour change sucessfully" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPut("ArchiveNote/{noteId}")]
        public async Task<ActionResult> ArchiveNote( int noteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);

                var note = fundooContext.Notes.FirstOrDefault(e => e.UserId == UserId && e.NoteId == noteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Archive not done" });
                }

                await this.noteBL.ArchiveNote(UserId, noteId);
                return this.Ok(new { success = true, message = "Note Archive sucessfully" });
            }
            catch(Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPut("UpdateNote/{noteId}")]

        public async Task<ActionResult> UpdateNote( int noteId, NoteUpdateModel noteUpdateModel)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);

                var note = fundooContext.Notes.FirstOrDefault(e => e.UserId == UserId && e.NoteId == noteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Invalid Note ID" });
                }
                await this.noteBL.UpdateNote(UserId, noteId, noteUpdateModel);
                return this.Ok(new { success = true, message = "Note Updated sucessfully" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPut("TrashNote/{noteId}")]
        public async Task<ActionResult> TrashNote(int noteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);

                var note = fundooContext.Notes.FirstOrDefault(e => e.UserId == UserId && e.NoteId == noteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Archive not done" });
                }

                await this.noteBL.TrashNote(UserId, noteId);
                return this.Ok(new { success = true, message = "Note Archive sucessfully" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPut("PinNote/{noteId}")]
        public async Task<ActionResult> PinNote(int noteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);

                var note = fundooContext.Notes.FirstOrDefault(e => e.UserId == UserId && e.NoteId == noteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Pinned Note is not done" });
                }

                await this.noteBL.PinNote(UserId, noteId);
                return this.Ok(new { success = true, message = "Pinned Note sucessfully" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPut("Remainder/{noteId}/{RemainderDate}")]
        public async Task<ActionResult> Remainder(int noteId,DateTime RemainderDate)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);

                var note = fundooContext.Notes.FirstOrDefault(e => e.UserId == UserId && e.NoteId == noteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Remainder is not done" });
                }

                await this.noteBL.Remainder(UserId, noteId, RemainderDate);
                return this.Ok(new { success = true, message = "Remainder done  sucessfully" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet("GetAllNotes")]
        public async Task<ActionResult>GetAll()
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                List<Note> notes = await this.noteBL.GetAll(UserId);
                return this.Ok(new { success = true, message = "These Nots are:", data = notes });
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
