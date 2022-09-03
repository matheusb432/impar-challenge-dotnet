﻿using ImparApp.Application.Extensions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.OData.ModelBuilder;

namespace ImparApp.Api.Configurations
{
    public sealed class ODataQueryAttribute : EnableQueryAttribute
    {
        public ODataQueryAttribute()
        {


        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null) return;

            base.OnActionExecuted(actionExecutedContext);

            var oDataFeature = actionExecutedContext.HttpContext.ODataFeature();
            if (oDataFeature.TotalCount.HasValue && actionExecutedContext.Result is ObjectResult obj && obj.Value is IQueryable<object> queryable)
                actionExecutedContext.Result = new ObjectResult(new PaginatedViewModel(oDataFeature.TotalCount, queryable)) { StatusCode = 200 };
        }
    }
}
