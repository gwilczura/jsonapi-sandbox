using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wilczura.JsonApiTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class view : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE OR REPLACE VIEW
persons_view AS
SELECT p.person_id, p.name, 'szakalaka'::citext AS person_details
FROM persons p
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
