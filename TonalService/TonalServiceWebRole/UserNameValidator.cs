using System.Configuration;
using System.ServiceModel;
using System.IdentityModel.Selectors;

namespace TonalServiceWebRole
{
    public class UserNameValidator : UserNamePasswordValidator
    {
        private const string USERNAME_ELEMENT_NAME = "userName";

        private const string PASSWORD_ELEMENT_NAME = "password";

        private const string FAULT_EXCEPTION_MESSAGE = "UserName or Password is incorrect!";
        public override void Validate(string userName = "", string password = "")
        {
            var validateUserName = ConfigurationManager.AppSettings[USERNAME_ELEMENT_NAME];
            var validatePassword = ConfigurationManager.AppSettings[PASSWORD_ELEMENT_NAME];
            var validateCondition =
                userName.Equals(validateUserName) && password.Equals(validatePassword);
            if (!validateCondition)
            {
                throw new FaultException(FAULT_EXCEPTION_MESSAGE);
            }
        }
    }
}