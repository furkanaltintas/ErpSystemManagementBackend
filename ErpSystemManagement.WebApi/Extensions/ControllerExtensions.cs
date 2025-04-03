using DomainResults.Common;
using Microsoft.AspNetCore.Mvc;

namespace ErpSystemManagement.WebApi.Extensions;

public static class ControllerExtensions
{
    public static IActionResult DomResult<T>(this ControllerBase controller, IDomainResult<T> domainResult)
    {
        if (domainResult.IsSuccess) return controller.Ok(domainResult);
        else return controller.NotFound(domainResult);
    }

    public static IActionResult Result<T>(this ControllerBase controller, T data)
    {
        if (data is not null) return controller.Ok(data);
        else return controller.NotFound("No Data");
    }
}