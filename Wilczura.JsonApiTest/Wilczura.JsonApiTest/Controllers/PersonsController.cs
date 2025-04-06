using Microsoft.AspNetCore.Mvc;
using Wilczura.Common.JsonApi.Controllers;
using Wilczura.JsonApiTest.Data.Entities;

namespace Wilczura.JsonApiTest.Controllers;

[Route("[controller]")]
public class PersonsController : CustomController<Person, int>
{
    public PersonsController(CustomControllerDependencies<Person,int> dependencies) 
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
