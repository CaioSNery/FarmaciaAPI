using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmaciaSOFT.Interfaces;
using FarmaciaSOFT.Settings;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace FarmaciaSOFT.Services
{
    public class SMSService : ISMSService
    {

        private readonly TwilioSettings _twilio;
        private static bool _twilioInitialized = false;
        public SMSService(IOptions<TwilioSettings> options)
        {
            _twilio = options.Value;

        }
        public async Task EnviarSMSAsync(string numero, string mensagem)
        {

            if (!_twilioInitialized)
            {
                TwilioClient.Init(_twilio.AccountSID, _twilio.AuthToken);
                _twilioInitialized = true;
            }
            var to = new PhoneNumber(numero);            
            var from = new PhoneNumber(_twilio.FromNumber); 

            var sms = await MessageResource.CreateAsync(
            to: to,
            from: from,
            body: mensagem
        );

        Console.WriteLine($"✅ SMS enviado com SID: {sms.Sid}");
        }
    }
}