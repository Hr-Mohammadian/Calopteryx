using Microsoft.AspNetCore.Components;

namespace Calopteryx.BuildingBlocks.Infrastructures.Controller;

[Route("api/v{version:apiVersion}/[controller]")]
public class VersionedApiController : BaseApiController
{
}
