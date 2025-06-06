using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class SearchQueryBuilder
    {
        private string _query = string.Empty;

        public SearchQueryBuilder SetQuery(string query)
        {
            _query = query;
            return this;
        }

        public string Build() => _query;
    }

}
