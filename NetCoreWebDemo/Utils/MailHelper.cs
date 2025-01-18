using Entities;
using System;
using System.Net;
using System.Net.Mail;

namespace NetCoreWebDemo.Utils
{
	public class MailHelper/*mail işlemlerini buradan yapacagız*/
	{
		public static bool SendMail(Contact contact)/*try ile dogru ise true yanlıs ise false dönecek*/
		{
			try
			{
				//gmail smtp bilgileri kendi sitenizin adını ve alan adını yazınız
				SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
				client.Credentials = new NetworkCredential("email kullanıcı adı", "email şifre");
				//client.EnableSsl = true; eger mailde sll kullanıyorsa bu satırı aktif ediniz
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
	}
}
