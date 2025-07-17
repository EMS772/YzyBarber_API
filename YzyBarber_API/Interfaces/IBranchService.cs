using YzyBarber_API.DTO_s.BranchDTO_s;

namespace YzyBarber_API.Interfaces
{
    public interface IBranchService
    {
        public List<BranchDTO> GetBranches();
        public BranchDTO CreateBranch(CreateBranchDTO branchDTO);
        public BranchDTO UpdateBranch(int Id, CreateBranchDTO branchDTO);
        public void DeleteBranch(int Id);
    }
}
