using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using Newtonsoft.Json;
using Nutritionix.Extensions;

namespace Nutritionix
{
    [JsonObject]
    public class SearchFilterCollection : List<ISearchFilter>
    {

    }

    [JsonObject]
    public interface ISearchFilter
    {

    }

    [JsonObject]
    public class NegatedSearchFilter : ISearchFilter
    {
        public ISearchFilter Filter { get; set; }
    }

    [JsonObject]
    public class ItemTypeFilter : ISearchFilter
    {
        [JsonProperty("item_type")]
        public ItemType Type { get; set; }
    }

    [JsonConverter(typeof(RangeSearchFilterConverter))]
    public class RangeSearchFilter : ISearchFilter
    {
        public RangeSearchFilter()
        {
            
        }

        public RangeSearchFilter(Expression<Func<Item, decimal?>> itemPropertyExpression)
        {
            Field = itemPropertyExpression.ToJsonProperty();
        }

        public string Field { get; set; }

        public decimal From { get; set; }

        public decimal To { get; set; }
    }

    public class RangeSearchFilterConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var filter = (RangeSearchFilter) value;
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
            return objectType == typeof(RangeSearchFilter);
        }
    }

    [JsonConverter(typeof(ComparisonSearchFilterConverter))]
    public class ComparisonSearchFilter : ISearchFilter
    {
        public ComparisonSearchFilter()
        {
            
        }

        public ComparisonSearchFilter(Expression<Func<Item, decimal?>> itemPropertyExpression)
        {
            Field = itemPropertyExpression.ToJsonProperty();
        }

        public string Field { get; set; }

        public ComparisonOperator Operator { get; set; }

        public decimal Value { get; set; }
    }

    public class ComparisonSearchFilterConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var filter = (ComparisonSearchFilter) value;
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
            return objectType == typeof(ComparisonSearchFilter);
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
