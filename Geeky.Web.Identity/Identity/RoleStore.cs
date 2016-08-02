using System;
using System.Linq;
using System.Threading.Tasks;
using Geeky.Models.Identity;
using Geeky.Models.Identity.Interfaces;
using Geeky.Web.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Geeky.Web.Identity.Identity
{
    public class RoleStore : RoleStore<GeekyRole, ApplicationDbContext, Guid>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region IRoleStore<IdentityRole, Guid> Members
        public System.Threading.Tasks.Task CreateAsync(GeekyRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            var r = getRole(role);

            _unitOfWork.RoleRepository.Add(r);
            return _unitOfWork.SaveChangesAsync();
        }

        public System.Threading.Tasks.Task DeleteAsync(GeekyRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            var r = getRole(role);

            _unitOfWork.RoleRepository.Remove(r);
            return _unitOfWork.SaveChangesAsync();
        }

        public System.Threading.Tasks.Task<GeekyRole> FindByIdAsync(Guid roleId)
        {
            var role = _unitOfWork.RoleRepository.FindById(roleId);
            return Task.FromResult<GeekyRole>(getIdentityRole(role));
        }

        public System.Threading.Tasks.Task<GeekyRole> FindByNameAsync(string roleName)
        {
            var role = _unitOfWork.RoleRepository.FindByName(roleName);
            return Task.FromResult<GeekyRole>(getIdentityRole(role));
        }

        public System.Threading.Tasks.Task UpdateAsync(GeekyRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");
            var r = getRole(role);
            _unitOfWork.RoleRepository.Update(r);
            return _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            // Dispose does nothing since we want Unity to manage the lifecycle of our Unit of Work
        }
        #endregion

        #region IQueryableRoleStore<IdentityRole, Guid> Members
        public IQueryable<GeekyRole> Roles
        {
            get
            {
                return _unitOfWork.RoleRepository
                    .GetAll()
                    .Select(x => getIdentityRole(x))
                    .AsQueryable();
            }
        }
        #endregion

        #region Private Methods
        private Role getRole(GeekyRole identityRole)
        {
            if (identityRole == null)
                return null;
            return new Role
            {
                RoleId = identityRole.Id,
                Name = identityRole.Name
            };
        }

        private GeekyRole getIdentityRole(Role role)
        {
            if (role == null)
                return null;
            return new GeekyRole
            {
                Id = role.RoleId,
                Name = role.Name
            };
        }
        #endregion
    }
}