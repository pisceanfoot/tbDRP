using System;
using System.Xml.Serialization;

namespace Top.Api.Response
{
    /// <summary>
    /// FenxiaoDealerRequisitionorderModifyResponse.
    /// </summary>
    public class FenxiaoDealerRequisitionorderModifyResponse : TopResponse
    {
        /// <summary>
        /// 操作是否成功。true：成功；false：失败。
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }
    }
}
