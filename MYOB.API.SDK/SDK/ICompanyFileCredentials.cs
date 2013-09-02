namespace MYOB.AccountRight.SDK
{
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