using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(WebAPI.Startup))]

namespace WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            //configuring token based authentication here

            //enable CORS using OWIN
            app.UseCors(CorsOptions.AllowAll);

            //to implement token based authentication create auth options below 

            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),        //HTTP Post request with the token url along with username and password
                Provider = new ApplicationOAuthProvider(),              //if the user is authenticated the server will return an encoded token string
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),   //token string has an expiration time
                AllowInsecureHttp = true
           
            };

            //tell the application that we need to use the above options to authenticate the user
            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
