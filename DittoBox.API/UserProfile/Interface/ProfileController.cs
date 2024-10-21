using DittoBox.API.UserProfile.Application.Commands;
using DittoBox.API.UserProfile.Application.DTOs;
using DittoBox.API.UserProfile.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.UserProfile.Interface
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProfileController : ControllerBase
    {
        [HttpGet("{profileId}")]
        public ActionResult<ProfileResource> GetProfileDetails([FromRoute] GetProfileQuery profileId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult<ProfileResource> UpdateProfileNames([FromBody] UpdateProfileNamesCommand profile)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult<ProfileResource> GrantPrivilege([FromBody] GrantPrivilegeCommand privilege)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult<ProfileResource> RevokePrivilege([FromBody] RevokePrivilegeCommand privilege)
        {
            throw new NotImplementedException();
        }
    }
}
