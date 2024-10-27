using DittoBox.API.UserProfile.Application.Commands;
using DittoBox.API.UserProfile.Application.Handlers.Interfaces;
using DittoBox.API.UserProfile.Application.Queries;
using DittoBox.API.UserProfile.Application.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.UserProfile.Interface
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProfileController(
        ILogger<ProfileController> _logger,
        IGetProfileDetailsQueryHandler getProfileDetailsQueryHandler,
        IUpdateProfileNamesCommandHandler updateProfileNamesCommandHandler,
        IGrantPrivilegeCommandHandler grantPrivilegeCommandHandler,
        IRevokePrivilegeCommandHandler revokePrivilegeCommandHandler
    ) : ControllerBase
    {
        [HttpGet("{query:int}")]
        public async Task<ActionResult<ProfileResource>> GetProfileDetails([FromRoute] GetProfileQuery query)
        {
            try
            {
                var result = await getProfileDetailsQueryHandler.Handle(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting profile with profileId: {profileId}", query.ProfileId);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        [Route("update-names")]
        public async Task<ActionResult> UpdateProfileNames([FromBody] UpdateProfileNamesCommand command)
        {
            try
            {
                await updateProfileNamesCommandHandler.Handle(command);
                _logger.LogInformation("Profile names updated with profileId: {profileId}", command.ProfileId);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating profile names with profileId: {profileId}", command.ProfileId);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("grant-privileges")]
        public async Task<ActionResult> GrantPrivilege([FromBody] GrantPrivilegeCommand privilege)
        {
            try
            {
                await grantPrivilegeCommandHandler.Handle(privilege);
                _logger.LogInformation("Privileges granted with profileId: {profileId}", privilege.ProfileId);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while granting privileges with profileId: {profileId}", privilege.ProfileId);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        [Route("revoke-privileges")]
        public async Task<ActionResult> RevokePrivilege([FromBody] RevokePrivilegeCommand privilege)
        {
            try
            {
                await revokePrivilegeCommandHandler.Handle(privilege);
                _logger.LogInformation("Privileges revoked with profileId: {profileId}", privilege.ProfileId);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while revoking privileges with profileId: {profileId}", privilege.ProfileId);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
