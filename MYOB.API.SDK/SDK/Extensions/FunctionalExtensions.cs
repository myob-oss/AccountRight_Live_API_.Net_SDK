using System;

namespace MYOB.AccountRight.SDK.Extensions
{
    /// <summary>
    /// some helper extensions
    /// </summary>
    public static class FunctionalExtensions
    {
        /// <summary>
        /// simple Maybe
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="_this"></param>
        /// <param name="func"></param>
        /// <param name="defaultReturnValue"></param>
        /// <returns></returns>
        public static TResult Maybe<T, TResult>(
            this T _this,
            Func<T, TResult> func,
            TResult defaultReturnValue = default(TResult)) where T : class
        {
            return (_this == null) ? defaultReturnValue : func(_this);
        }
    }
}
