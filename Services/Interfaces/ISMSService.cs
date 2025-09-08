using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaSOFT.Interfaces
{
    public interface ISMSService
    {
        Task EnviarSMSAsync(string numero, string mensagem);
    }
}