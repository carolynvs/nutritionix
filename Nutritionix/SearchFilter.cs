using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using Newtonsoft.Json;
using Nutritionix.Extensions;

namespace Nutritionix
{
    [JsonObject]
    public interface ISearchFilter
    {

    }

    [JsonObject, JsonConverter(typeof(ItemTypeFilterConverter))]
    public class ItemTypeFilter : ISearchFilter
    {
        public ItemType ItemType { get; set; }

        /// <summary>
        /// Exclude the specified ItemType
        /// </summary>
        public bool Negated { get; set; }
    }

    public class ItemTypeFilterConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var filter = (ItemTypeFilter) value;

            if (filter.Negated)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("not");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("item_type");
            writer.WriteValue((int)filter.ItemType);
            writer.WriteEndObject();

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

    [JsonObject, JsonConverter(typeof(RangeFilterConverter))]
    public class RangeFilter : ISearchFilter
    {
        public RangeFilter()
        {
            
        }

        public RangeFilter(Expression<Func<Item, decimal?>> itemPropertyExpression)
        {
            Field = itemPropertyExpression.ToJsonProperty();
        }

        public string Field { get; set; }

        public decimal From { get; set; }

        public decimal To { get; set; }
    }

    public class RangeFilterConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var filter = (RangeFilter) value;
            writer.WriteStartObject();
                writer.WritePropertyName(filter.Field);
                writer.WriteStartObject();
                    writer.WritePropertyName("from");
                    writer.WriteValue(filter.From);
                    writer.WritePropertyName("to");
                    writer.WriteValue(filter.To);
                writer.WriteEndObject();
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

    [JsonObject, JsonConverter(typeof(ComparisonFilterConverter))]
    public class ComparisonFilter : ISearchFilter
    {
        public ComparisonFilter()
        {
            
        }

        public ComparisonFilter(Expression<Func<Item, decimal?>> itemPropertyExpression)
        {
            Field = itemPropertyExpression.ToJsonProperty();
        }

        public string Field { get; set; }

        public ComparisonOperator Operator { get; set; }

        public int Value { get; set; }
    }

    public class ComparisonFilterConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var filter = (ComparisonFilter) value;
            writer.WriteStartObject();
                writer.WritePropertyName(filter.Field);
                writer.WriteStartObject();
                    writer.WritePropertyName(filter.Operator.ToDescription());
                    writer.WriteValue(filter.Value);
                writer.WriteEndObject();
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

    public enum ComparisonOperator
    {
        [Description("lt")]
        LessThan,
        [Description("lte")]
        LessThanOrEqualTo,
        [Description("gt")]
        GreaterThan,
        [Description("gte")]
        GreaterThanOrEqualTo
    }

    public enum ItemType
    {
        Restaurant = 1,
        Packaged = 2,
        USDA = 3
    }
}
