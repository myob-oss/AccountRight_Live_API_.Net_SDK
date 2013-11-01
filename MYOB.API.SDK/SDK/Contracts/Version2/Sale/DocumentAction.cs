namespace MYOB.AccountRight.SDK.Contracts.Version2.Sale
{
    /// <summary>
    /// Type of document action
    /// </summary>
    public enum DocumentAction
    {
        /// <summary>
        /// Nothing to do or, already printed and/or sent
        /// </summary>
        Nothing,

        /// <summary>
        /// To be printed
        /// </summary>
        Print,

        /// <summary>
        /// To be emailed
        /// </summary>
        Email,

        /// <summary>
        /// To be printed and emailed
        /// </summary>
        PrintAndEmail
    }
}