using CleanArchitecture.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Extensions;

public static class ResultExtensions
{
    public static ActionResult<TValue> ToActionResult<TValue>(this Result<TValue> result)
    {
        if (!result.IsSuccess)
            return new BadRequestObjectResult(new { errors = result.Errors });

        return result.Value!;
    }

    public static ActionResult<List<TValue>> ToActionResult<TValue>(this IEnumerable<Result<TValue>> results)
    {
        var list = results.ToList();

        var failures = list.Where(r => r.IsFailure).ToList();
        if (failures.Any())
            return new BadRequestObjectResult(new { errors = failures.SelectMany(f => f.Errors).ToList() });

        var values = list
            .Where(r => r.IsSuccess && r.Value != null)
            .Select(r => r.Value!)
            .ToList();

        return values;
    }
}