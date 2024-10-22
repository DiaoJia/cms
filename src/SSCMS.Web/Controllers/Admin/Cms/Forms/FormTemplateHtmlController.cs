﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SSCMS.Configuration;
using SSCMS.Dto;
using SSCMS.Repositories;
using SSCMS.Services;

namespace SSCMS.Web.Controllers.Admin.Cms.Forms
{
    [OpenApiIgnore]
    [Authorize(Roles = Types.Roles.Administrator)]
    [Route(Constants.ApiAdminPrefix)]
    public partial class FormTemplateHtmlController : ControllerBase
    {
        private const string Route = "cms/forms/formTemplateHtml";

        private readonly IAuthManager _authManager;
        private readonly IFormManager _formManager;
        private readonly ISiteRepository _siteRepository;

        public FormTemplateHtmlController(
            IAuthManager authManager,
            IFormManager formManager,
            ISiteRepository siteRepository
        )
        {
            _authManager = authManager;
            _formManager = formManager;
            _siteRepository = siteRepository;
        }

        public class GetRequest : SiteRequest
        {
            public bool IsSystem { get; set; }
            public string Name { get; set; }
        }

        public class GetResult
        {
            public string TemplateHtml { get; set; }
        }

        public class SubmitRequest : SiteRequest
        {
            public string Name { get; set; }
            public string TemplateHtml { get; set; }
        }
    }
}
