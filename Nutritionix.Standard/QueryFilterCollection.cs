using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Newtonsoft.Json;
using Nutritionix.Standard.Extensions;

namespace Nutritionix.Standard
{
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(QueryFilterCollectionConverter))]
    public class QueryFilterCollection : List<QueryFilter>
    {
        
    }

    internal class QueryFilterCollectionConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var filters = (QueryFilterCollection)value;

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
            return objectType == typeof(QueryFilterCollection);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [JsonObject, JsonConverter(typeof(QueryFilterConverter))]
    public class QueryFilter
    {
        /// <summary>
        /// 
        /// </summary>
        public QueryFilter()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemPropertyExpression"></param>
        /// <param name="value"></param>
        public QueryFilter(Expression<Func<Item, string>> itemPropertyExpression, string value)
        {
            Field = itemPropertyExpression.ToJsonProperty();
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
    }

    internal class QueryFilterConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var filter = (QueryFilter) value;

            writer.WritePropertyName(filter.Field);
            writer.WriteValue(filter.Value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(QueryFilter);
        }
    }
}
