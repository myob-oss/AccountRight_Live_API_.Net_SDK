namespace MYOB.AccountRight.SDK
{
    /// <summary>
    /// Interface for classes that will provide Company File credentials 
    /// </summary>
    public interface ICompanyFileCredentials
    {
        /// <summary>
        /// The company file username, for the sample files use 'Administrator'
        /// </summary>
        string Username { get; }

        /// <summary>
        /// The company file password, for the sample files use ''
        /// </summary>
        string Password { get; }
    }
}