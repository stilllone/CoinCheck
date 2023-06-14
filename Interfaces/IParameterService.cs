using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinCheck.Interfaces
{
    public interface IParameterService
    {
        T GetParameter<T>(string key);
        void SetParameter<T>(string key, T value);
    }
}
