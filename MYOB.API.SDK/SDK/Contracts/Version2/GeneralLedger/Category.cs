namespace MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger
{

    public class Category : BaseEntity
    {
        public Category()
        {
            IsActive = true;
        }

        public string DisplayID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}