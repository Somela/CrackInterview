using CrackInterview.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CrackInterview.DataAccess
{
    public interface IEmailDataAccess
    {
        Task<EmailResponse> EmailOTPRequest(EmailRequest emailRequest);
    }
    public interface IMobileDataAccess
    {
        Task<OTPRequest> PhoneOTPRequest(EmailRequest emailRequest);
    }
    public class OtpResponseClass : IMobileDataAccess, IEmailDataAccess
    {
        public async Task<EmailResponse> EmailOTPRequest(EmailRequest emailRequest)
        {
            EmailResponse emailResponse = new EmailResponse();
            string EmailToken = "12451";
            string message = "Hi Dude ! Here is your Token" + EmailToken;
            MailMessage msg = new MailMessage();
            msg.Sender = new MailAddress(_configuration.GetSection("EmailInfo:Email").Value);
            msg.From = new MailAddress("CrackInterview@crack.com", "Crack-Interview");
            msg.To.Add(emailRequest.ValueType);
            msg.Subject = "OTP";
            msg.Body = message;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Host = "mail.o365am.aig.com";
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = _configuration.GetSection("EmailInfo:Email").Value;
            NetworkCred.Password = _configuration.GetSection("EmailInfo:Password").Value;
            client.UseDefaultCredentials = true;
            client.Credentials = NetworkCred;
            client.Port = 25;
            client.EnableSsl = true;
            client.Send(msg);
            emailResponse.OTPNumber.message = EmailToken;
            emailResponse.StatusCode = 200;
            emailResponse.ValueType = emailRequest.ValueType;
            emailResponse.Message = message;
            return emailResponse;
        }
        private IConfiguration _configuration;
        private IProxiedTwilioClientCreator _IProxiedTwilioClientCreator;
        public OtpResponseClass(IConfiguration configuration, IProxiedTwilioClientCreator IProxiedTwilioClientCreator)
        {
            _configuration = configuration;
            _IProxiedTwilioClientCreator = IProxiedTwilioClientCreator;
        }
        public async Task<OTPRequest> PhoneOTPRequest(EmailRequest emailRequest)
        {
            string SMSToken = "12451";
            string message = "Hi Dude ! Here is your Token" + SMSToken;

            SendSms(message, emailRequest.ValueType).Wait();
            OTPRequest otp = new OTPRequest();
            otp.message = message;
            return otp;
        }
        public async Task SendSms(string messageBody,string ValueType)
        {
            var twilioRestClient = _IProxiedTwilioClientCreator.GetClient();

            // Now that we have our custom built TwilioRestClient,
            // we can pass it to any REST API resource action.
            var message = MessageResource.Create(
                to: new PhoneNumber("+918688198695"),
                from: new PhoneNumber(ValueType),
                body: messageBody,
                // Here's where you inject the custom client
                client: twilioRestClient
            );

            Console.WriteLine(message.Sid);
        }
    }
    
}
