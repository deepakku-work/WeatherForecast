namespace TestApp.V1.Controllers
{
    using Microsoft.AspNet.OData;
    using Microsoft.AspNetCore.Mvc;

    [ODataFormatting]
    [ODataRouting]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class BaseODataController : ODataController
    {
    }
}
