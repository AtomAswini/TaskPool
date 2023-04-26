using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web.Configuration;

namespace TaskPool.Common
{
   public class EmailProfile
    {
        /// <summary>
        /// email_profiles.id
        /// </summary>
        private int _Id;
        /// <summary>
        /// email_profiles.email_address
        /// </summary>
        private string _EmailAddress;
        /// <summary>
        /// email_profiles.host
        /// </summary>
        private string _Host;
        /// <summary>
        /// email_profiles.user_name
        /// </summary>
        private string _UserName;
        /// <summary>
        /// email_profiles.password
        /// </summary>
        private string _Password;
        /// <summary>
        /// email_profiles.enabled
        /// </summary>
        private bool _Enabled;
        /// <summary>
        /// email_profiles.display_name
        /// </summary>
        private string _DisplayName;
        /// <summary>
        /// email_profiles.date_created
        /// </summary>
        private DateTime _DateCreated;
        /// <summary>
        /// email_profiles.date_last_modified
        /// </summary>
        private DateTime _DateLastModified;

        /// <summary>
        /// Gets and Sets the Id Property.
        /// </summary>
        public int Id
        {
            get { return (this._Id); }
            set { this._Id = value; }
        }
        /// <summary>
        /// Gets and Sets the EmailAddress Property.
        /// </summary>
        public string EmailAddress
        {
            get { return (this._EmailAddress); }
            set { this._EmailAddress = value; }
        }
        /// <summary>
        /// Gets and Sets the Host Property.
        /// </summary>
        public string Host
        {
            get { return (this._Host); }
            set { this._Host = value; }
        }
        /// <summary>
        /// Gets and Sets the UserName Property.
        /// </summary>
        public string UserName
        {
            get { return (this._UserName); }
            set { this._UserName = value; }
        }
        /// <summary>
        /// Gets and Sets the Password Property.
        /// </summary>
        public string Password
        {
            get { return (this._Password); }
            set { this._Password = value; }
        }
        /// <summary>
        /// Gets and Sets the Enabled Property.
        /// </summary>
        public bool Enabled
        {
            get { return (this._Enabled); }
            set { this._Enabled = value; }
        }
        /// <summary>
        /// Gets and Sets the DisplayName Property.
        /// </summary>
        public string DisplayName
        {
            get { return (this._DisplayName); }
            set { this._DisplayName = value; }
        }
        /// <summary>
        /// Gets and Sets the DateCreated Property.
        /// </summary>
        public DateTime DateCreated
        {
            get { return (this._DateCreated); }
            set { this._DateCreated = value; }
        }
        /// <summary>
        /// Gets and Sets the DateLastModified Property.
        /// </summary>
        public DateTime DateLastModified
        {
            get { return (this._DateLastModified); }
            set { this._DateLastModified = value; }
        }
        public EmailProfile(int pId, string pEmailAddress, string pHost, string pUserName, string pPassword, bool pEnabled, string pDisplayName, DateTime pDateCreated, DateTime pDateLastModified)
        {
            this._Id = pId;
            this._EmailAddress = pEmailAddress;
            this._Host = pHost;
            this._UserName = pUserName;
            this._Password = pPassword;
            this._Enabled = pEnabled;
            this._DisplayName = pDisplayName;
            this._DateCreated = pDateCreated;
            this._DateLastModified = pDateLastModified;
        }
        public EmailProfile()
        {
            
        }
        public static bool QuickSendEmail(bool pIsHtmlBody, string pBody, string pSubject, MailPriority pPriority, EmailProfile pEmailProfile, List<MailAddress> pTos, bool useConfiguration = false)
        {
            try
            {
                if (pEmailProfile == null || pTos == null || pTos.Count == 0)
                    return false;

                bool enableEmailOverride;
                string[] overrideEmailAddresses;
                if (useConfiguration)
                {
                    //DB Setup for all configuration if required
                    enableEmailOverride = false;
                    overrideEmailAddresses = WebConfigurationManager.AppSettings["OverrideEmailAddresses"].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                }
                else
                {
                    enableEmailOverride = WebConfigurationManager.AppSettings["TAMEnvironment"].ToUpper() == "PROD" ? false : true;
                    overrideEmailAddresses = WebConfigurationManager.AppSettings["OverrideEmailAddresses"].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                }

                var emailSent = false;

                SmtpClient lSmtpClient = new SmtpClient(pEmailProfile.EmailAddress, 25);
                lSmtpClient.Credentials = new System.Net.NetworkCredential(pEmailProfile.UserName, pEmailProfile.Password);
                lSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                lSmtpClient.DeliveryFormat = SmtpDeliveryFormat.International;

                var lMessage = new MailMessage();
                lMessage.IsBodyHtml = pIsHtmlBody;
                lMessage.Body = pBody;
                lMessage.From = new MailAddress(pEmailProfile.UserName, pEmailProfile.DisplayName);
                lMessage.Priority = pPriority;
                lMessage.Subject = pSubject;

                lMessage.To.Clear();
                foreach (var lMailAddress in pTos)
                    lMessage.To.Add(lMailAddress);

                if (enableEmailOverride)
                {
                    lMessage.To.Clear();
                    foreach (var address in overrideEmailAddresses)
                        lMessage.To.Add(new MailAddress(address));
                    lSmtpClient.Send(lMessage);
                    emailSent = true;
                }
                else
                {
                    if (WebConfigurationManager.AppSettings["TAMEnvironment"].ToUpper() == "PROD")
                        lSmtpClient.Send(lMessage);
                    emailSent = true;
                }

                return emailSent;
            }
            catch (Exception exc)
            {
                return false;
            }
        }

