
using ImageMarkingContract.DTO;
using ImageMarkingUsersDAL;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OracleDAL;
using SignInService;
using System.IO;

namespace NUnitTestImageMarkingSystem
{
    public class SignInTests
    {
        
        [SetUp]
        public void Setup()
        {

           var builder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddEnvironmentVariables();

            IConfiguration config = builder.Build();
        }

        [Test]
       public void SignInOkTest()
         {
             var signInService = new SignInServiceImpl(new ImageMarkingUsersDALImpl(new InfraDAL(),_configuration));
             SignInRequest request = new SignInRequest();
             request.Email = "888";
             var response = signInService.SignIn(request);
             Assert.IsInstanceOf(typeof(SignInResponse), response);
         }

          [Test]
          public void SignInInvalidEmailOrUserName()
          {
              var signInService = new SignInServiceImpl(new ImageMarkingUsersDALImpl(new InfraDAL()));
             SignInRequest request = new SignInRequest();
             request.Email = "88888";
              var response = signInService.SignIn(request);
              Assert.IsInstanceOf(typeof(SignInResponseOK), response);
          }

    }
}