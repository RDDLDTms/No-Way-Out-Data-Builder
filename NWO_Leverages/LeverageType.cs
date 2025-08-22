using NWO_Abstractions;

namespace NWO_Leverages
{
    /// <summary>
    /// Тип воздействия
    /// </summary>
    public sealed class LeverageType : IGeneralObject
    {
        public Guid Id { get; private set; }

        public string CommonName { get; private set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public LeverageType(Guid id, string commonName, string displayName, string description)
        {
            Id = id;
            CommonName = commonName;
            DisplayName = displayName;
            Description = description;
        }
    }
}
