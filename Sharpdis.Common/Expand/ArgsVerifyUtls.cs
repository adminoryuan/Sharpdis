using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Common.Expand
{
    /// <summary>
    /// 特性参数校验工具类
    /// </summary>
    public class ArgsVerifyUtls
    {
        private static bool ArgsVerifyAttribute(ArgsVerifyAttribute argsVerify, string[] body)
        {
            var minLength = argsVerify.MinLength;
            var maxLength = argsVerify.MaxLength;
            var verityRes = minLength==null|| body.Length > minLength;
            verityRes = verityRes &&(maxLength == null || body.Length > minLength);
            return verityRes;
        }

        public static (bool,string?) VerifyRequstBody(Type type, string[] requestBody)
        {
            Attribute[] atrs = Attribute.GetCustomAttributes(type, true);
            foreach (Attribute att in atrs)
            {
                if (att is ArgsVerifyAttribute)
                {
                    if (!ArgsVerifyAttribute((ArgsVerifyAttribute)att, requestBody)){
                        return (false, ((ArgsVerifyAttribute)att).ErrorMessage);
                    }
                }
            }
            return (true, null);
        }

    }
}
