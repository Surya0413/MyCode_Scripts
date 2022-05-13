using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using Core;
using System.Net.Sockets;
using System.Threading;
using System.Configuration;

namespace ShowbizStudio_Scripts
{
    public class GnerateReports
    {


        private static List<ReportParams> reportParam;
        private static List<ReportParams> reportFail;
        static Stopwatch stopWatch = new Stopwatch();
        static double d = 0.00;
        static string time = "";
        static StringBuilder sb;
        static StringBuilder sbFail;
        static string environ = "QA";
        public static List<ReportParams> IniTialzeList()
        {
            if (reportParam == null)
            {
                reportParam = new List<ReportParams>();
                sb = new StringBuilder();
            }
            return reportParam;
        }

        public static List<ReportParams> IniTialzeListFail()
        {
            if (reportFail == null)
            {
                reportFail = new List<ReportParams>();              
            }
            return reportFail;
        }
        public static void Start()
        {
            stopWatch.Reset();
            stopWatch.Start();

        }
        public static void Stop()
        {
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            time = ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds;
            d = Math.Round(ts.TotalMinutes, 1, MidpointRounding.AwayFromZero);
        }
        public static void CreateReport(TestContext conText)
        {
            Stop();
            reportParam = IniTialzeList();
            reportFail = IniTialzeListFail();             
            reportParam.Add(new ReportParams() { TestCaseID = Convert.ToString(DataHandler.Instance.GetParam("TestCaseID", "--")), TestCaseName = Convert.ToString(conText.Test.MethodName), Stats = conText.Result.Outcome.Status.ToString(), MyProperty = time, SuiteName = Convert.ToString(conText.Test.ClassName),Browser= DataHandler.Instance.GetParam("Browser","Edge"),Errors = DataHandler.Instance.GetParam ("Error","--") });
            environ = Convert.ToString(DataHandler.Instance.GetParam("Environment", "QA"));
        }
          

