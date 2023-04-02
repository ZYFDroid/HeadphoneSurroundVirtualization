
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 耳机虚拟环绕声
{
    public static class MathHelper
    {
        public static float clamp(float x)
        {
            return x < -1 ? -1 : (x > 1 ? 1 : x);
        }

        public static float clamp(float x,float min,float max)
        {
            return x < min ? min : (x > max ? max : x);
        }
        public static float db2linear(float dB)
        {
            return (float) Math.Pow(10d, dB / 20.0);
        }

        public static float linear2db(float x)
        {
            return (float)(20.0 * Math.Log10(x / 1.0));
        }
    }

    public class JsonConvert
    {
        private static System.Web.Script.Serialization.JavaScriptSerializer serializer;
        public static string Serialize(object obj)
        {
            if (serializer == null) { serializer = new System.Web.Script.Serialization.JavaScriptSerializer(); }
            return serializer.Serialize(obj);
        }

        public static T Deserialize<T>(string json)
        {
            if (serializer == null) { serializer = new System.Web.Script.Serialization.JavaScriptSerializer(); }
            return serializer.Deserialize<T>(json);
        }
    }
}
