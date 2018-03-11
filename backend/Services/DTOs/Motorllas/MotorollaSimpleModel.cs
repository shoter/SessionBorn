using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Motorllas
{
    public class MotorollaSimpleModel
    {
        public MotorollaSimpleModelMetaHeader metaHeader { get; set; }

        public MotorollaSimpleModelMainHeader eventHeader { get; set; }
    }

    public class MotorollaSimpleModelMetaHeader
    {
        public string metaTimeStamp { get; set; }
        public string metaEventTypeLabel { get; set; }

    }

    public class MotorollaSimpleModelMainHeader
    {
        public string id { get; set; }
        public string label { get; set; }
        public string timeStamp { get; set; }
        public MotorllaSimpleModelLocation location { get; set; }
        public string expirationTimeStamp { get; set; }
        public string detailedDescription { get; set; }
        public MotorllaSimpleModelIcon icon { get; set; }
        public string priority { get; set; }
        public List<int> attachments => new List<int>();

    }
    public class MotorllaSimpleModelLocation
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class MotorllaSimpleModelIcon
    {
        public string url { get; set; }
    }
}
