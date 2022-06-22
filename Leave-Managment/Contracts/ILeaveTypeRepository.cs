using Leave_Managment.Data;

namespace Leave_Managment.Contracts
{
    public interface ILeaveTypeRepository: IRepositoryBase<LeaveType>
    {
        ICollection<LeaveType> GetEmployeesByLeaveType(int id);

    }
}
