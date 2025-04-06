using Microsoft.AspNetCore.Mvc;
using Wilczura.Common.JsonApi.Controllers;
using Wilczura.JsonApiTest.Data.Entities;

namespace Wilczura.JsonApiTest.Controllers;

[Route("person-details")]
public class PersonDetailsController : CustomController<PersonDetailsView, int>
{
    public PersonDetailsController(CustomControllerDependencies<PersonDetailsView, int> dependencies)
        : base(dependencies)
    {
    }

    [HttpGet]
    [HttpHead]
    public override Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        return base.GetAsync(cancellationToken);
    }
}

