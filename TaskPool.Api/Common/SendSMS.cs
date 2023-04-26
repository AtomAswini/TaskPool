using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Collections.Specialized;
namespace TaskPool.Api.Common
{
    public class SendSMS
    {
        public string sendSMS(string phoneNumber)
        {
            String message = HttpUtility.UrlEncode("Test Message from TaskPool OTP Generation. ");
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "bVxOkaC3kkk-f8IBXo4xVwBIxIXWCqWlaFzDPEhyRM"},
                {"numbers" , phoneNumber},
                {"message" , message},
                {"sender" , "TXTLCL"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
        }
    }
}