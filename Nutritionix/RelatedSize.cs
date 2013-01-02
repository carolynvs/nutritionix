using System.Runtime.Serialization;

namespace Nutritionix
{
    [DataContract]
    public class RelatedSize
    {
        [DataMember(Name = "item_id")]
        public string ItemId { get; set; }

        [DataMember(Name = "name")]
        public string ItemName { get; set; }
    }
}