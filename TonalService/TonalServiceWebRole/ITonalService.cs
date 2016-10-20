using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ToneReader;

namespace TonalServiceWebRole
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITonalService
    {
        [OperationContract]
        string GetAnalysis(string email, string text);
    }
    
    public class EmailAnalysis : ITonalService
    {
        public string GetAnalysis(string email, string text)
        {
            var provider = new AnalysisProvider();
            provider.Analyze(email, text);
            return provider.EmailAnalysis;
        }
    }
}
