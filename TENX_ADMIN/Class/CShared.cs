using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TENX.Class
{
    public static class CShared
    {
        private static string[] Numbers = new string[10] { "", "нэг", "хоёр", "гурван", "дөрвөн", "таван", "зургаан", "долоон", "найман", "есөн" };
        private static string[] Tenths = new string[10] { "", "арван", "хорин", "гучин", "дөчин", "тавин", "жаран", "далан", "наян", "ерэн" };

        private static string RecurseNumber(long N)
        {
            if (N >= 1L && N <= 9L)
                return CShared.Numbers[N];
            if (N >= 10L && N <= 99L)
                return CShared.Tenths[(int)(N / 10L)] + " " + CShared.RecurseNumber(N % 10L);
            if (N >= 100L && N <= 999L)
                return CShared.Numbers[(int)(N / 100L)] + " зуун " + CShared.RecurseNumber(N % 100L);
            if (N >= 1000L && N <= 999999L)
            {
                if (N % 1000L != 0L)
                    return CShared.RecurseNumber((long)(int)(N / 1000L)) + " мянга " + CShared.RecurseNumber(N % 1000L);
                return CShared.RecurseNumber((long)(int)(N / 1000L)) + " мянган ";
            }
            if (N >= 1000000L && N <= 999999999L)
                return CShared.RecurseNumber((long)(int)(N / 1000000L)) + " сая " + CShared.RecurseNumber(N % 1000000L);
            if (N >= 1000000000L && N <= (long)uint.MaxValue)
                return CShared.RecurseNumber((long)(int)(N / 1000000000L)) + " тэрбум " + CShared.RecurseNumber(N % 1000000000L);
            return "";
        }

        public static string NumToLetters(Decimal Number, string CurrencyId)
        {
            string str1;
            string str2;
            switch (CurrencyId)
            {
                case "MNT":
                    str1 = "төгрөг";
                    str2 = "мөнгө";
                    break;
                case "USD":
                    str1 = "ам доллар";
                    str2 = "цент";
                    break;
                case "EUR":
                    str1 = "евро";
                    str2 = "";
                    break;
                case "CNY":
                    str1 = "юань";
                    str2 = "";
                    break;
                case "RUB":
                    str1 = "рубль";
                    str2 = "";
                    break;
                case "GBP":
                    str1 = "фунт";
                    str2 = "";
                    break;
                case "JPY":
                    str1 = "иен";
                    str2 = "";
                    break;
                default:
                    str1 = "";
                    str2 = "";
                    break;
            }
            if (Number >= new Decimal(1) && Number <= new Decimal((long)uint.MaxValue))
            {
                string str3 = CShared.RecurseNumber(Convert.ToInt64(Number));
                int length = str3.Length;
                string str4 = str3.Substring(0, 1).ToUpper() + str3.Substring(1, length - 1) + " " + str1;
                long num = Convert.ToInt64(Number * new Decimal(100)) % 100;
                string str5 = num == 0 ? "" : CShared.RecurseNumber(Convert.ToInt64(num));
                if (!(str5 != ""))
                    return str4;
                return str4 + " " + str5 + " " + str2;
            }
            return Number == new Decimal(0) ? "" : "not in valid range";
        }
    }
}