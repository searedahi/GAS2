using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Geeky.Models.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using Geeky.Models.Identity;
using Claim = System.Security.Claims.Claim;

namespace Geeky.Web.Identity.Identity
{
    public class UserStore : IUserLoginStore<GeekyUser>, 
        IUserClaimStore<GeekyUser>, 

        IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region IUserStore<IdentityUser, Guid> Members
        public Task CreateAsync(GeekyUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var u = getUser(user);

            _unitOfWork.UserRepository.Add(u);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task DeleteAsync(GeekyUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var u = getUser(user);

            _unitOfWork.UserRepository.Remove(u);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task<GeekyUser> FindByIdAsync(Guid userId)
        {
            var user = _unitOfWork.UserRepository.FindById(userId);
            return Task.FromResult<GeekyUser>(getIdentityUser(user));
        }

        public Task<GeekyUser> FindByNameAsync(string userName)
        {
            var user = _unitOfWork.UserRepository.FindByUserName(userName);
            return Task.FromResult<GeekyUser>(getIdentityUser(user));
        }

        public Task UpdateAsync(GeekyUser user)
        {
            if (user == null)
                throw new ArgumentException("user");

            var u = _unitOfWork.UserRepository.FindById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            populateUser(u, user);

            _unitOfWork.UserRepository.Update(u);
            return _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            // Dispose does nothing since we want Unity to manage the lifecycle of our Unit of Work
        }
        #endregion

        #region IUserClaimStore<IdentityUser, Guid> Members
        public Task AddClaimAsync(GeekyUser user, Claim claim)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (claim == null)
                throw new ArgumentNullException("claim");

            var u = _unitOfWork.UserRepository.FindById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            var c = new Geeky.Models.Identity.Claim
            {
                ClaimType = claim.Type,
                ClaimValue = claim.Value,
                User = u
            };
            u.Claims.Add(c);

            _unitOfWork.UserRepository.Update(u);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task<IList<Claim>> GetClaimsAsync(GeekyUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var u = _unitOfWork.UserRepository.FindById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            return Task.FromResult<IList<Claim>>(u.Claims.Select(x => new Claim(x.ClaimType, x.ClaimValue)).ToList());
        }

        public Task RemoveClaimAsync(GeekyUser user, Claim claim)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (claim == null)
                throw new ArgumentNullException("claim");

            var u = _unitOfWork.UserRepository.FindById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            var c = u.Claims.FirstOrDefault(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value);
            u.Claims.Remove(c);

            _unitOfWork.UserRepository.Update(u);
            return _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region IUserLoginStore<IdentityUser, Guid> Members
        public Task AddLoginAsync(GeekyUser user, UserLoginInfo login)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (login == null)
                throw new ArgumentNullException("login");

            var u = _unitOfWork.UserRepository.FindById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            var l = new ExternalLogin
            {
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey,
                User = u
            };
            u.Logins.Add(l);

            _unitOfWork.UserRepository.Update(u);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task<GeekyUser> FindAsync(UserLoginInfo login)
        {
            if (login == null)
                throw new ArgumentNullException("login");

            var identityUser = default(GeekyUser);

            var l = _unitOfWork.ExternalLoginRepository.GetByProviderAndKey(login.LoginProvider, login.ProviderKey);
            if (l != null)
                identityUser = getIdentityUser(l.User);

            return Task.FromResult<GeekyUser>(identityUser);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(GeekyUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var u = _unitOfWork.UserRepository.FindById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            return Task.FromResult<IList<UserLoginInfo>>(u.Logins.Select(x => new UserLoginInfo(x.LoginProvider, x.ProviderKey, x.User.UserName)).ToList());
        }

        public Task RemoveLoginAsync(GeekyUser user, UserLoginInfo login)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (login == null)
                throw new ArgumentNullException("login");

            var u = _unitOfWork.UserRepository.FindById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            var l = u.Logins.FirstOrDefault(x => x.LoginProvider == login.LoginProvider && x.ProviderKey == login.ProviderKey);
            u.Logins.Remove(l);

            _unitOfWork.UserRepository.Update(u);
            return _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region IUserRoleStore<IdentityUser, Guid> Members
        public Task AddToRoleAsync(GeekyUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: roleName.");

            var u = _unitOfWork.UserRepository.FindById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");
            var r = _unitOfWork.RoleRepository.FindByName(roleName);
            if (r == null)
                throw new ArgumentException("roleName does not correspond to a Role entity.", "roleName");

            u.Roles.Add(r);
            _unitOfWork.UserRepository.Update(u);

            return _unitOfWork.SaveChangesAsync();
        }

        public Task<IList<string>> GetRolesAsync(GeekyUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var u = _unitOfWork.UserRepository.FindById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            return Task.FromResult<IList<string>>(u.Roles.Select(x => x.Name).ToList());
        }

        public Task<bool> IsInRoleAsync(GeekyUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: role.");

            var u = _unitOfWork.UserRepository.FindById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            return Task.FromResult<bool>(u.Roles.Any(x => x.Name == roleName));
        }

        public Task RemoveFromRoleAsync(GeekyUser user, string roleName, CancellationToken cancellationToken)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: role.");

            var u = _unitOfWork.UserRepository.FindById(user.Id);
            if (u == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            var r = u.Roles.FirstOrDefault(x => x.Name == roleName);
            u.Roles.Remove(r);

            _unitOfWork.UserRepository.Update(u);
            return _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region IUserPasswordStore<IdentityUser, Guid> Members
        public Task<string> GetPasswordHashAsync(GeekyUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return Task.FromResult<string>(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(GeekyUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return Task.FromResult<bool>(!string.IsNullOrWhiteSpace(user.PasswordHash));
        }

        public Task SetPasswordHashAsync(GeekyUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }
        #endregion

        #region IUserSecurityStampStore<IdentityUser, Guid> Members
        public Task<string> GetSecurityStampAsync(GeekyUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            return Task.FromResult<string>(user.SecurityStamp);
        }

        public Task SetSecurityStampAsync(GeekyUser user, string stamp)
        {
            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }
        #endregion

        #region Private Methods
        private Geeky.Models.Identity.User getUser(GeekyUser identityUser)
        {
            if (identityUser == null)
                return null;

            var user = new Geeky.Models.Identity.User();
            populateUser(user, identityUser);

            return user;
        }

        private void populateUser(Geeky.Models.Identity.User user, GeekyUser identityUser)
        {
            user.UserId = identityUser.Id;
            user.UserName = identityUser.UserName;
            user.PasswordHash = identityUser.PasswordHash;
            user.SecurityStamp = identityUser.SecurityStamp;
        }

        private GeekyUser getIdentityUser(Geeky.Models.Identity.User user)
        {
            if (user == null)
                return null;

            var identityUser = new GeekyUser();
            populateIdentityUser(identityUser, user);

            return identityUser;
        }

        private void populateIdentityUser(GeekyUser identityUser, Geeky.Models.Identity.User user)
        {
            identityUser.Id = user.UserId;
            identityUser.UserName = user.UserName;
            identityUser.PasswordHash = user.PasswordHash;
            identityUser.SecurityStamp = user.SecurityStamp;
        }
        #endregion

        public Task<string> GetUserIdAsync(GeekyUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserStore<GeekyUser>.GetUserNameAsync(GeekyUser user, CancellationToken cancellationToken)
        {
            return GetUserNameAsync(user, cancellationToken);
        }

        Task IUserStore<GeekyUser>.GetNormalizedUserNameAsync(GeekyUser user, CancellationToken cancellationToken)
        {
            return GetNormalizedUserNameAsync(user, cancellationToken);
        }

        public Task SetNormalizedUserNameAsync(GeekyUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(GeekyUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserStore<GeekyUser>.GetUserIdAsync(GeekyUser user, CancellationToken cancellationToken)
        {
            return GetUserIdAsync(user, cancellationToken);
        }

        public Task<string> GetUserNameAsync(GeekyUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(GeekyUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(GeekyUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(GeekyUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(GeekyUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(GeekyUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(GeekyUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GeekyUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GeekyUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GeekyUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GeekyUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddLoginAsync(GeekyUser user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserLoginStore<GeekyUser>.GetLoginsAsync(GeekyUser user, CancellationToken cancellationToken)
        {
            return GetLoginsAsync(user, cancellationToken);
        }

        public Task<GeekyUser> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(GeekyUser user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(GeekyUser user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(GeekyUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GeekyUser> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Claim>> GetClaimsAsync(GeekyUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddClaimsAsync(GeekyUser user, IEnumerable claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddClaimsAsync(GeekyUser user, IEnumerable claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserClaimStore<GeekyUser>.GetClaimsAsync(GeekyUser user, CancellationToken cancellationToken)
        {
            return GetClaimsAsync(user, cancellationToken);
        }

        public Task ReplaceClaimAsync(GeekyUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IUserClaimStore<GeekyUser>.GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            return GetUsersForClaimAsync(claim, cancellationToken);
        }

        public Task RemoveClaimsAsync(GeekyUser user, IEnumerable claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<GeekyUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(GeekyUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(GeekyUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(GeekyUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<GeekyUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(GeekyUser user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(GeekyUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(GeekyUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetSecurityStampAsync(GeekyUser user, string stamp, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSecurityStampAsync(GeekyUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}