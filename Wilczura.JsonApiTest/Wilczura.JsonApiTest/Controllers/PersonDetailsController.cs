using Microsoft.AspNetCore.Mvc;
using Wilczura.JsonApiTest.Common;
using Wilczura.JsonApiTest.Data.Entities;

namespace Wilczura.JsonApiTest.Controllers;

[Route("person-details")]
public class PersonDetailsController : GregController<PersonDetailsView, int>
{
    public PersonDetailsController(GregControllerDependencies<PersonDetailsView, int> dependencies)
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

