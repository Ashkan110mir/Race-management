using System;
using System.Globalization;
namespace Race_management.Utility
{
    public class DateCalculator
    {
        public static string DateToShamshi(DateTime date)
        {
            PersianCalendar pc=new PersianCalendar();
            return pc.GetYear(date).ToString("0000")+"/"+pc.GetMonth(date).ToString("00")+"/"+pc.GetDayOfMonth(date).ToString("00");
        }
        public static DateTime Tomiladi(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, new System.Globalization.PersianCalendar());
        }
    }
}
