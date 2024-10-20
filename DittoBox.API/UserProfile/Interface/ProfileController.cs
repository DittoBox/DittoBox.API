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
        public ActionResult<ProfileDto> GetProfileDetails([FromRoute] GetProfileQuery profileId)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult<ProfileDto> UpdateProfileNames([FromBody] UpdateProfileNamesCommand profile)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult<ProfileDto> GrantPrivilege([FromBody] GrantPrivilegeCommand privilege)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult<ProfileDto> RevokePrivilege([FromBody] RevokePrivilegeCommand privilege)
        {
            throw new NotImplementedException();
        }
    }
}
