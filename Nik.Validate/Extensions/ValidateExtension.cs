using Nik.Validate.Validate;
using Nik.Validate.Validate.Attributes;
using System;
using System.Reflection;

namespace Nik.Validate.Extensions
{
    public static class ValidateExtension
    {
        /// <summary>
        /// 校验对象属性值是否合法
        /// </summary>
        /// <param name="obj">待校验对象</param>
        /// <returns></returns>
        public static ValidateResult Validate(this IValidate obj)
        {
            ValidateResult result = new ValidateResult();

            PropertyInfo[] infos = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo p in infos)
            {
                //获取数据校验特性。
                Attribute[] attrs = Attribute.GetCustomAttributes(p, typeof(ValidateAttribute), false);
                if (attrs.Length <= 0)
                {
                    continue;
                }

                //获取名称描述特性
                CaptionAttribute caption = Attribute.GetCustomAttribute(p, typeof(CaptionAttribute), false) as CaptionAttribute;
                object value = p.GetValue(obj);

                foreach (Attribute attr in attrs)
                {
                    ValidateAttribute validate = attr as ValidateAttribute;
                    if (validate == null)
                    {
                        continue;
                    }

                    result = Validate(validate, value, caption);
                    if (!result.IsSuccess)
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 校验数据是否合法
        /// </summary>
        /// <param name="validate">校验规则</param>
        /// <param name="value">待校验值</param>
        /// <param name="caption">描述</param>
        /// <returns></returns>
        private static ValidateResult Validate(ValidateAttribute validate, object value, CaptionAttribute caption)
        {
            ValidateResult result = new ValidateResult();

            if (!validate.Validate(value))
            {
                result.IsSuccess = false;
                if (caption == null)
                {
                    result.ErrorMessage = validate.GetErrorMessage();
                }
                else
                {
                    result.ErrorMessage = validate.GetErrorMessage(caption.Name);
                }
            }
            return result;
        }
    }
}