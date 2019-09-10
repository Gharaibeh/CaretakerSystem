using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
using System.IO;
using System.Text;

using UnityEngine;
 using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class CreatePDF : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(SendDailyReportRounds("somepdf"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SendDailyReportRounds(string filename)
    {

        string desktopPath = Application.dataPath;//.GetFolderPath (System.Environment.SpecialFolder.DesktopDirectory);

        string ruta = desktopPath + "/" + filename + ".csv";

        //sr.Write(datosCSV);
        if (File.Exists(ruta))
        {
            File.Delete(ruta);
        }

        string datosCSV = "Survey Report" + System.Environment.NewLine;
        datosCSV += " IMEI " +  System.Environment.NewLine + (System.DateTime.Now.Day).ToString() + "."
            + (System.DateTime.Now.Month).ToString() + "."
            + (System.DateTime.Now.Year).ToString() +
            System.Environment.NewLine + System.Environment.NewLine;
        datosCSV += "Total Surveys, IMEI, Avatar, Date, Time, Durdation, " +
            "q1,q2,q3,q4,q5,q6,q7,q8,q9,q10,q11,q12,q13,q14,q15,q16,q17,q18,q19,q20,q21,q22,q23,q24,q25,q26,q27,q28,q29,q30" + System.Environment.NewLine;

       

        //sr.Write(datosCSV);
        if (File.Exists(ruta))
        {
            File.Delete(ruta);
        }
        StreamWriter outStream = System.IO.File.CreateText(ruta);
        outStream.WriteLine(datosCSV);
        outStream.Close();
        
        //FileInfo fInfo = new FileInfo(ruta);
        //fInfo.IsReadOnly = false;

        //sr.Close();            

        yield return new WaitForSeconds(0.1f);

        print(Application.dataPath);
        Application.OpenURL(ruta);


    }
    }
