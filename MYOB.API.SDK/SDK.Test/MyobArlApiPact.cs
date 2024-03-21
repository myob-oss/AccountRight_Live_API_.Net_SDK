using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PactNet;
using PactNet.Mocks.MockHttpService;

namespace SDK.Test
{
    public class MyobArlApiPact : IDisposable
    {
        public IPactBuilder PactBuilder { get; private set; }
        public IMockProviderService MockProviderService { get; private set; }

        public int MockServerPort { get { return 9000; } }
        public string MockProviderServiceBaseUri { get { return String.Format("http://localhost:{0}", MockServerPort); } }

        public MyobArlApiPact()
        {
            PactBuilder = new PactBuilder()
                .ServiceConsumer("Consumer")
                .HasPactWith("MYOB ARL API");

            MockProviderService = PactBuilder.MockService(MockServerPort); //Configure the http mock server
            //NOTE: You can also use SSL by passing true as the second param. This will however require a valid SSL certificate installed and bound with netsh (netsh http add sslcert ipport=0.0.0.0:port certhash=thumbprint appid={app-guid}) on the machine running the test. See https://groups.google.com/forum/#!topic/nancy-web-framework/t75dKyfgzpg
        }

        public void Dispose()
        {
            PactBuilder.Build(); //NOTE: Will save the pact file once finished
        }
    }
}
