using Bienesoft.Models;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace Bienesoft.Function
{

    public class GeneralFuction
        {
            public IConfiguration _Configuration { get; set; }
            public ConfigServer ConfigServer { get; set; }
            public GeneralFuction(IConfiguration configuration)
            {
                _Configuration = configuration;
                ConfigServer = configuration.GetSection("ConfiServerEmail").Get<ConfigServer>();
            }
            public async Task<ResponseSend> SendEmail(String EmailDestino)
            {
                ResponseSend response = new ResponseSend();

                try
                {
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = ConfigServer.HostName;
                    smtpClient.Port = ConfigServer.PortHost;
                    smtpClient.Credentials = new NetworkCredential(ConfigServer.Email, ConfigServer.Password);
                    smtpClient.EnableSsl = true;
                    MailAddress remitente = new MailAddress(ConfigServer.Email, "Bienesoft", Encoding.UTF8);
                    MailAddress destinatario = new MailAddress(EmailDestino);
                    MailMessage message = new MailMessage(remitente, destinatario);

                    message.Subject = "Prueva correo";
                    message.IsBodyHtml = true;
                    await smtpClient.SendMailAsync(message);
                    response.Message = "Correo enviado exitosamente";
                    response.Status = true;
                }
                catch (Exception ex)
                {
                    addloig(ex.ToString());
                    response.Message = ex.Message;
                    response.Status = false;

                }
                return response;
            }

        
        public void addloig(string newlog)
        {
            string carpetalog = AppDomain.CurrentDomain.BaseDirectory + "logs//";
            if (!Directory.Exists(carpetalog))
            {
                Directory.CreateDirectory(carpetalog);
            }
            string RutaLog = carpetalog + AppDomain.CurrentDomain.FriendlyName + " " + DateTime.Now.ToString("dd-MM-yyyy") + ".log";
            var registro = DateTime.Now + " " + newlog + "\n";
            var logs = new UTF8Encoding().GetBytes(registro);
            using (FileStream log = File.Open(RutaLog, FileMode.Append))
            {
                log.Write(logs, 0, logs.Length);
            }
        }

        internal void addloig(object value)
        {
            throw new NotImplementedException();
        }
    }
}