using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace TENX.Models
{
    public static class SystemGlobals
    {
        public static CDataBase DataBase;
        public static string HeaderTitleText = "";
        public static string FooterTitleText = "";
        public static string UserName = "";

        public static string encrypt(string message)
        {
            byte[] results;
            UTF8Encoding utf8 = new UTF8Encoding();
            //UTF8Encoding  класс үүсгэнэ
            // MD5CryptoServiceProvider үүсгэ_э
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] deskey = md5.ComputeHash(utf8.GetBytes("MCE.B2E"));
            //passkey 2 т руу хөрвүүлнэ
            //TripleDESCryptoServiceProvider үүсгэнэ
            TripleDESCryptoServiceProvider desalg = new TripleDESCryptoServiceProvider();
            desalg.Key = deskey;//пасс encode хийх утгийг олгно
            desalg.Mode = CipherMode.ECB;
            desalg.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            byte[] encrypt_data = utf8.GetBytes(message);
            //UTF байт руу хөрвүүлнэ
            try
            {
                //md5 хөрвүүлнэ
                ICryptoTransform encryptor = desalg.CreateEncryptor();
                results = encryptor.TransformFinalBlock(encrypt_data, 0, encrypt_data.Length);

            }
            finally
            {
                //Санах ойг цэвэрлэнэ
                desalg.Clear();
                md5.Clear();
            }
            //64 bit ruu хөрвүүлнэ
            return Convert.ToBase64String(results);

        }

        public static string decrypt(string message)
        {
            byte[] results;
            UTF8Encoding utf8 = new UTF8Encoding();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] deskey = md5.ComputeHash(utf8.GetBytes("MCE.B2E"));
            TripleDESCryptoServiceProvider desalg = new TripleDESCryptoServiceProvider();
            desalg.Key = deskey;
            desalg.Mode = CipherMode.ECB;
            desalg.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            byte[] decrypt_data = Convert.FromBase64String(message);
            try
            {
                //To transform the utf binary code to md5 decrypt
                ICryptoTransform decryptor = desalg.CreateDecryptor();
                results = decryptor.TransformFinalBlock(decrypt_data, 0, decrypt_data.Length);
            }
            finally
            {
                desalg.Clear();
                md5.Clear();

            }
            //TO convert decrypted binery code to string
            return utf8.GetString(results);
        }

        public static string IsUpdate(string UserGroupID, string MenuInfoID)
        {
            DataTable dt = SystemGlobals.DataBase.ExecuteSQL("select * from smmUserInPermission where UserGroupID='" + UserGroupID + "' and MenuInfoID='" + MenuInfoID + "'").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["IsUpdate"].ToString();
            }
            else
                return "N";
        }

        public static string IsInsert(string UserGroupID, string MenuInfoID)
        {
            DataTable dt = SystemGlobals.DataBase.ExecuteSQL("select * from smmUserInPermission where UserGroupID='" + UserGroupID + "' and MenuInfoID='" + MenuInfoID + "'").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["IsInsert"].ToString();
            }
            else
                return "N";
        }

        public static string IsDelete(string UserGroupID, string MenuInfoID)
        {
            DataTable dt = SystemGlobals.DataBase.ExecuteSQL("select * from smmUserInPermission where UserGroupID='" + UserGroupID + "' and MenuInfoID='" + MenuInfoID + "'").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["IsDelete"].ToString();
            }
            else
                return "N";
        }

        public static string IsSelect(string UserGroupID, string MenuInfoID)
        {
            DataTable dt = SystemGlobals.DataBase.ExecuteSQL("select * from smmUserInPermission where UserGroupID='" + UserGroupID + "' and MenuInfoID='" + MenuInfoID + "'").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["IsSelect"].ToString();
            }
            else
                return "N";
        }

        public static int CountSubMenu(string UserGroupID, string MenuInfoID)
        {
            DataTable dt = SystemGlobals.DataBase.ExecuteSQL("select count(*) c from smmUserInPermission where UserGroupID='" + UserGroupID + "' and MenuInfoID like '" + MenuInfoID + "%' and IsSelect='Y'").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["c"]);
            }
            else
                return 0;
        }

        public static string DateToWeekendName(DateTime dt)
        {
            string Name = "";
            switch ((int)dt.DayOfWeek)
            {
                case 1:
                    Name = "Даваа";
                    break;
                case 2:
                    Name = "Мягмар";
                    break;
                case 3:
                    Name = "Лхагва";
                    break;
                case 4:
                    Name = "Пүрэв";
                    break;
                case 5:
                    Name = "Баасан";
                    break;
                case 6:
                    Name = "Бямба";
                    break;
                case 7:
                    Name = "Ням";
                    break;
                default:
                    Name="Тодорхойгүй";
                    break;
            }
            return Name;
        }



        private static object getAspNetInternalCacheObj()
        {
            object aspNetCacheInternal = null;

            PropertyInfo cacheInternalPropInfo = typeof(HttpRuntime).GetProperty("CacheInternal", BindingFlags.NonPublic | BindingFlags.Static);
            if (cacheInternalPropInfo != null)
            {
                aspNetCacheInternal = cacheInternalPropInfo.GetValue(null, null);
                return aspNetCacheInternal;
            }

            // At some point, after some .NET Framework's security update, that internal member disappeared.
            // https://stackoverflow.com/a/45045160
            // 
            // We need to look for internal cache otherwise.
            //
            var cacheInternalFieldInfo = HttpRuntime.Cache.GetType().GetField("_internalCache", BindingFlags.NonPublic | BindingFlags.Static);
            if (cacheInternalFieldInfo == null)
                return null;

            var httpRuntimeInternalCache = cacheInternalFieldInfo.GetValue(HttpRuntime.Cache);
            var httpRuntimeInternalCacheField = httpRuntimeInternalCache.GetType().GetField("_cacheInternal", BindingFlags.NonPublic | BindingFlags.Instance);
            if (httpRuntimeInternalCacheField == null)
                return null;

            aspNetCacheInternal = httpRuntimeInternalCacheField.GetValue(httpRuntimeInternalCache);
            return aspNetCacheInternal;
        }


        // adapted from https://stackoverflow.com/a/39422431/1086134
        public static IEnumerable<System.Web.SessionState.SessionStateItemCollection> getAllUserSessions()
        {
            List<Hashtable> hTables = new List<Hashtable>();
            object obj = getAspNetInternalCacheObj();
            if (obj == null)
                yield break;

            dynamic fieldInfo = obj.GetType().GetField("_caches", BindingFlags.NonPublic | BindingFlags.Instance);
            //If server uses "_caches" to store session info
            if (fieldInfo != null)
            {
                object[] _caches = (object[])fieldInfo.GetValue(obj);
                for (int i = 0; i <= _caches.Length - 1; i++)
                {
                    Hashtable hTable = (Hashtable)_caches[i].GetType().GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_caches[i]);
                    hTables.Add(hTable);
                }
            }
            //If server uses "_cachesRefs" to store session info
            else
            {
                fieldInfo = obj.GetType().GetField("_cachesRefs", BindingFlags.NonPublic | BindingFlags.Instance);
                object[] cacheRefs = fieldInfo.GetValue(obj);
                for (int i = 0; i <= cacheRefs.Length - 1; i++)
                {
                    var target = cacheRefs[i].GetType().GetProperty("Target").GetValue(cacheRefs[i], null);
                    Hashtable hTable = (Hashtable)target.GetType().GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target);
                    hTables.Add(hTable);
                }
            }

            foreach (Hashtable hTable in hTables)
            {
                foreach (DictionaryEntry entry in hTable)
                {
                    object o1 = entry.Value.GetType().GetProperty("Value", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(entry.Value, null);
                    if (o1.GetType().ToString() == "System.Web.SessionState.InProcSessionState")
                    {
                        System.Web.SessionState.SessionStateItemCollection sess = (System.Web.SessionState.SessionStateItemCollection)o1.GetType().GetField("_sessionItems", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(o1);
                        if (sess != null)
                            yield return sess;
                    }
                }
            }
        }


        public static string sendEmail(string cust_email, string emailSubject, string body)
        {
            try
            {
                DataTable dt = SystemGlobals.DataBase.ExecuteSQL("select * from BMQ..Settings where id = 3015").Tables[0];

                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(dt.Rows[0]["Caption"].ToString());

                mail.From = new MailAddress(dt.Rows[0]["SettingName"].ToString());
                mail.Bcc.Add(cust_email);
                mail.Subject = emailSubject;
                mail.IsBodyHtml = true;

                //Та энэ <a href =\"" + url + "\">link</a>-ээр орж тодорхойлолтоо харна уу.
                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(dt.Rows[0]["SettingName"].ToString(), dt.Rows[0]["SettingValue"].ToString());
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return "success";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

    }
}