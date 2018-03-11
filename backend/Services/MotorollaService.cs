using Services.DTOs.Motorllas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MotorollaService : IMotorollaService
    {
        private static readonly HttpClient client = new HttpClient();
        void DoRequest(MotorollaSimpleModel model)
        {

        }
    }
}
