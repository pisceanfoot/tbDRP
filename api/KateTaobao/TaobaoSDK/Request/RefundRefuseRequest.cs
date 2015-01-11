using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.refund.refuse
    /// </summary>
    public class RefundRefuseRequest : ITopUploadRequest<RefundRefuseResponse>
    {
        /// <summary>
        /// 退款单号
        /// </summary>
        public Nullable<long> RefundId { get; set; }

        /// <summary>
        /// 可选值为：售中：onsale，售后：aftersale，天猫退款为必填项。
        /// </summary>
        public string RefundPhase { get; set; }

        /// <summary>
        /// 退款版本号，天猫退款为必填项。
        /// </summary>
        public Nullable<long> RefundVersion { get; set; }

        /// <summary>
        /// 拒绝退款时的说明信息，长度2-200<br /> 支持最大长度为：200<br /> 支持的最大列表长度为：200
        /// </summary>
        public string RefuseMessage { get; set; }

        /// <summary>
        /// 拒绝退款时的退款凭证，一般是卖家拒绝退款时使用的发货凭证，最大长度130000字节，支持的图片格式：GIF, JPG, PNG。天猫退款为必填项。<br /> 支持的文件类型为：gif,jpg,png<br /> 支持的最大列表长度为：130000
        /// </summary>
        public FileItem RefuseProof { get; set; }

        private IDictionary<string, string> otherParameters;

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.refund.refuse";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("refund_id", this.RefundId);
            parameters.Add("refund_phase", this.RefundPhase);
            parameters.Add("refund_version", this.RefundVersion);
            parameters.Add("refuse_message", this.RefuseMessage);
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("refund_id", this.RefundId);
            RequestValidator.ValidateRequired("refuse_message", this.RefuseMessage);
            RequestValidator.ValidateMaxLength("refuse_message", this.RefuseMessage, 200);
            RequestValidator.ValidateMaxLength("refuse_proof", this.RefuseProof, 130000);
        }

        #endregion

        #region ITopUploadRequest Members

        public IDictionary<string, FileItem> GetFileParameters()
        {
            IDictionary<string, FileItem> parameters = new Dictionary<string, FileItem>();
            parameters.Add("refuse_proof", this.RefuseProof);
            return parameters;
        }

        #endregion

        public void AddOtherParameter(string key, string value)
        {
            if (this.otherParameters == null)
            {
                this.otherParameters = new TopDictionary();
            }
            this.otherParameters.Add(key, value);
        }
    }
}
