﻿using Calopteryx.BuildingBlocks.Abstractions.Wrapper;
using Calopteryx.BuildingBlocks.Infrastructures.Middleware;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Calopteryx.BuildingBlocks.Infrastructures.Controller;

#nullable disable
#pragma warning disable RCS1163, IDE0060

public static class CalopteryxApiConventions
{
    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(HttpValidationProblemDetails))]
    [ProducesDefaultResponseType(typeof(ErrorResult<>))]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Search(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object request)
    {
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(HttpValidationProblemDetails))]
    [ProducesDefaultResponseType(typeof(ErrorResult))]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Get()
    {
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(HttpValidationProblemDetails))]
    [ProducesDefaultResponseType(typeof(ErrorResult))]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Get(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object id)
    {
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(HttpValidationProblemDetails))]
    [ProducesDefaultResponseType(typeof(ErrorResult))]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Get(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object id,
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object cancellationtoken)
    {
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(HttpValidationProblemDetails))]
    [ProducesDefaultResponseType(typeof(ErrorResult))]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Post(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object request)
    {
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(HttpValidationProblemDetails))]
    [ProducesDefaultResponseType(typeof(ErrorResult))]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Post(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object request,
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object cancellationToken)
    {
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(HttpValidationProblemDetails))]
    [ProducesDefaultResponseType(typeof(ErrorResult))]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Register(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object request)
    {
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(HttpValidationProblemDetails))]
    [ProducesDefaultResponseType(typeof(ErrorResult))]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Create(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object request)
    {
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(HttpValidationProblemDetails))]
    [ProducesDefaultResponseType(typeof(ErrorResult))]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Update(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object request)
    {
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(HttpValidationProblemDetails))]
    [ProducesDefaultResponseType(typeof(ErrorResult))]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Update(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object request,
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object id)
    {
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(HttpValidationProblemDetails))]
    [ProducesDefaultResponseType(typeof(ErrorResult))]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Update(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object request,
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object id,
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object cancellationToken)
    {
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(HttpValidationProblemDetails))]
    [ProducesDefaultResponseType(typeof(ErrorResult))]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Put(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object request,
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object id)
    {
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(HttpValidationProblemDetails))]
    [ProducesDefaultResponseType(typeof(ErrorResult))]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Put(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object request,
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object id,
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object cancellationToken)
    {
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(HttpValidationProblemDetails))]
    [ProducesDefaultResponseType(typeof(ErrorResult))]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Delete(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object id)
    {
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(HttpValidationProblemDetails))]
    [ProducesDefaultResponseType(typeof(ErrorResult))]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Delete(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object id,
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object cancellationToken)
    {
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(HttpValidationProblemDetails))]
    [ProducesDefaultResponseType(typeof(ErrorResult))]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Generate(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object request)
    {
    }
}