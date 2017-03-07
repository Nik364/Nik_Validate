using Nik.Validate.Validate;
using Nik.Validate.Validate.Attributes;

namespace Nik.Validate.Models
{
    internal class User : IValidate
    {
        [Caption("手机号码")]
        [Regex(RegexExpression.Mobile)]
        public string Mobile { get; set; }

        [Caption("年龄")]
        [Range(1, 120)]
        public int Age { get; set; }

        [Range(30, 280, "身高数据异常")]
        public decimal Height { get; set; }
    }
}