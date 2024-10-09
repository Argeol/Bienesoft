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

        public async Task<ResponseSend> SendEmail(string emailDestination)
        {
            ResponseSend response = new ResponseSend();
            try
            {
                // Configuramos el cliente SMTP
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Host = configServer.HostName; // Asegúrate de que este valor es correcto
                    smtpClient.Port = configServer.PortHost; // Asegúrate de que el puerto es correcto
                    smtpClient.Credentials = new NetworkCredential(
                        configServer.Email, configServer.Password);
                    smtpClient.EnableSsl = true; // Asegúrate de que SSL esté habilitado

                    MailAddress remitente = new MailAddress(configServer.Email, "bienesoft", Encoding.UTF8);
                    MailAddress destinatario = new MailAddress(emailDestination);
                    MailMessage message = new MailMessage(remitente, destinatario);

                    message.Subject = "prueba Correo";
                    message.IsBodyHtml = true;
                    message.Body = "<h1>hola mundo</h1>";
                    await smtpClient.SendMailAsync(message);
                    response.Message = "Correo enviando exitosamente";
                    response.Status = true;
                }
            }


            catch (SmtpException smtpEx)
            {
                // Captura errores específicos de SMTP
                Addlog($"SMTP Error: {smtpEx.Message}");
                response.Message = "Error al enviar el correo: " + smtpEx.Message;
                response.Status = false;
            }
            catch (Exception ex)
            {
                // Captura errores generales
                Addlog($"General Error: {ex.Message}");
                response.Message = "Error inesperado: " + ex.Message;
                response.Status = false;
            }
            return response;
        }


        public void Addlog(string newlog)
        {
            // Define la ruta de la carpeta de logs
            string carpetalog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");

            // Asegúrate de que el directorio de logs exista
            if (!Directory.Exists(carpetalog))
            {
                Directory.CreateDirectory(carpetalog);
            }

            // Define la ruta del archivo de log
            string rutalog = Path.Combine(carpetalog, DateTime.Now.ToString("dd-MM-yyyy") + ".log");

            // Crear el registro del log
            var registro = $"{DateTime.Now}: {newlog}\n";

            // Escribir el log en el archivo usando StreamWriter
            using (StreamWriter writer = new StreamWriter(rutalog, true, Encoding.UTF8))
            {
                writer.Write(registro);
            }
        }

    }

}

