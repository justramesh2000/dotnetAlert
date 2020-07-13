using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel;
using System.ServiceModel.Channels;
using DotNetFramework.ServiceReference1;


namespace DotNetFramework
{
    public class AlertService
    {
        
        private static string GetToken(string clientId, string clientSecret)
        {
            
            return "";
        }

        public AlertService()
        {
            
        }
        public Dictionary<string, Dictionary<string, string>> GetDataExtension()
        {
            Dictionary<string, Dictionary<string, string>> dict = new Dictionary<string, Dictionary<string, string>>();
            SoapClient client = new SoapClient();
            client.ClientCredentials.UserName.UserName = "rameshsinha";
            client.ClientCredentials.UserName.Password = "welcome@3";
            APIObject[] Results;
            String requestID;
            String status ;
            RetrieveRequest1 rr1 = new RetrieveRequest1();
            RetrieveRequest rr = new RetrieveRequest();
            rr.ObjectType = "DataExtensionObject[Alert_Inbox]";
            rr.Properties = new string[]{
                "Alert_Category","Alert_Subject"
            };
            rr1.RetrieveRequest = rr;
            SimpleFilterPart sf = new SimpleFilterPart();
            sf.SimpleOperator = SimpleOperators.equals;
            sf.Property = "ET_Surrogate_ID";

            try
            {
                //var result = Task.Run(async () => client.RetrieveAsync(rr1));
               // var values = result.GetAwaiter().GetResult().GetAwaiter().GetResult();
                var results = client.Retrieve(rr,out requestID, out Results);
                if (Results.Length > 0)
                {
                    for (int i = 0; i < Results.Length; i++)
                    {
                        DataExtensionObject deo = (DataExtensionObject)Results[i];

                        Dictionary<string, string> props = new Dictionary<string, string>();
                        string transactionID = "";

                        foreach (APIProperty prop in deo.Properties)
                        {
                            if (prop.Name == "ET_Transaction_ID")
                            {
                                transactionID = prop.Value;
                            }

                            props[prop.Name] = prop.Value;
                        }

                        dict[transactionID] = props;
                    }
                }

            }
            catch (Exception e)
            {
               
            }
            //var results =   client.RetrieveAsync(rr1);
            return dict;


        }
    }
}