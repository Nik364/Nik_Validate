namespace Nik.Validate.Validate
{
    /// <summary>
    /// 数据校验结果类
    /// </summary>
    public class ValidateResult
    {
        public ValidateResult()
        {
            this.IsSuccess = true;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="isSuccess">是否校验通过</param>
        /// <param name="errorMessage">检验不通过提示信息</param>
        public ValidateResult(bool isSuccess, string errorMessage)
        {
            this.IsSuccess = isSuccess;
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 是否校验通过
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 检验不通过提示信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}