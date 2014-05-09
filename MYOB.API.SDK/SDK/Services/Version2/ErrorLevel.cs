namespace MYOB.AccountRight.SDK.Services
{
    /// <summary>
    /// Enum to determine whether warnings cause exceptions to be thrown or whether warnings are ignored
    /// </summary>
    public enum ErrorLevel
    {
        /// <summary>
        /// Treat warnings as errors
        /// </summary>
        WarningsAsErrors,

        /// <summary>
        /// Ignore warnings
        /// </summary>
        IgnoreWarnings
    }
}