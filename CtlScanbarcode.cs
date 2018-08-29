using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication2.Model
{
   public class CtlScanbarcode
    {
        public Ctlbarcode GetInfoFromInputBarcode(string strbarcode)
        {
            Ctlbarcode barcodeInfo = new Ctlbarcode();
            try
            {
                string strstore = strbarcode.Substring(strbarcode.Length - 2, 2);
                string strdate = strbarcode.Substring(0, 4);
                string strregister = strbarcode.Substring(4, 2);
                string strtranx = strbarcode.Substring(6, 3);

                barcodeInfo.Store = Convertbarcode(strstore);
                barcodeInfo.Register = Convertbarcode(strregister);
                barcodeInfo.Tranx = Convertbarcode(strtranx);
                barcodeInfo.datetime = ConverDate(strdate, barcodeInfo.hangSoDate);
                return barcodeInfo;
            }
            catch (Exception ex)
            {
                return barcodeInfo;
            }

        }
        public string Convertbarcode(string value)
        {
            double res=0;
            Ctlbarcode bar = new Ctlbarcode();

            for (int i = 0; i < value.Length; i++)
            {
                res +=(Convert.ToDouble(bar.tbHeso[value[i].ToString()]) * Math.Pow(26, value.Length-1 - i));
            }

            return res.ToString();
        }
        public DateTime ConverDate(string value,double hanngso)
        {
            double date=Convert.ToDouble(Convertbarcode(value));
            return DateTime.FromOADate(date - hanngso);
        }
    }
}
