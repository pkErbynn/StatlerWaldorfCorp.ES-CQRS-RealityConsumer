using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
using StatlerWaldorfCorp.ES_CQRS_RealityConsumer.Models;

namespace StatlerWaldorfCorp.ES_CQRS_RealityConsumer.Location.Redis
{
    public class RedisLocationCache : ILocationCache
    {
        private ILogger logger;
        private IConnectionMultiplexer connection;

        public RedisLocationCache(ILogger<RedisLocationCache> logger, IConnectionMultiplexer connection)
        {
            this.logger = logger;
            this.connection = connection;

            logger.LogInformation($"Using redis location cache - {connection.Configuration}");
        }

        public RedisLocationCache(ILogger<RedisLocationCache> logger,
            ConnectionMultiplexer connection) : this(logger, (IConnectionMultiplexer)connection)
        {
        }

        public IList<MemberLocation> GetMemberLocations(Guid teamId)
        {
            IDatabase db = connection.GetDatabase();
            RedisValue[] values = db.HashValues(teamId.ToString());

            return ConvertRedisValuesToLocationList(values);
        }

        public MemberLocation GetMemberLocation(Guid teamId, Guid memberId)
        {
            IDatabase db = connection.GetDatabase();
            var value = (string)db.HashGet(teamId.ToString(), memberId.ToString());
            var memberLocation= MemberLocation.FromJsonStringToModel(value);
            return memberLocation;
        }

        public void PutMemberLocation(Guid teamId, MemberLocation memberLocation)
        {
            IDatabase db = connection.GetDatabase();
            db.HashSet(teamId.ToString(), memberLocation.MemberId.ToString(), memberLocation.ToJsonString());   // { "teamId": { "MemberId1": "memberLocation1"  } } 
        }

        private IList<MemberLocation> ConvertRedisValuesToLocationList(RedisValue[] redisValues)
        {
            List<MemberLocation> memberLocations = new List<MemberLocation>();
            foreach (var value in redisValues)
            {
                string val = (string)value;
                MemberLocation ml = MemberLocation.FromJsonStringToModel(val);
                memberLocations.Add(ml);
            }
            return memberLocations;
        }
    }
}