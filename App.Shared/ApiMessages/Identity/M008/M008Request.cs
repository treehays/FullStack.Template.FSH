﻿using App.Shared.ApiMessages.Base;

namespace App.Shared.ApiMessages.Identity.M008;

/// <summary>
/// Assign roles request
/// </summary>
public record M008Request(string UserId, List<UserRoleDto> Roles);
