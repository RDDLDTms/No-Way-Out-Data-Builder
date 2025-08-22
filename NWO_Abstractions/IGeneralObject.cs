using Newtonsoft.Json;

namespace NWO_Abstractions
{
    public interface IGeneralObject
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty]
        public Guid Id { get; }

        /// <summary>
        /// Общее имя объекта (на все языки)
        /// </summary>
        [JsonProperty]
        public string CommonName { get; }

        /// <summary>
        /// Отображаемое имя объекта
        /// </summary>
        [JsonProperty]
        public string DisplayName { get; set; }

        /// <summary>
        /// Отображаемое описание объекта
        /// </summary>
        [JsonProperty]
        public string Description { get; set; }
    }
}
