using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Http
{
    public class  HttpCodes
    {
        public static HttpCode UnprocessableEntity = new HttpCode(422);
    }

    public class HttpCode
    {
        public readonly int value;
        public HttpCode(int value)
        {
            this.value = value;
        }

        public static implicit operator int(HttpCode code)
        {
            return code.value;
        }

    }
}
