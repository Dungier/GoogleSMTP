using Org.BouncyCastle.Crypto.Macs;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;

class Program
{
    static void Main()
    {
        string smtpServer = "smtp.gmail.com";
        int smtpPort = 587;
        string senderEmail = "example@gmail.com";
        string senderPassword = "123qwe";
        string filePath = @"path to file";
        SendEmail(smtpServer, smtpPort, senderEmail, senderPassword, filePath);
    }

    static void SendEmail(string smtpServer, int smtpPort, string senderEmail, string senderPassword, string filePath)
    {
        SmtpClient client = new SmtpClient(smtpServer, smtpPort)
        {
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(senderEmail, senderPassword),
            EnableSsl = true
        };
        MailMessage message = new MailMessage(senderEmail, "mailTO@gmail.com")
        {
            Subject = "Hello World!",
            Body = "Place here text",
            IsBodyHtml = false
        };
        Attachment attachment = new Attachment(filePath);
        message.Attachments.Add(attachment);

        try
        {
            client.Send(message);
            Console.WriteLine("Письмо успешно отправлено.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при отправке письма: " + ex.Message);
        }
    }
}