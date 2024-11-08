﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using SSCMS.Configuration;
using SSCMS.Repositories;
using SSCMS.Services;

namespace SSCMS.Web.Controllers.Admin.Common.Form
{
    [OpenApiIgnore]
    [Authorize(Roles = Types.Roles.Administrator)]
    [Route(Constants.ApiAdminPrefix)]
    public partial class LayerVideoUploadController : ControllerBase
    {
        private const string Route = "common/form/layerVideoUpload";

        private readonly IPathManager _pathManager;
        private readonly IVodManager _vodManager;
        private readonly IStorageManager _storageManager;
        private readonly ISiteRepository _siteRepository;
        private readonly IMaterialVideoRepository _materialVideoRepository;

        public LayerVideoUploadController(
            IPathManager pathManager,
            IVodManager vodManager,
            IStorageManager storageManager,
            ISiteRepository siteRepository,
            IMaterialVideoRepository materialVideoRepository
        )
        {
            _pathManager = pathManager;
            _vodManager = vodManager;
            _storageManager = storageManager;
            _siteRepository = siteRepository;
            _materialVideoRepository = materialVideoRepository;
        }

        public class Options
        {
            public bool IsChangeFileName { get; set; }
            public bool IsLibrary { get; set; }
        }

        public class GetResult : Options
        {
            public bool IsCloudVod { get; set; }
            public string VideoUploadExtensions { get; set; }
        }

        public class SubmitRequest : Options
        {
            public int SiteId { get; set; }
        }

        public class SubmitResult
        {
            public bool Success { get; set; }
            public string ErrorMessage { get; set; }
            public string CoverUrl { get; set; }
            public string PlayUrl { get; set; }
            public string VirtualUrl { get; set; }
        }
    }
}
