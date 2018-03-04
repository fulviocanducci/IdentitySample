using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentitySample.Application.Api.Interfaces
{
    public interface ISignInManager<TUser> where TUser : class
    {
        Task<bool> CanSignInAsync(TUser user);
        Task<SignInResult> CheckPasswordSignInAsync(TUser user, string password, bool lockoutOnFailure);
        AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl, string userId = null);
        Task<ClaimsPrincipal> CreateUserPrincipalAsync(TUser user);
        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor);
        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);
        Task ForgetTwoFactorClientAsync();
        Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
        Task<ExternalLoginInfo> GetExternalLoginInfoAsync(string expectedXsrf = null);
        Task<TUser> GetTwoFactorAuthenticationUserAsync();
        bool IsSignedIn(ClaimsPrincipal principal);
        Task<bool> IsTwoFactorClientRememberedAsync(TUser user);
        Task<SignInResult> PasswordSignInAsync(TUser user, string password, bool isPersistent, bool lockoutOnFailure);
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task RefreshSignInAsync(TUser user);
        Task RememberTwoFactorClientAsync(TUser user);
        Task SignInAsync(TUser user, AuthenticationProperties authenticationProperties, string authenticationMethod = null);
        Task SignInAsync(TUser user, bool isPersistent, string authenticationMethod = null);
        Task SignOutAsync();
        Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient);
        Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode);
        Task<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient);
        Task<IdentityResult> UpdateExternalAuthenticationTokensAsync(ExternalLoginInfo externalLogin);
        Task<TUser> ValidateSecurityStampAsync(ClaimsPrincipal principal);

    }
}
