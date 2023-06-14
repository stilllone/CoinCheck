using CoinCheck.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinCheck.Services
{
    public class ParameterService : IParameterService
    {
        private readonly Dictionary<string, object> _parameters;

        public ParameterService()
        {
            _parameters = new Dictionary<string, object>();
        }

        public T GetParameter<T>(string key)
        {
            if (_parameters.ContainsKey(key))
            {
                return (T)_parameters[key];
            }
            return default;
        }

        public void SetParameter<T>(string key, T value)
        {
            if (_parameters.ContainsKey(key))
            {
                _parameters[key] = value;
            }
            else
            {
                _parameters.Add(key, value);
            }
        }
    }
}
