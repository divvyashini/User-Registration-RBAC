using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AccountController : ApiController
    {
        //registering the new user 
        [Route("api/User/Register")]
        [HttpPost]
        [AllowAnonymous]
        public IdentityResult Register(AccountModel accountModel)
        {
            var userDetails = new UserStore<ApplicationUser>(new ApplicationDbContext());   //storing the user
            var manager = new UserManager<ApplicationUser>(userDetails) ;     //creating the manager using user variable
            var user = new ApplicationUser() { UserName = accountModel.UserName, Email = accountModel.Email };
            user.FirstName = accountModel.FirstName;
            user.LastName = accountModel.LastName;
            IdentityResult result = manager.Create(user, accountModel.Password);
            manager.AddToRoles(user.Id, accountModel.Roles);
            return result;
        }


        //this webapi method returns the claims of the current logged in user
        //bearer token which was generated in the applicationOAuthprovider class will be passed into this method to retrieve user details
        [HttpGet]
        [Route("api/GetUserClaims")]
        [Authorize]
        public AccountModel GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            AccountModel model = new AccountModel()
            {
                UserName = identityClaims.FindFirst("UserName").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LastName = identityClaims.FindFirst("LastName").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value
            };

            return model;
        }
    }
}
