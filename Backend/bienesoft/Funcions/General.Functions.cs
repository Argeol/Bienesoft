using bienesoft.Models;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace bienesoft.Funcions
{
    public class GeneralFunction { 
         //configuramos
         public ConfigServer configServer { get; set; }
         public GeneralFunction(IConfiguration configuration)
    {
        configServer = configuration.GetSection("ConfigServerEmail")
         .Get<ConfigServer>();

    }
    public IConfiguration Configuration { get; set; }

    public async Task<ResponseSend> SendEmail(string EmailDestination)
    {
        ResponseSend response = new ResponseSend();
        try
        {
            //le pasamos la configuracion al servidor
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = configServer.HostName;
            smtpClient.Port = configServer.PortHost;
            smtpClient.Credentials = new NetworkCredential(
                configServer.Email, configServer.Password);
            smtpClient.EnableSsl = true;

            MailAddress remitente = new MailAddress(configServer.Email, "bienesoft",
                Encoding.UTF8);
            MailAddress destinatario = new MailAddress(EmailDestination);
            MailMessage message = new MailMessage(remitente, destinatario);
            message.IsBodyHtml = true;
            message.Subject = "ASUNTO";
            message.Body = "<h1>Hola</h1>";
            message.BodyEncoding = Encoding.UTF8;


            await smtpClient.SendMailAsync(message);

            response.Message = "Correo enviado exictosamente";
            response.Status = true;
        }
        catch (Exception ex)
        {
            Addlog(ex.ToString());
            response.Message = ex.Message;
            response.Status = false;
        }
        return response;
    }
    
        public void Addlog(string newlog)
        {
            string carpetalog = AppDomain.CurrentDomain.BaseDirectory + "logs//";
            if (!Directory.Exists(carpetalog))
            {
                Directory.CreateDirectory(carpetalog);
            }
            string rutalog = carpetalog + AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("dd-MM-yyyy") + ".log";
            var registro = DateTime.Now + "-" + newlog + "\n";
            var byteslog = UTF8Encoding.UTF8.GetBytes(registro);
            using (FileStream log = File.Open(rutalog, FileMode.Append)) 
            { 
                log.Write(byteslog, 0 , byteslog.Length); 
            }
 
        }

    }
}
