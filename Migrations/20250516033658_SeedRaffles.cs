using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rifa_Casa.Migrations
{
    /// <inheritdoc />
    public partial class SeedRaffles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var insertSql = new System.Text.StringBuilder();

            for (int i = 1; i <= 600; i++)
            {
                insertSql.AppendLine($"INSERT INTO \"Raffles\" (\"Number\", \"Available\") VALUES ({i}, true);");
            }

            migrationBuilder.Sql(insertSql.ToString());
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Raffles\";");
        }

    }
}
