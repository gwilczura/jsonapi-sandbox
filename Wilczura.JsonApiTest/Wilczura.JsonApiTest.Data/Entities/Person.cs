using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wilczura.JsonApiTest.Data.Entities;

[Resource(PublicName ="persons", GenerateControllerEndpoints = JsonApiDotNetCore.Controllers.JsonApiEndpoints.None)]
public class Person : Identifiable<int>
{
    [Attr]
    [Column($"person_id")]
    public override int Id { get => base.Id; set => base.Id = value; }

    [Attr]
    [Column(TypeName = "citext")]
    public string Name { get; set; } = null!;
}
