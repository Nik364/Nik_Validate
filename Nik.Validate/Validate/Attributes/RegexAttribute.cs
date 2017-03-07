using System.Text.RegularExpressions;

namespace Nik.Validate.Validate.Attributes
{
    public class RegexAttribute : ValidateAttribute
    {
        private string regex = null;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="regex">正则</param>
        public RegexAttribute(string regex)
            : this(regex, "{0}格式错误")
        {
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="regex">正则</param>
        /// <param name="errorMessage">校验失败提示信息</param>
        public RegexAttribute(string regex, string errorMessage)
        {
            this.regex = regex;
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 校验数据是否合法
        /// </summary>
        /// <param name="value">待校验的值</param>
        /// <returns></returns>
        public override bool Validate(object value)
        {
            if (value == null)
            {
                return false;
            }

            return new Regex(regex).IsMatch(value.ToString());
        }
    }
}