using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestZPLPrint
{
    internal class ZPLAction
    {

        private int _port;
        private string _ip { get; set; }

        public ZPLAction ForIP(string ip)
        {
            _ip = ip;
            return this;
        }

        public ZPLAction WithPort(int port)
        {
            _port = port;
            return this;
        }






        //public void StampaZplEtichetta(Int64 id, string qta)
        //{
        //    try
        //    {   

        //        // Lettura file etichetta segnaposto {0}, ....
        //        string ZPLString = string.Empty;
        //        using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/etichetta.zpl")))
        //        {
        //            ZPLString = sr.ReadToEnd();
        //            sr.Close();
        //        }
        //        // Recupero dati etichetta da stored
                
        //        SendToZPL(ZPLString);
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine("stampaZpl ", ex.InnerException);
        //    }
        //}
        internal bool SendToZPL(string zplcontent)
        {
            var sc = new SocketManager();
            sc.ForIP(_ip).WithPort(_port);
            return sc.SendStream(zplcontent);           

        }
    }

}
