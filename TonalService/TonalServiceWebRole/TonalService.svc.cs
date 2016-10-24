using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ToneReader;

namespace TonalServiceWebRole
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class TonalService : ITonalService
    {
        public string GetAnalysis(string email, string text, string userName, string password)
        {
            if (IsValidUser(userName, password) == false)
            {
                return "Invalid Login Credentials";
            }
            var provider = new AnalysisProvider();            
            provider.Analyze(email, text);
            return provider.EmailAnalysis;
        }
        private bool IsValidUser(string userName, string password)
        {
            if (userName != null && password != null)
            {
                if (userName == ConfigurationManager.AppSettings.Get("UserName") && password == ConfigurationManager.AppSettings.Get("Password"))
                {  
                    return true;
                }
            }

            return false;

        }
    }
}