        //public static void GenerateFinalReport()
        //{
        //    CreateFolder("D:\\NS07");
        //    String sbReslt = string.Empty;
        //    for (int i = 0; i < reportParam.Count; i++)
        //    {
        //        if (i == 0)
        //        {
        //            sb.Append("<table class='hovertable' style='Width:80%'><tr><th>Test CaseID</th><th >Test Case Name</th><th>Time Taken</th><th>Status</th></tr>");
        //            sb.Append("<tr onmouseover=\"style.backgroundColor = '#ffff66'; \" onmouseout=\"style.backgroundColor = '#d4e3e5'; \"><td>" + reportParam[i].TestCaseID + "</td><td>" + reportParam[i].TestCaseName.ToString() + "</td><td >" + reportParam[i].MyProperty + "</td><td>" + reportParam[i].Stats.ToString() + "</td></tr>");
        //        }
        //        else
        //        {
        //            sb.Append("<tr onmouseover=\"style.backgroundColor = '#ffff66'; \" onmouseout=\"style.backgroundColor = '#d4e3e5'; \"><td>" + reportParam[i].TestCaseID + "</td><td >" + reportParam[i].TestCaseName.ToString() + "</td><td >" + reportParam[i].MyProperty + "</td><td >" + reportParam[i].Stats.ToString() + "</td></tr>");
        //        }
        //    }
        //    sb.Append("</table>");          
        //    try
        //    {
        //        StringBuilder stb = new StringBuilder(); StringBuilder stTableFail = new StringBuilder();
        //        using (FileStream fs = new FileStream("D:\\NS07\\test.html", FileMode.Create))
        //        {
        //            using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
        //            {
        //                w.WriteLine("<html>");
        //                stb.Append("<html>");
        //                //start head section
        //                w.WriteLine("<head>");
        //                stb.Append("<head>");
        //                w.WriteLine("<style type='text / css'>table.hovertable {  font-family: verdana,arial,sans-serif; font-size: 12px;  color: #333333;  border-width: 1px;  border-color: #999999; border-collapse: collapse;   } table.hovertable th {  background-color: #c3dde0;  border-width: 1px;    padding: 8px;  border-style: solid;   border-color: #a9c6c9;   }   table.hovertable tr {    background-color: #d4e3e5;   }   table.hovertable td {   border-width: 1px;   padding: 8px;    border-style: solid; border-color: #a9c6c9;     } </style>");
        //                stb.Append("<style type='text / css'>table.hovertable {  font-family: verdana,arial,sans-serif; font-size: 12px;  color: #333333;  border-width: 1px;  border-color: #999999; border-collapse: collapse;   } table.hovertable th {  background-color: #c3dde0;  border-width: 1px;    padding: 8px;  border-style: solid;   border-color: #a9c6c9;   }   table.hovertable tr {    background-color: #d4e3e5;   }   table.hovertable td {   border-width: 1px;   padding: 8px;    border-style: solid; border-color: #a9c6c9;     } </style>");
        //                w.WriteLine("</head>");
        //                stb.Append("</head>");
        //                w.WriteLine("<body style='background-color: #F0F8FF'>");
        //                stb.Append("<body style='background-color: #F0F8FF'>");
        //                w.WriteLine("<br/><br/>");
        //                stb.Append("<br/>");
        //                stTableFail.Append(stb);
        //                if (reportParam.Count > 0)
        //                {
        //                    stb.Append("<table style='font-family: verdana,arial,sans-serif; font-size: 14px;  color: #333333; border:none;'>");
        //                    stb.Append("<tr><td style='color:blue;'> Search Name </td><td>: " + reportParam[0].SuiteName.ToString().Substring(21) + "</td></tr>");
        //                    stb.Append("<tr><td style='color:blue;'> Date </td><td>: " + DateTime.Now.ToShortDateString() + "</td></tr>");
        //                    stb.Append("<tr><td style='color:blue;'> Environment </td><td>: " + Convert.ToString(DataHandler.Instance.GetParam("Environment", "QA2")) + "</td></tr>");
        //                    stb.Append("<tr><td style='color:blue;'> Machine </td><td>: " + GetLocalIPAddress() + "</td></tr>");
        //                    stb.Append("</table>");
        //                    stb.Append("<br/>");
        //                    stb.Append("<br/>");
        //                }                       
        //                if (reportParam.Count > 0)
        //                {
        //                    stb.Append("<table style='font-family: verdana,arial,sans-serif; font-size: 14px;  color: #333333; border:none;'>");
        //                    stb.Append("<tr><td style='color:blue;'> Total Test Cases </td><td>: " + reportParam.Count.ToString() + "</td><td></td><td></td><td style='color:green;'> Passed </td><td>: " + reportParam.Where(x => x.Stats == "Passed").Count().ToString() + "</td><td></td><td style='color:red;'> Failed </td><td>: 0</td></tr>");
        //                    stb.Append("</table>");
        //                    stb.Append("<br/>");
        //                    w.WriteLine("<div>" + sb + "</div>");
        //                    stb.Append("<div>" + sb.ToString() + "</div>");
        //                }
                        
        //                w.WriteLine("<br/><br/>");
        //                stb.Append("<br/><br/>");
        //                w.WriteLine("</body>");
        //                stb.Append("</body>");

        //                w.WriteLine("</html>");
        //                stb.Append("</html>");
        //                stTableFail.Append("<br/><br/>");
        //                stTableFail.Append("</body>");
        //                stTableFail.Append("</html>");
        //            }
        //        }
        //        if (reportParam.Count > 0)
        //            SendMail(stb);


               
        //    }
        //    catch (Exception ex)
        //    {

        //        new Exception();
        //    }

