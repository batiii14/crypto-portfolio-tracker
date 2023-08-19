namespace Business.Abstracts
{
    public interface ICoinUpdaterService
    {
        Task<double> GetCoinValueFromApi(string coinName);

    }
}
