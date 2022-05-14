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
    public class NoteRL : INoteRL
    {
        FundooContextDB fundooContext;
        public IConfiguration configuraion { get; }

        public NoteRL(FundooContextDB fundooContext, IConfiguration configuraion)
        {
            this.fundooContext = fundooContext;
            this.configuraion = configuraion;
        }
        public async Task AddNote(int UserId, NotePostModel notePostModel)
        {
            try
            {
                Note note = new Note();

                note.NoteId = new Note().NoteId;
                note.UserId = UserId;

                note.Title = notePostModel.Title;
                note.Description = notePostModel.Description;
                note.colour = notePostModel.colour;

                note.IsPin = false;
                note.IsTrash = false;
                note.IsArchieve = false;
                note.IsRemainder = false;

                note.RegisterDate=DateTime.Now;
                note.ModifyDate=DateTime.Now;
                note.RemainderDate=DateTime.Now;

                fundooContext.Add(note);
                await fundooContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
           
        }


        public async Task ChangeColour(int UserId, int noteId, string colour)
        {
            try
            {
                var note = fundooContext.Notes.FirstOrDefault(e => e.UserId == UserId && e.NoteId == noteId);
                if(note != null)
                {
                    note.colour = colour;
                    await fundooContext.SaveChangesAsync();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task ArchiveNote(int UserId, int noteId)
        {
           try
           {
                var note = fundooContext.Notes.FirstOrDefault(e => e.UserId == UserId && e.NoteId == noteId);
                if(note != null)
                {
                    if(note.IsArchieve == true)
                    {
                        note.IsArchieve = false;
                    }
                    if(note.IsArchieve == false)
                    {
                        note.IsArchieve= true;
                    }
                }
                await fundooContext.SaveChangesAsync();
           }
           catch (Exception)
           {
                throw;
           }
        }

        public async Task<Note> UpdateNote(int UserId, int noteId, NoteUpdateModel noteUpdateModel)
        {
            try
            {
                var note = fundooContext.Notes.FirstOrDefault(e => e.UserId == UserId && e.NoteId == noteId);
                if(note != null)
                {
                    note.Title = noteUpdateModel.Title;
                    note.Description = noteUpdateModel.Description;
                    note.IsArchieve= noteUpdateModel.IsArchieve;
                    note.colour = noteUpdateModel.colour;
                    note.IsPin = noteUpdateModel.IsPin;
                    note.IsRemainder = noteUpdateModel.IsRemainder;
                    note.IsTrash = noteUpdateModel.IsTrash;

                    await fundooContext.SaveChangesAsync();
                }
                return await fundooContext.Notes
                    .Where(u => u.UserId == u.UserId && u.NoteId == noteId)
                    .Include(u => u.User)
                    .FirstOrDefaultAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task DeleteNote(int noteId, int UserId)
        {
            try
            {
                var note = fundooContext.Notes.FirstOrDefault(e => e.NoteId == noteId && e.UserId==UserId);
                if (note != null)
                {
                    fundooContext.Remove(note);
                    await fundooContext.SaveChangesAsync();
                    
                }
                
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public async Task PinNote(int UserId, int noteId)
        {
            try
            {
                var note = fundooContext.Notes.FirstOrDefault(e => e.UserId == UserId && e.NoteId == noteId);
                if (note != null)
                {
                    if (note.IsPin == true)
                    {
                        note.IsPin = false;
                    }
                    if (note.IsPin == false)
                    {
                        note.IsPin = true;
                    }
                }
                await fundooContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task TrashNote(int UserId, int noteId)
        {
            try
            {
                var note = fundooContext.Notes.FirstOrDefault(e => e.UserId == UserId && e.NoteId == noteId);
                if (note != null)
                {
                    if (note.IsTrash == true)
                    {
                        note.IsTrash = false;
                    }
                    if (note.IsTrash == false)
                    {
                        note.IsTrash = true;
                    }
                }
                await fundooContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Remainder(int UserId, int noteId, DateTime RemainderDate)
        {
            try
            {
                var note = fundooContext.Notes.FirstOrDefault(e => e.UserId == UserId && e.NoteId == noteId);
                if (note != null)
                {
                    if (note.IsRemainder == true)
                    {
                        note.RemainderDate = RemainderDate;
                    }   
                }
                await fundooContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Note>> GetAll(int UserId)
        {
            try
            {
                return await fundooContext.Notes.Where(x => x.UserId == UserId).Include(u => u.User).Include(l => l.Label).ToListAsync();
            }
            catch(Exception)
            {
                throw;
            }
            
        }
    }
}
