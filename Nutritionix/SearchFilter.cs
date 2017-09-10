using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using Newtonsoft.Json;
using Nutritionix.Extensions;

namespace Nutritionix
{
    /// <summary>
    /// 
    /// </summary>
    [JsonObject]
    public interface ISearchFilter
    {

    }

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(SearchFilterCollectionConverter))]
    public class SearchFilterCollection : List<ISearchFilter>
    {
        
    }

    internal class SearchFilterCollectionConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var filters = (SearchFilterCollection)value;

            writer.WriteStartObject();
            foreach (var filter in filters)
            {
                serializer.Serialize(writer, filter);
            }
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (SearchFilterCollection);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [JsonObject, JsonConverter(typeof(ItemTypeFilterConverter))]
    public class ItemTypeFilter : ISearchFilter
    {
        /// <summary>
        /// 
        /// </summary>
        public ItemType ItemType { get; set; }

        /// <summary>
        /// Exclude the specified ItemType
        /// </summary>
        public bool Negated { get; set; }
    }

    internal class ItemTypeFilterConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var filter = (ItemTypeFilter) value;

            if (filter.Negated)
            {
                writer.WritePropertyName("not");
                writer.WriteStartObject();
            }

            writer.WritePropertyName("item_type");
            writer.WriteValue((int)filter.ItemType);
            
            if (filter.Negated)
            {
                writer.WriteEndObject();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (ItemTypeFilter);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [JsonObject, JsonConverter(typeof(RangeFilterConverter))]
    public class RangeFilter : ISearchFilter
    {
        /// <summary>
        /// 
        /// </summary>
        public RangeFilter()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemPropertyExpression"></param>
        public RangeFilter(Expression<Func<Item, decimal?>> itemPropertyExpression)
        {
            Field = itemPropertyExpression.ToJsonProperty();
        }

        /// <summary>
        /// 
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal From { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal To { get; set; }
    }

    internal class RangeFilterConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var filter = (RangeFilter) value;
            writer.WritePropertyName(filter.Field);
            writer.WriteStartObject();
                writer.WritePropertyName("from");
                writer.WriteValue(filter.From);
                writer.WritePropertyName("to");
                writer.WriteValue(filter.To);
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(RangeFilter);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [JsonObject, JsonConverter(typeof(ComparisonFilterConverter))]
    public class ComparisonFilter : ISearchFilter
    {
        /// <summary>
        /// 
        /// </summary>
        public ComparisonFilter()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemPropertyExpression"></param>
        public ComparisonFilter(Expression<Func<Item, decimal?>> itemPropertyExpression)
        {
            Field = itemPropertyExpression.ToJsonProperty();
        }

        /// <summary>
        /// 
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ComparisonOperator Operator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Value { get; set; }
    }

    internal class ComparisonFilterConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var filter = (ComparisonFilter) value;

            writer.WritePropertyName(filter.Field);
            writer.WriteStartObject();
                writer.WritePropertyName(filter.Operator.ToDescription());
                writer.WriteValue(filter.Value);
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ComparisonFilter);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ComparisonOperator
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("lt")]
        LessThan,
        /// <summary>
        /// 
        /// </summary>
        [Description("lte")]
        LessThanOrEqualTo,
        /// <summary>
        /// 
        /// </summary>
        [Description("gt")]
        GreaterThan,
        /// <summary>
        /// 
        /// </summary>
        [Description("gte")]
        GreaterThanOrEqualTo
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ItemType
    {
        /// <summary>
        /// 
        /// </summary>
        Restaurant = 1,
        /// <summary>
        /// 
        /// </summary>
        Packaged = 2,
        /// <summary>
        /// 
        /// </summary>
        USDA = 3
    }
}
