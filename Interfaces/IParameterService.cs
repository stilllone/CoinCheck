namespace CoinCheck.Interfaces
{
    public interface IParameterService
    {
        T GetParameter<T>(string key);
        void SetParameter<T>(string key, T value);
    }
}