        //}
        private static void SendMail(StringBuilder sb)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("suryasasidhar13@gmail.com");
                message.To.Add(new MailAddress("surya.sasidhar@castandcrew.com","Surya"));
                message.To.Add(new MailAddress("umut@mediaservices.com", "Umut"));
                message.Subject = "SBS Automation Script Results";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = sb.ToString ();
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;                
                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailUser"], ConfigurationManager.AppSettings["EmailPass"]);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {

            }
        }
      


        private static void CreateFolder(string rootpath)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(rootpath);
            if (!dirinfo.Exists)
            {
                dirinfo.Create();
            }

        }


        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }


        public static void GenerateFinalReport_Two()
        {
            CreateFolder("D:\\NS07");
            String sbReslt = string.Empty;
            for (int i = 0; i < reportParam.Count; i++)
            {
                if (i == 0)
                {
                    sb.Append("<table id='customers'><tr><th>Test CaseID</th><th >Test Case Name</th><th>Time Taken</th><th>Browser</th><th>Status</th></tr>");
                    if(reportParam[i].Stats.ToString()== "Failed")
                      sb.Append("<tr><td>" + reportParam[i].TestCaseID + "</td><td>" + reportParam[i].TestCaseName.ToString() + "</td><td >" + reportParam[i].MyProperty + "</td><td>" + reportParam[i].Browser + "</td><td><a href=\"javascript:alert('"+ reportParam[i].Errors.ToString()+"')\">" + reportParam[i].Stats.ToString() +"</a></td></tr>");
                    else
                        sb.Append("<tr><td>" + reportParam[i].TestCaseID + "</td><td>" + reportParam[i].TestCaseName.ToString() + "</td><td >" + reportParam[i].MyProperty + "</td><td>" + reportParam[i].Browser + "</td><td><a href=\"javascript:alert('Pass')\">" + reportParam[i].Stats.ToString() + "</a></td></tr>");
                }
                else
                {
                    if (reportParam[i].Stats.ToString() == "Failed")
                        sb.Append("<tr><td>" + reportParam[i].TestCaseID + "</td><td>" + reportParam[i].TestCaseName.ToString() + "</td><td >" + reportParam[i].MyProperty + "</td><td>" + reportParam[i].Browser + "</td><td><a href=\"javascript:alert('" + reportParam[i].Errors.ToString() + "')\">" + reportParam[i].Stats.ToString() + "</a></td></tr>");
                    else
                        sb.Append("<tr><td>" + reportParam[i].TestCaseID + "</td><td>" + reportParam[i].TestCaseName.ToString() + "</td><td >" + reportParam[i].MyProperty + "</td><td>" + reportParam[i].Browser + "</td><td><a href=\"javascript:alert('Pass')\">"+ reportParam[i].Stats.ToString() + "</a></td></tr>");
                    // sb.Append("<tr><td>" + reportParam[i].TestCaseID + "</td><td >" + reportParam[i].TestCaseName.ToString() + "</td><td >" + reportParam[i].MyProperty + "</td><td >" + reportParam[i].Browser  + "</td><td><a href=\"javascript.alert('Yes')\">" + reportParam[i].Stats.ToString() + "</a></td></tr>");
                }
            }
            sb.Append("</table>");
            try
            {
                StringBuilder stb = new StringBuilder(); StringBuilder stTableFail = new StringBuilder();
                using (FileStream fs = new FileStream("D:\\NS07\\test.html", FileMode.Create))
                {
                    using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                    {
                        w.WriteLine("<html>");
                        stb.Append("<html>");
                        //start head section
                        w.WriteLine("<head>");
                        stb.Append("<head>");                       
                        w.WriteLine("<style> #customers {  font-family:Arial, Helvetica, sans-serif;  border-collapse: collapse; width: 65%; } #customers td, #customers th {  border: 1px solid #ddd; padding: 8px; } #customers tr:nth-child(even){background-color: #f2f2f2;} #customers tr:hover {background-color: #ddd;} #customers th { padding-top: 12px; padding-bottom: 12px;   text-align: left; background-color: #04AA6D;  color: white;  }</style>");
                        stb.Append("<style> #customers {  font-family:Arial, Helvetica, sans-serif;  border-collapse: collapse; width: 60%; } #customers td, #customers th {  border: 1px solid #ddd; padding: 8px; } #customers tr:nth-child(even){background-color: #f2f2f2;} #customers tr:hover {background-color: #ddd;} #customers th { padding-top: 12px; padding-bottom: 12px;   text-align: left; background-color: #04AA6D;  color: white;  }</style>");                       
                        w.WriteLine("</head>");
                        stb.Append("</head>");
                        w.WriteLine("<body style='background-color: #F0F8FF'>");
                       
                        stb.Append("<body style='background-color: #F0F8FF'>");
                        w.WriteLine("<br/>");
                        stb.Append("<br/>");
                        stTableFail.Append(stb);
                        if (reportParam.Count > 0)
                        {
                            //Email
                            stb.Append("<table style='font-family: verdana,arial,sans-serif; font-size: 14px;  color: #333333; border:none;'>");
                            stb.Append("<tr><td style='color:blue;'> Search Name </td><td>: " + reportParam[0].SuiteName.ToString().Substring(21) + "</td></tr>");
                            stb.Append("<tr><td style='color:blue;'> Date </td><td>: " + DateTime.Now.ToShortDateString() + "</td></tr>");
                            stb.Append("<tr><td style='color:blue;'> Environment </td><td>: " + environ + "</td></tr>");
                            stb.Append("<tr><td style='color:blue;'> Machine </td><td>: " + GetLocalIPAddress() + "</td></tr>");
                            stb.Append("</table>");
                            stb.Append("<br/>");
                            stb.Append("<br/>");

                            //Html Page
                            w.WriteLine("<table style='font-family: verdana,arial,sans-serif; font-size: 14px;  color: #333333; border:none;'>");
                            w.WriteLine("<tr><td style='color:darkgreen;'> </td><td> </td></tr>");
                            w.WriteLine("<tr><td style='color:darkgreen; font-size: 16px;'> AUTOMATION SCRIPTS </td><td></td></tr>");
                            w.WriteLine("<tr><td style='color:blue;'> </td><td> </td></tr>");
                            w.WriteLine("<tr><td style='color:blue;'> Search Name </td><td>: " + reportParam[0].SuiteName.ToString().Substring(21) + "</td></tr>");
                            w.WriteLine("<tr><td style='color:blue;'> Date </td><td>: " + DateTime.Now.ToShortDateString() + "</td></tr>");
                            w.WriteLine("<tr><td style='color:blue;'> Environment </td><td>: " + environ + "</td></tr>");
                            w.WriteLine("<tr><td style='color:blue;'> Machine </td><td>: " + GetLocalIPAddress() + "</td></tr>");
                            w.WriteLine("</table>");
                            w.WriteLine("<br/>");                           

                        }
                        if (reportParam.Count > 0)
                        {
                            stb.Append("<table style='font-family: verdana,arial,sans-serif; font-size: 14px;  color: #333333; border:none;'>");
                            stb.Append("<tr><td style='color:blue;'> Total Test Cases </td><td>: " + reportParam.Count.ToString() + "</td><td></td><td></td><td style='color:green;'> Passed </td><td>: " + reportParam.Where(x => x.Stats == "Passed").Count().ToString() + "</td><td></td><td style='color:red;'> Failed </td><td>: "+ reportParam.Where(x => x.Stats == "Failed").Count().ToString() + "</td></tr>");
                            stb.Append("</table>");
                            stb.Append("<br/>");    

                            //Html Page
                            w.WriteLine("<div>" + sb + "</div>");

                            //Eamil Page
                            stb.Append("<div>" + sb.ToString() + "</div>");
                        }

                        w.WriteLine("<br/><br/>");
                        stb.Append("<br/><br/>");                        
                        w.WriteLine("</body>");
                        stb.Append("</body>");
                        w.WriteLine("</html>");
                        stb.Append("</html>");
                        stTableFail.Append("<br/><br/>");
                        stTableFail.Append("</body>");
                        stTableFail.Append("</html>");
                    }
                }
                //if (reportParam.Count > 0)
                //    SendMail(stb);



            }
            catch (Exception ex)
            {

                new Exception();
            }

        }


    }
    public class ReportParams
    {
        public string TestCaseID { get; set; }
        public string TestCaseName { get; set; }
        public string Stats { get; set; }

        public string MyProperty { get; set; }
        public string outPutFile { get; set; }
        public string SuiteName { get; set; }
        public string Browser { get; set; }
        public string Errors { get; set; }
    }

}


