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
    public class NoteBL: INoteBL
    {
        INoteRL noteRL;
        public NoteBL(INoteRL noteRL)
        {
            this.noteRL = noteRL;
        }

        public async Task AddNote(int UserId, NotePostModel notePostModel)
        {
            try
            {
                await noteRL.AddNote(UserId, notePostModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task ArchiveNote(int UserId, int noteId)
        {
            try
            {
                await this.noteRL.ArchiveNote(UserId, noteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task ChangeColour(int UserId, int noteId, string colour)
        {
            try
            {
                await this.noteRL.ChangeColour(UserId, noteId, colour);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteNote(int noteId, int UserId)
        {
            try
            {
                await this.noteRL.DeleteNote(UserId, noteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Note>> GetAll(int UserId)
        {
            try
            {
               return await this.noteRL.GetAll(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task PinNote(int UserId, int noteId)
        {
            try
            {
                await this.noteRL.PinNote(UserId, noteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Remainder(int UserId, int noteId, DateTime RemainderDate)
        {

            try
            {
                await this.noteRL.Remainder(UserId, noteId,RemainderDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task TrashNote(int UserId, int noteId)
        {
            try
            {
                await this.noteRL.TrashNote(UserId, noteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Note> UpdateNote(int UserId, int noteId, NoteUpdateModel noteUpdateModel)
        {
            try
            {
                return await this.noteRL.UpdateNote(UserId, noteId, noteUpdateModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
