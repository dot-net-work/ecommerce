using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.DatabaseContext.Migrations
{
    public partial class Category_Id_long : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            ALTER TABLE Products DROP CONSTRAINT FK_Products_Categories_CategoryId;
            ALTER TABLE Categories DROP CONSTRAINT PK_Categories;   
            DROP INDEX [IX_Products_CategoryId] ON [dbo].[Products]
            
            
            ");
            migrationBuilder.AlterColumn<long>(
                name: "CategoryId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.Sql(@"ALTER TABLE Categories ADD CONSTRAINT PK_Categories PRIMARY KEY (Id);");
            migrationBuilder.Sql(@"ALTER TABLE Products ADD CONSTRAINT FK_Products_Categories_CategoryId FOREIGN KEY (CategoryId) REFERENCES Categories(Id);");
            migrationBuilder.Sql(@"CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [dbo].[Products](
	                             [CategoryId] ASC
                                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
