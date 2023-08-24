using Business.Abstracts;
using DataAccess.Abstracts;
using Entities.concretes;
using Newtonsoft.Json.Linq;

namespace Business.Concretes
{
    public class CoinUpdaterManager : ICoinUpdaterService
    {
        private readonly ICoinUpdaterDal _coinUpdaterDal;
        private readonly ICoinDal _coinDal;

        public CoinUpdaterManager(ICoinUpdaterDal coinUpdaterDal, ICoinDal coinDal)
        {
            _coinUpdaterDal = coinUpdaterDal;
            _coinDal = coinDal;
        }
 

        public async Task<double> GetCoinValueFromApi(string coinName)
        {
            Coin coin = new Coin();
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient httpClient = new HttpClient(clientHandler))
                {
                    string apiUrl = $"https://api.coingecko.com/api/v3/simple/price?ids={coinName}&vs_currencies=usd";

                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        JObject apiResponse = JObject.Parse(jsonResponse);

                        if (apiResponse.ContainsKey(coinName))
                        {
                            double coinValue = (double)apiResponse[coinName]["usd"];
                             coin = _coinDal.GetList().Where(p => p.Name.Equals(coinName)).Single();
                            coin.Value= coinValue;
                            _coinDal.Update(coin);
                            return coinValue;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"API request failed with status code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while getting coin value: {ex.Message}");
            }

            return coin.Value; 
        }

        public void UpdateAlltheCoins()
        {
            foreach (var coin in _coinDal.GetList().ToArray())
            {
                GetCoinValueFromApi(coin.Name);
            }
        }
    }
   

    

   
}
