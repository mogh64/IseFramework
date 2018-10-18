// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014

using ISE.UILibrary.DateTimeBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Utility.Utils
{
    public class DateTimeHelper
    {
        // TODO complete this method 
        public static DateTime GetDateTime(int persianYear, int persianMonth, int persianDay)
        {
            ISE.UILibrary.DateTimeBase.PersianDate pDate = new UILibrary.DateTimeBase.PersianDate(persianYear, persianMonth, persianDay);
            DateTime gDate = ISE.UILibrary.DateTimeBase.PersianDateConverter.ToGregorianDateTime(pDate.ToString("yyyy/mm/dd"));
            return gDate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"> yyyy-MM-dd</param>
        /// <returns></returns>
        public static DateTime GetDateTime(string dateTime)
        {
            DateTime dt = DateTime.ParseExact(dateTime, "yyyy-MM-dd",null);
            return dt;
        }
        public static int GetPersianDayOfWeek(DateTime dateTime)
        {
            int day = (int)dateTime.DayOfWeek;
            int result = 1;
            if (day <= 5)
                result = day + 2;
            else
                result = day - 5;
            return result;
        }
        public static DateTime GetPersianStartOfWeek(DateTime date)
        {
            int pDayOfWeek = GetPersianDayOfWeek(date);
            DateTime startOfWeek = date.AddDays(-(pDayOfWeek - 1));
            return startOfWeek;
        }
        public static DateTime GetPersianEndOfWeek(DateTime date)
        {
            int pDayOfWeek = GetPersianDayOfWeek(date);
            DateTime startOfWeek = date.AddDays(-(pDayOfWeek - 1));
            DateTime endOfWeek = startOfWeek.AddDays(6);
            return endOfWeek;
        }
        public static DateTime GetCurrentStartDateTime()
        {
            PersianDate pdate = ISE.UILibrary.DateTimeBase.PersianDateConverter.ToPersianDate(DateTime.Now);
            PersianDate faStartOfYear = new PersianDate(pdate.Year, 1, 1);
            DateTime enStartOfyear = ISE.UILibrary.DateTimeBase.PersianDateConverter.ToGregorianDateTime(faStartOfYear);
            return enStartOfyear;
        }
        public static PersianDate GetPersianDate(DateTime dt)
        {
            PersianDate pdate = ISE.UILibrary.DateTimeBase.PersianDateConverter.ToPersianDate(dt);
            return pdate;
        }
        public static string GetPersianDateString(DateTime dt)
        {
            PersianDate pdate = ISE.UILibrary.DateTimeBase.PersianDateConverter.ToPersianDate(dt);
            string year = pdate.Year.ToString();
            string month = pdate.Month.ToString();
            string day = pdate.Day.ToString();
            if (month.Length == 1)
            {
                month = "0" + month;
            }
            if (day.Length == 1)
            {
                day = "0" + day;
            }
            string psdate = string.Format("{0}/{1}/{2}", year, month, day);
            return psdate;
        }
        public static string GetPersianDayOfWeekName(DateTime dt)
        {
            string result = string.Empty;
            int day = GetPersianDayOfWeek(dt);
            ISE.UILibrary.DateTimeBase.PersianDate.PersianWeekDayNames pd = new PersianDate.PersianWeekDayNames();
            switch (day)
            {
                case 1:
                    {
                        result = pd.Shanbeh;
                    }
                    break;
                case 2:
                    {
                        result = pd.Yekshanbeh;
                    }
                    break;
                case 3:
                    {
                        result = pd.Doshanbeh;
                    }
                    break;
                case 4:
                    {
                        result = pd.Seshanbeh;
                    }
                    break;
                case 5:
                    {
                        result = pd.Chaharshanbeh;
                    }
                    break;
                case 6:
                    {
                        result = pd.Panjshanbeh;
                    }
                    break;
                case 7:
                    {
                        result = pd.Jomeh;
                    }
                    break;

            }
            return result;
        }
        public static string GetPersianMonthName(int month)
        {
            if (month > 0 && month < 13)
            {
                ISE.UILibrary.DateTimeBase.PersianDate.PersianMonthNames pName = new PersianDate.PersianMonthNames();
                switch (month)
                {
                    case 1:
                        {
                            return pName.Farvardin;
                        }

                    case 2:
                        {
                            return pName.Ordibehesht;
                        }

                    case 3:
                        {
                            return pName.Khordad;
                        }

                    case 4:
                        {
                            return pName.Tir;
                        }

                    case 5:
                        {
                            return pName.Mordad;
                        }

                    case 6:
                        {
                            return pName.Shahrivar;
                        }

                    case 7:
                        {
                            return pName.Mehr;
                        }

                    case 8:
                        {
                            return pName.Aban;
                        }

                    case 9:
                        {
                            return pName.Azar;
                        }

                    case 10:
                        {
                            return pName.Day;
                        }

                    case 11:
                        {
                            return pName.Bahman;
                        }

                    case 12:
                        {
                            return pName.Esfand;
                        }

                }
            }
            return string.Empty;
        }

    }
}
