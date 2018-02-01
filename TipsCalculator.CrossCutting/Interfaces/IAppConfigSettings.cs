namespace TipsCalculator.CrossCutting.Interfaces
{
    public interface IAppConfigSettings
    {
        string RatesApiUrl { get; }

        string TransactionApiUrl { get; }
    }
}
