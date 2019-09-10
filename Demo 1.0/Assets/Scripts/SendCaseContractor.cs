using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class SendCaseContractor : MonoBehaviour
{ 
    
    // Use this for initialization
    public void sendReport(string receiverName, string caseDetails , string contractorEmail)
    {

        StartCoroutine(SendDailyReportRounds( receiverName,  caseDetails,  contractorEmail));
    }

    /*IEnumerator CombineReport(string receiverName, string caseDetails, string contractorEmail)
    {

        yield return new WaitForSeconds(.1f);

        System.DateTime dt = (System.DateTime.Today);
        string fileName = dt.DayOfWeek + dt.ToString("dd-MMMM");
        //StartCoroutine (tryExcel(fileName));

        StartCoroutine(SendDailyReportRounds(fileName));
    }*/

    IEnumerator SendDailyReportRounds(string receiverName, string caseDetails, string contractorEmail)
    {

        yield return new WaitForSeconds(0.1f);


        SmtpClient SmtpServer = new SmtpClient("smtp.ipage.com");


        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("hasan@imsc.org.au");
        //mail.To.Add(emailInput.text);
        mail.To.Add(contractorEmail);
        mail.CC.Add("swehu1988@gmail.com");

        mail.Subject = "New case for Monarco Estate" + (System.DateTime.Now.Day).ToString() + "-" +
            System.DateTime.Now.Month + "-" +
            System.DateTime.Now.Year;
        mail.Body = "Dear " + receiverName + ", \nYour quotation is required for the below case:\n" +

            caseDetails +
            ". \n\nThanks,\n iMSC support team";
        SmtpServer.Port = 587; //  
        SmtpServer.Credentials = new System.Net.NetworkCredential("hasan@imsc.org.au", "iMSC@123") as ICredentialsByHost;
        SmtpServer.EnableSsl = true;

        // mail.Attachments.Add(new Attachment(ruta));
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
                return true;
            };
        SmtpServer.Send(mail);
        Debug.Log("mail Sent...");

         

    }
}
