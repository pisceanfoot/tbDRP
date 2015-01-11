using System;
using System.Xml.Serialization;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallProductSchemaMatchResponse.
    /// </summary>
    public class TmallProductSchemaMatchResponse : TopResponse
    {
        /// <summary>
        /// 返回匹配产品ID
        /// </summary>
        [XmlElement("match_result")]
        public string MatchResult { get; set; }
    }
}
