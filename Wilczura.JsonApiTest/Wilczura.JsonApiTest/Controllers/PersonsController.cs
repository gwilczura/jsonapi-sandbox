using Microsoft.AspNetCore.Mvc;
using Wilczura.JsonApiTest.Common;
using Wilczura.JsonApiTest.Data.Entities;

namespace Wilczura.JsonApiTest.Controllers;

[Route("[controller]")]
public class PersonsController : GregController<Person, int>
{
    public PersonsController(GregControllerDependencies<Person,int> dependencies) 
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
