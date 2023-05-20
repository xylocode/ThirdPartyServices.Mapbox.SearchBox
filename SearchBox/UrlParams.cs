using System.Collections.Specialized;
using System.Web;

namespace XyloCode.ThirdPartyServices.Mapbox.SearchBox
{
    internal class UrlParams
    {
        readonly NameValueCollection nvc;
        public UrlParams()
        {
            nvc = HttpUtility.ParseQueryString(string.Empty);
        }

        public string this[string name]
        {
            get => nvc[name];
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    nvc.Remove(name);
                else
                    nvc[name] = value;
            }
        }

        public override string ToString()
        {
            return nvc.ToString() ?? string.Empty;
        }
    }
}
