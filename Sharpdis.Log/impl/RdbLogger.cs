using Sharpdis.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Log.impl
{
    public class RdbLogger : absLogger
    {
        public RdbLogger(string fileName) : base(fileName)
        {

        }

        public override void LoadLog(Action<RespRequestEntity> func)
        {
            throw new NotImplementedException();
        }

        public override void WriteLog(byte[] cmd)
        {
            throw new NotImplementedException();
        }
    }
}
