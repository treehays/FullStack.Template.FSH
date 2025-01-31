﻿using App.Shared.ApiMessages.Identity.M003;
using App.Shared.ApiMessages.Identity.M007;
using App.Shared.ApiMessages.Identity.M004;
using App.Shared.ApiMessages.Identity.M005;
using App.Shared.ApiMessages.Identity.M006;
using App.Shared.ApiMessages.Identity.M008;
using App.Shared.Wrapper;


namespace App.Shared.Routes;
/// <summary>
/// Contains users API endpoints
/// <para>
/// All responses wrapped into <see cref="IResult"/>
/// </para>
/// </summary>
public class UserEndpoints
{
	/// <summary>
	/// Root path for users API
	/// <para>
	/// <list type="bullet">
	/// <item>
	///		<strong>GET</strong> - Get list of all users
	///		<para>
	///			Response:  - <see cref="M003Response"/>
	///		</para>
	/// </item>
	/// <item>
	///		<strong>POST</strong> - Create new user
	///		<para>
	///			Request - <see cref="M005Request"/>
	///		</para>
	/// </item>
	/// </list>
	/// </para>
	/// </summary>
	public const string Base = "api/identity/users";

	private const string _roles = "roles";
	private const string _selfRegister = "self-register";
	private const string _toogleStatus = "toogle-status";

	/// <summary>
	/// POST - Assign new roles for user
	/// <para>
	/// Request - <see cref="M008Request"/>
	/// </para>
	/// </summary>
	/// <returns></returns>
	public static string AssignRoles() => $"{Base}/{_roles}";

	/// <summary>
	/// GET - Get single user info
	/// <para>
	///	Response - <see cref="M007Response"/>
	/// </para>
	/// </summary>
	/// <param name="id">User Id</param>
	/// <returns></returns>
	public static string GetUser(string id) => $"{Base}/{id}";

	/// <summary>
	/// GET - Get user roles
	/// <para>
	/// Response - <see cref="M004Response"/>
	/// </para>
	/// </summary>
	/// <param name="id">User Id</param>
	/// <returns></returns>
	public static string GetUserRoles(string id) => $"{Base}/{id}/{_roles}";

	/// <summary>
	/// POST - Toogle user IsActive status
	/// <para>
	/// Request - <see cref="M006Request"/>
	/// </para>
	/// </summary>
	/// <returns></returns>
	public static string ToogleUserStatus() => $"{Base}/{_toogleStatus}";

	/// <summary>
	/// POST - Allow anonymous create user
	/// <para>
	/// Request - <see cref="M005Request"/>
	/// </para>
	/// </summary>
	/// <returns></returns>
	public static string SelfRegister() => $"{Base}/{_selfRegister}";
}
