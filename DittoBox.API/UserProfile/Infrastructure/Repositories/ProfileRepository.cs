﻿using DittoBox.API.Shared.Infrastructure.Repositories;
using DittoBox.API.UserProfile.Domain.Models.Entities;
using DittoBox.API.UserProfile.Domain.Repositories;

namespace DittoBox.API.UserProfile.Infrastructure.Repositories
{
    public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
    {
    }
}