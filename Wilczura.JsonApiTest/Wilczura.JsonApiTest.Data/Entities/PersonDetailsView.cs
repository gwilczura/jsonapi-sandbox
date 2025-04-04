using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wilczura.JsonApiTest.Data.Entities;

[Resource(PublicName = "person-details", GenerateControllerEndpoints = JsonApiDotNetCore.Controllers.JsonApiEndpoints.None)]
public class PersonDetailsView : Identifiable<int>
{
    [Attr]
    [Column($"person_id")]
    public override int Id { get => base.Id; set => base.Id = value; }

    [Attr]
    public string Name { get; set; } = null!;

    [Attr]
    public string PersonDetails { get; set; } = null!;
}