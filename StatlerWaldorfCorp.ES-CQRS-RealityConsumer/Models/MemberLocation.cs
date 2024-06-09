using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StatlerWaldorfCorp.ES_CQRS_RealityConsumer.Models
{
    public class MemberLocation
    {
        public Guid MemberId { get; set; }
        public GpsCoordinate Location { get; set; }

        public string ToJsonString() {
            return JsonConvert.SerializeObject(this);
        }

        public static MemberLocation FromJsonStringToModel(string jsonString){
            return JsonConvert.DeserializeObject<MemberLocation>(jsonString);
        }
    }
}