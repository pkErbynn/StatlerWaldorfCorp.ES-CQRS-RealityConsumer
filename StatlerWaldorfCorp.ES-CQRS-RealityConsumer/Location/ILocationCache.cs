using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatlerWaldorfCorp.ES_CQRS_RealityConsumer.Models;

namespace StatlerWaldorfCorp.ES_CQRS_RealityConsumer.Location
{
    public interface ILocationCache
    {
        IList<MemberLocation> GetMemberLocations(Guid teamId);
        void PutMemberLocation(Guid teamId, MemberLocation memberLocation);
        MemberLocation GetMemberLocation(Guid teamId, Guid memberId);
    }
}