using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StatlerWaldorfCorp.ES_CQRS_RealityConsumer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RealityController : ControllerBase
    {
        private ILocationCache locationCache;
        private ILogger logger;

        public RealityController(ILocationCache locationCache, ILogger<RealityController> logger)
        {
            this.locationCache = locationCache;
            this.logger = logger;
        }

        [HttpGet("teams/{teamId}/members")]
        public virtual IActionResult GetTeamMembersLocations(Guid teamId)
        {
            return this.Ok(locationCache.GetMemberLocations(teamId));
        }

        [HttpGet("teams/{teamId}/members/{memberId}")]
        public virtual IActionResult GetTeamMemberLocation(Guid teamId, Guid memberId)
        {
            return this.Ok(locationCache.GetMemberLocation(teamId, memberId));
        }

        [HttpPut("teams/{teamId}/members/{memberId}")]
        public virtual IActionResult UpdateTeamMemberLocation(Guid teamId, Guid memberId, [FromBody] MemberLocation memberLocation)
        {
            return this.Ok(locationCache.PutMemberLocation(teamId, memberId));
        }
    }
}