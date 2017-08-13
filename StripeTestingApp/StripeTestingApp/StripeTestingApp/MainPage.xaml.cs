using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


//Note: in order to test this, use NuGet to install the following modules for all three platforms:
//Microsoft.Bcl.Build
//System.net.http
//stripe.net


namespace StripeTestingApp
{
	public partial class MainPage : ContentPage
	{
        HttpClient client;

        public MainPage()
        {
            InitializeComponent();

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public void OnButtonClicked(object sender, EventArgs args)
        {
            //TODO see if this is all that needs to be done to properly call an async method
            var response = RefreshDataAsync();
        }

        public async Task<List<TodoItem>> RefreshDataAsync()
        {
            

            //
            //Test the stripe component
            //


            //StripeConfiguration.SetApiKey("pk_test_6pRNASCoBOKtIshFeQd4XMUh");
            StripeConfiguration.SetApiKey("sk_test_BQokikJOvBiI2HlWgH4olfQ2");


            var balanceService = new StripeBalanceService();
            StripeBalance balance = balanceService.Get();

            //Place the breakpoint around here to check out the balance object











            //
            //Test the HTTP rest communications component.
            //

            //This will be used for anything that the app apis don't directly cover
            //We might not need it - it's basically our lower level fallback

            //// RestUrl = http://developer.xamarin.com:8081/api/todoitems/
            //var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            var uri = new Uri(string.Format(@"https://api.stripe.com", string.Empty));

            var response = await client.GetAsync(uri);
            //TODO
            //This will fail validation from stripe, but it is the mechanism to perform general REST requests
            if (response.IsSuccessStatusCode)
            {
                //Place a breakpoint here and check out the response
                var content = await response.Content.ReadAsStringAsync();
                //Items = JsonConvert.DeserializeObject<List<TodoItem>>(content);
            }






            //TODO!
            return new List<TodoItem>();
        }
	}
}
