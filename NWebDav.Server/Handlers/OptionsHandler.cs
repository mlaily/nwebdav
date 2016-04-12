﻿using System;
using System.Threading.Tasks;

using NWebDav.Server.Helpers;
using NWebDav.Server.Http;
using NWebDav.Server.Stores;

namespace NWebDav.Server.Handlers
{
    public class OptionsHandler : IRequestHandler
    {
        public Task<bool> HandleRequestAsync(IHttpContext httpContext, IStore store)
        {
            // Obtain response
            var response = httpContext.Response;

            // We're a DAV class 2 server
            response.SetHeaderValue("DAV", "2");

            // Set the Allow/Public headers
            response.SetHeaderValue("Allow", string.Join(" ", RequestHandlerFactory.AllowedMethods));
            response.SetHeaderValue("Public", string.Join(" ", RequestHandlerFactory.AllowedMethods));

            // Finished
            response.SendResponse(DavStatusCode.Ok);
            return Task.FromResult(true);
        }
    }
}
