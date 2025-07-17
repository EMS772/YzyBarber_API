using YzyBarber_API.Data;
using YzyBarber_API.DTO_s.BranchDTO_s;
using YzyBarber_API.Entities;
using YzyBarber_API.Interfaces;

namespace YzyBarber_API.Services
{
    public class BranchService : IBranchService
    {
        private readonly BarberDbContext _dbcontext;
        public BranchService(BarberDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public BranchDTO CreateBranch(CreateBranchDTO branchDTO)
        {
            var exists = _dbcontext.Branches.Any(b =>
            b.BranchName == branchDTO.BranchName &&
            b.BranchPhone == branchDTO.BranchPhone);

            if (exists)
            {
                throw new ArgumentException("There is already a branch with the same name and phone number.");
            }

            var Branch = new Branch
            {
                CompanyId = branchDTO.CompanyId,
                BranchName = branchDTO.BranchName,
                BranchPhone = branchDTO.BranchPhone,
                Address = branchDTO.Address
            };

            _dbcontext.Branches.Add(Branch);
            _dbcontext.SaveChanges();

            return new BranchDTO
            {
                CompanyId = Branch.CompanyId,
                BranchName = Branch.BranchName,
                BranchPhone = Branch.BranchPhone,
                Address = Branch.Address
            };
        }

        public void DeleteBranch(int Id)
        {

            var branch = _dbcontext.Branches.FirstOrDefault(b => b.BranchId == Id);
            if (branch == null)
            {
                throw new ArgumentException("Branch not found");
            }
            _dbcontext.Remove(branch);
            _dbcontext.SaveChanges();

        }

        public List<BranchDTO> GetBranches()
        {
            var branches = _dbcontext.Branches.Select(b => new BranchDTO
            {
                BranchId = b.BranchId,
                CompanyId = b.CompanyId,
                BranchName = b.BranchName,
                BranchPhone = b.BranchPhone,
                Address = b.Address
            }).ToList();

            return branches;
        }

        public BranchDTO UpdateBranch(int Id, CreateBranchDTO branchDTO)
        {
            var branch = _dbcontext.Branches.FirstOrDefault(b => b.BranchId == Id);
            if (branch == null)
            {
                throw new ArgumentException("Branch not found");
            }


            branch.CompanyId = branchDTO.CompanyId;
            branch.BranchName = branchDTO.BranchName;
            branch.BranchPhone = branchDTO.BranchPhone;
            branch.Address = branchDTO.Address;
            _dbcontext.SaveChanges();
            return new BranchDTO
            {
                BranchId = branch.BranchId,
                CompanyId = branch.CompanyId,
                BranchName = branch.BranchName,
                BranchPhone = branch.BranchPhone,
                Address = branch.Address
            };
        }
    }
}
