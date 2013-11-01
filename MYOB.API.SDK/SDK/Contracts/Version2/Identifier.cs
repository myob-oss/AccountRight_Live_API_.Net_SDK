namespace MYOB.AccountRight.SDK.Contracts.Version2
{
    /// <summary>
    /// Describes an identifier
    /// </summary>
    public class Identifier
    {
        /// <summary>
        /// The label assigned to identify the value
        /// </summary>
        /// <remarks>
        /// This entry is read only and can be manipulated using the AccountRight application
        /// </remarks>
        public string Label { get; set; }

        /// <summary>
        /// The data to store
        /// </summary>
        public string Value { get; set; }
    }
}