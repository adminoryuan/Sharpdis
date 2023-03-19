using System.Security.Cryptography.X509Certificates;
using System;
namespace Sharpdis.Common.Expand
{
    public class ArgsVerifyAttribute: Attribute
    {
        public int? MinLength{get;set;}

        public int? MaxLength{get;set;}

        public string ErrorMessage{get;set;}


        public ArgsVerifyAttribute(int MinLength,string ErrorMessage="")
        {
            this.MinLength = MinLength;
            this.ErrorMessage = ErrorMessage;
        }
        public ArgsVerifyAttribute(int? MinLength ,int MaxLength, string ErrorMessage = "")
        {
            this.MinLength = MinLength;
            this.MaxLength = MaxLength;
            this.ErrorMessage = ErrorMessage;
        }
    }
}