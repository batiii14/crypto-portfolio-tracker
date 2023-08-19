using Core.DataAccess;
using Dapper;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.concretes;
using Microsoft.Extensions.Configuration;
using Npgsql;



namespace DataAccess.Concretes
{
    public class CoinUpdaterDal : EfEntityRepositoryBase<CoinUpdater, CoinAppContext>, ICoinUpdaterDal
    {
        private readonly IConfiguration _configuration;

        public CoinUpdaterDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public async Task<CoinUpdater> GetCoinUpdaterByNameAsync(string coinName)
        //{
        //    using var connection = new NpgsqlConnection(_configuration.GetConnectionString("YourConnectionString"));
        //    return await connection.QueryFirstOrDefaultAsync<CoinUpdater>("SELECT * FROM CoinUpdater WHERE CoinName = @CoinName", new { CoinName = coinName });
        //}

        //public async Task<int> UpdateCoinValueAsync(CoinUpdater coinUpdater)
        //{
        //    using var connection = new NpgsqlConnection(_configuration.GetConnectionString("YourConnectionString"));
        //    string query = "UPDATE CoinUpdater SET UpdatedValue = @UpdatedValue, LastUpdated = @LastUpdated WHERE CoinName = @CoinName";
        //    return await connection.ExecuteAsync(query, coinUpdater);
        //}
    }
}
