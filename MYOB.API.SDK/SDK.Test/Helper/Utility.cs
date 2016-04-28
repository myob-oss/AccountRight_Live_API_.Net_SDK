using System;
using System.Reflection;

namespace SDK.Test.Helper
{
    public class Utility
    {
        public static object RunInstanceMethod(Type t, string strMethod, object objInstance, object[] objParams)
        {
            var method = t.GetMethod(strMethod, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (method == null)
            {
                throw new ArgumentException("There is no method '" + strMethod + "' for type '" + t + "'.");
            }
            return method.Invoke(objInstance, objParams);
        }
    }
}