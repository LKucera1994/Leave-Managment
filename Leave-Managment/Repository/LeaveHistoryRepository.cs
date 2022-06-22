
using Leave_Managment.Contracts;
using Leave_Managment.Data;

namespace Leave_Managment.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveHistory entity)
        {
            _db.Add(entity);
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _db.Remove(entity);
            return Save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            return _db.LeaveHistories.ToList();
        }

        public LeaveHistory FindById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _db.LeaveHistories.Find(id);
#pragma warning restore CS8603 // Possible null reference return.
        }


        public bool Save()
        {
            return _db.SaveChanges()>0;
        }

        public bool Update(LeaveHistory entity)
        {
            _db.Update(entity);
            return Save();
        }
    }
}
