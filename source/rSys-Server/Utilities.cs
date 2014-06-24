using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace rSysServer
{
    /// <summary>
    /// 
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Serialize an object to a json string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T source)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, source);
                ms.Position = 0;
                using (StreamReader sr = new StreamReader(ms, Encoding.UTF8))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Deserialize an json string to a object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T ToObject<T>(this string source)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(source)))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));
                return (T)deserializer.ReadObject(ms);
            }
        }

        /// <summary>
        /// Formats the given size to an human readable format
        /// </summary>
        /// <param name="size">size</param>
        /// <returns>human readable size</returns>
        public static string ToHumanReadable(this ulong size)
        {
            return ((decimal)size).ToHumanReadable();
        }

        /// <summary>
        /// Formats the given size to an human readable format
        /// </summary>
        /// <param name="size">size</param>
        /// <returns>human readable size</returns>
        public static string ToHumanReadable(this long size)
        {
            return ((decimal)size).ToHumanReadable();
        }

        /// <summary>
        /// Formats the given size to an human readable format
        /// </summary>
        /// <param name="size">size</param>
        /// <returns>human readable size</returns>
        public static string ToHumanReadable(this decimal size)
        {
            const int scale = 1024;
            string[] orders = new string[] { "PiB", "TiB", "GiB", "MiB", "KiB", "Bytes" };
            decimal max = (decimal)Math.Pow(scale, orders.Length - 1);

            foreach (string order in orders)
            {
                if (size > max)
                {
                    return string.Format("{0:##.##} {1}", decimal.Divide(size, max), order);
                }

                max /= scale;
            }
            return "0 Bytes";
        }

        /// <summary>
        /// Creates a pretty string of a list of objects if it begins with "Instance: #total"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToPrettyString<T>(this List<T> source)
        {
            T d = source.Find(x => { return x.ToString().StartsWith("Instance: #total"); });
            if (d == null)
            {
                return source.ToString();
            }
            else
            {
                return d.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal Round(this decimal value)
        {
            return decimal.Round(value, 2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void DebugOutput(string text)
        {
            Debug.WriteLine(text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        public static void DebugDump(object source)
        {
            DebugOutput(XSharper.Core.Dump.ToDump(source));
        }
    }
}
