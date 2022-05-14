using CommonLayer;
using RepositaryLayer.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryLayer.Interface
{
    public interface INoteRL
    {
        Task AddNote(int UserId ,NotePostModel notePostModel);
        Task <List<Note>>GetAll(int UserId);
        Task DeleteNote(int noteId,int UserId);
        Task ChangeColour(int UserId ,int noteId, string colour);
        Task ArchiveNote(int UserId,int noteId);
        Task PinNote(int UserId,int noteId);
        Task TrashNote(int UserId,int noteId);
        Task Remainder(int UserId,int noteId,DateTime RemainderDate);
        Task<Note> UpdateNote(int UserId, int noteId, NoteUpdateModel noteUpdateModel);
    }
}
