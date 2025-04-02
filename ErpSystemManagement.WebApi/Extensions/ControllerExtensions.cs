using DomainResults.Common;
using Microsoft.AspNetCore.Mvc;

namespace ErpSystemManagement.WebApi.Extensions;

public static class ControllerExtensions
{
    public static IActionResult DomResult<T>(this ControllerBase controller, IDomainResult<T> domainResult)
    {
        if (domainResult.IsSuccess) return controller.Ok(domainResult);
        return controller.NotFound(domainResult);
    }
}