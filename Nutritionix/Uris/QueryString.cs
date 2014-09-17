using System.Collections.Generic;
using System.Linq;

namespace Nutritionix
{
    internal class QueryString : Dictionary<string, string>
    {
        public override string ToString()
        {
            var nonEmptyParameters = this.Where(x => !string.IsNullOrEmpty(x.Value));
            IEnumerable<string> encodedValues = nonEmptyParameters.Select(x => string.Concat(x.Key, "=", System.Uri.EscapeDataString(x.Value)));
            return string.Join("&", encodedValues);
        }
    }
}