        public static EmailProfile GetEmailProfile()
        {
            var lReturn = new EmailProfile();
            try
            {
                
                EmailProfile lEmailProfile = new EmailProfile();
                lEmailProfile.EmailAddress = WebConfigurationManager.AppSettings["EmailProfileEmailAddress"];
                lEmailProfile.Host = WebConfigurationManager.AppSettings["EmailProfileHost"];
                lEmailProfile.UserName = WebConfigurationManager.AppSettings["EmailProfileUserName"];
                lEmailProfile.Password = WebConfigurationManager.AppSettings["EmailProfilePassword"];
                lEmailProfile.DisplayName = WebConfigurationManager.AppSettings["EmailProfileDisplayName"];
                lReturn = lEmailProfile;
            }
            catch (Exception exc)
            {
              
            }
            return lReturn;
        }

        public static void _SendApiEmail(string ToEmail,string Comment,string Subject)
        {
            
            try
            {
                var ApiSubmittedEmailAddresses = ToEmail.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (ApiSubmittedEmailAddresses.Length > 0)
                {
                    var lBody = new StringBuilder();
                    lBody.Append("<!doctype html>");
                    lBody.Append("<html>");
                    lBody.Append("<head>");
                    lBody.Append("<meta name='viewport' content='width = device - width' />");
                    lBody.Append("<meta http-equiv='Content - Type' content='text / html; charset = UTF - 8' />");
                    lBody.Append("<title>TrickyCasa.com</title>");

                    lBody.Append("<style>");
                    lBody.Append("img {border: none;-ms-interpolation-mode: bicubic;max-width: 100%;}");
                    lBody.Append("body {background-color: #f6f6f6;font-family: sans-serif;-webkit-font-smoothing: antialiased;font-size: 14px;line-height: 1.4;margin: 0;padding: 0;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%;}");
                    lBody.Append("table {border-collapse: separate;mso-table-lspace: 0pt;mso-table-rspace: 0pt;width: 100%;}");
                    lBody.Append("table td {font-family: sans-serif;font-size: 14px;vertical-align: top;}");
                    lBody.Append(".body {background-color: #f6f6f6;width: 100%;}");
                    lBody.Append(".container {display: block;margin: 0 auto !important;max-width: 580px;padding: 10px;width: 580px;}");
                    lBody.Append(".content {box-sizing: border-box;display: block;margin: 0 auto;max-width: 580px;padding: 10px;}");
                    lBody.Append(".main {background: #ffffff;border-radius: 3px;width: 100%;}.wrapper {box-sizing: border-box;padding: 20px;}");
                    lBody.Append(".content-block {padding-bottom: 10px;padding-top: 10px;}");
                    lBody.Append(".footer {clear: both;margin-top: 10px;text-align: center;width: 100%;}.footer td,.footer p,.footer span,.footer a {color: #999999;font-size: 12px;text-align: center;}");
                    lBody.Append("h1,h2,h3,h4 {color: #000000;font-family: sans-serif;font-weight: 400;line-height: 1.4;margin: 0;margin-bottom: 30px;}");
                    lBody.Append("h1 {font-size: 35px;font-weight: 300;text-align: center;text-transform: capitalize;}");
                    lBody.Append("p,ul,ol {font-family: sans-serif;font-size: 14px;font-weight: normal;margin: 0;margin-bottom: 15px;}");
                    lBody.Append("p li,ul li,ol li {list-style-position: inside;margin-left: 5px;}a {color: #3498db;text-decoration: underline;}");
                    lBody.Append(".btn {box-sizing: border-box;width: 100%;}.btn > tbody > tr > td {padding-bottom: 15px;}.btn table {width: auto;}");
                    lBody.Append(".btn table td {background-color: #ffffff;border-radius: 5px;text-align: center;}");
                    lBody.Append(".btn a {background-color: #ffffff;border: solid 1px #3498db;border-radius: 5px;box-sizing: border-box;color: #3498db;cursor: pointer;display: inline-block;");
                    lBody.Append("font-size: 14px;font-weight: bold;margin: 0;padding: 12px 25px;text-decoration: none;text-transform: capitalize;}");
                    lBody.Append(".btn-primary table td {background-color: #3498db;}.btn-primary a {background-color: #3498db;border-color: #3498db;color: #ffffff;}");
                    lBody.Append(".last {margin-bottom: 0;}.first {margin-top: 0;}.align-center {text-align: center;}.align-right { text-align: right;}");
                    lBody.Append(".align-left {text-align: left;}.clear {clear: both;}.mt0 {margin-top: 0;}.mb0 {margin-bottom: 0;}");
                    lBody.Append(".preheader {color: transparent;display: none;height: 0;max-height: 0;max-width: 0;opacity: 0;overflow: hidden;mso-hide: all;visibility: hidden;width: 0;}");
                    lBody.Append(".powered-by a {text-decoration: none;}hr {border: 0;border-bottom: 1px solid #f6f6f6;margin: 20px 0;}");
                    lBody.Append("@media only screen and (max-width: 620px) {table[class=body] h1 {font-size: 28px !important;margin-bottom: 10px !important;}");
                    lBody.Append("table[class=body] p,table[class=body] ul,table[class=body] ol,table[class=body] td,table[class=body] span,table[class=body] a {font-size: 14px !important;line-height: 25px;}");
                    lBody.Append("table[class=body] .wrapper,table[class=body] .article {padding: 10px !important;}table[class=body] .content {padding: 0 !important;}");
                    lBody.Append("table[class=body] .container {padding: 0 !important;width: 100% !important;}");
                    lBody.Append("table[class=body] .main {border-left-width: 0 !important;border-radius: 0 !important;border-right-width: 0 !important;}");
                    lBody.Append("table[class=body] .btn table {width: 100% !important;}table[class=body] .btn a {width: 100% !important;}");
                    lBody.Append("table[class=body] .img-responsive {height: auto !important;max-width: 100% !important;width: auto !important; }}");
                    lBody.Append("@media all {.ExternalClass {width: 100%;}.ExternalClass,.ExternalClass p,.ExternalClass span,.ExternalClass font,.ExternalClass td,.ExternalClass div {line-height: 100%;}");
                    lBody.Append(".apple-link a {color: inherit !important;font-family: inherit !important;font-size: inherit !important;font-weight: inherit !important;line-height: inherit !important;text-decoration: none !important;}");
                    lBody.Append("#MessageViewBody a {color: inherit;text-decoration: none;font-size: inherit;font-family: inherit;font-weight: inherit;line-height: inherit;}");
                    lBody.Append(".btn-primary table td:hover {background-color: #34495e !important;}.btn-primary a:hover {background-color: #34495e !important; border-color: #34495e !important;}}");
                    lBody.Append("</style>");

                    lBody.Append("</head>");
                    lBody.Append("<body class=''>");
                    lBody.Append("<span class='preheader'>This is preheader text. Some clients will show this text as a preview.</span>");
                    lBody.Append("<table role='presentation' border='0' cellpadding='0' cellspacing='0' class='body'>");
                    lBody.Append("<tr>");
                    lBody.Append("<td>&nbsp;</td>");
                    lBody.Append("<td class='container'>");
                    lBody.Append("<div class='content'>");
                    lBody.Append("<table role='presentation'>");
                    lBody.Append("<tr>");
                    lBody.Append("<td align='center' valign='middle' class='wrapper'><img src='http://trickycash.com/img/logo-dark.png'></td>");
                    lBody.Append("</tr>");
                    lBody.Append("</table>");
                    lBody.Append("<table role='presentation' class='main'>");
                    lBody.Append("<tr>");
                    lBody.Append("<td class='wrapper'>");
                    lBody.Append("<table role='presentation' border='0' cellpadding='0' cellspacing='0'>");
                    lBody.Append("<tr>");
                    lBody.Append("<td>");
                    lBody.Append("<p><strong>Hi There,</strong></p>");
                    lBody.Append("<p>");
                    lBody.Append(Comment);
                    lBody.Append("</p>");
                    lBody.Append("<p>&nbsp;</p>");
                    lBody.Append("<p><strong>Thanks</strong></p>");
                    lBody.Append("<p>Team TrickyCash.</p>");
                    lBody.Append("</td>");
                    lBody.Append("</tr>");
                    lBody.Append("</table>");
                    lBody.Append("</td>");
                    lBody.Append("</tr>");
                    lBody.Append("</table>");
                    lBody.Append("<div class='footer'>");
                    lBody.Append("<table role='presentation' border='0' cellpadding='0' cellspacing='0'>");
                    lBody.Append("<tr>");
                    lBody.Append("<td class='content-block'>");
                    lBody.Append("<a href='#'><img src='http://trickycash.com/img/googleplay.png' border='0'></a>");
                    lBody.Append("<a href='#'><img src='http://trickycash.com/img/appstore.png' border='0'></a>");
                    lBody.Append("</td>");
                    lBody.Append("</tr>");
                    lBody.Append("<tr>");
                    lBody.Append("<td class='content-block'>");
                    lBody.Append("<span class='apple-link'>Please do not replay this email. Replies to this message are</span><br>");
                    lBody.Append("routed to an unmonitored mailbox<br>");
                    lBody.Append("For more information visit our <a href='http://grosseriz.com/'>trickycase.com</a> or <a href='http://grosseriz.com/'>Contact us here</a>");
                    lBody.Append("</td>");
                    lBody.Append("</tr>");
                    lBody.Append("<tr>");
                    lBody.Append("<td class='content-block powered-by'>");
                    lBody.Append("Copyright © 2020 trickycase.");
                    lBody.Append("</td>");
                    lBody.Append("</tr>");
                    lBody.Append("</table>");
                    lBody.Append("</div>");
                    lBody.Append("</div>");
                    lBody.Append("</td>");
                    lBody.Append("<td>&nbsp;</td>");
                    lBody.Append("</tr>");
                    lBody.Append("</table>");
                    lBody.Append("</body>");
                    lBody.Append("</html>");

                    var emailProfile = GetEmailProfile();

                    foreach (var toEmail in ApiSubmittedEmailAddresses)
                    {
                       
                        if (toEmail.Trim().Length > 0)
                            QuickSendEmail(true, lBody.ToString(), Subject, MailPriority.High, emailProfile, new List<MailAddress>() {new MailAddress(toEmail)});
                    }
                }
            }
            catch (Exception ex)
            {
               //log exception to log table
            }
            finally
            {
               
            }
        }


    }

    public class EmailRecord
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string ReviewComment { get; set; }
        public string Subject { get; set; }
    }
}
