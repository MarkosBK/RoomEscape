using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace ASP_ComplexEx.Models
{
    public class RoomsList : IRepository<Room>, IDisposable
    {
        RoomContext db;
        public RoomsList(string name)
        {
            db = new RoomContext(name);
        }
        public void Add(Room room)
        {

        }

        public void Delete(int id)
        {
            db.Entry(getById(id)).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Edit(Room room)
        {
            if (room.Images.Where(i => i.IsLogo).Count() > 0) 
            {
                if (room.Images.FirstOrDefault(i => i.IsLogo).Path != db.Images.Where(i => i.RoomId == room.Id).FirstOrDefault(i => i.IsLogo).Path)
                {
                    db.Images.Remove(db.Images.FirstOrDefault(i => i.IsLogo));
                    db.SaveChanges();
                    db.Images.Add(room.Images.FirstOrDefault(i => i.IsLogo));
                }
            }
            else
            {
                room.Images.Add(db.Images.Where(i => i.RoomId == room.Id).FirstOrDefault(i => i.IsLogo));
            }

            db.Images.AddRange(room.Images.Skip(db.Images.Where(i => i.RoomId == room.Id).Count()).Where(i=>!i.IsLogo));
            db.SaveChanges();
            Room room1 = db.Set<Room>().Local.FirstOrDefault(t => t.Id == room.Id);
            if (room1 != null)
                db.Entry(room1).State = EntityState.Detached;
            db.Entry(room).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Room> GetList()
        {
            return db.Rooms.ToList();
        }
        public ImageForRoom GetLogo(Room room)
        {
            return db.Images.Where(i => i.RoomId == room.Id).First(i=>i.IsLogo);
        }

        public Room getById(int id)
        {
            return db.Rooms.First(r => r.Id == id);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        public int Length => throw new NotImplementedException();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    db.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~RoomsList()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }


        #endregion
    }
}