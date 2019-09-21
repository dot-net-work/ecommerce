using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.DatabaseContext.Migrations
{
    public partial class Product_PrimaryKey_Long : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            ALTER TABLE ProductOrder DROP CONSTRAINT FK_ProductOrder_Products_ProductId;
            ALTER TABLE ProductOrder DROP CONSTRAINT PK_ProductOrder;             
            ALTER TABLE Products DROP CONSTRAINT PK_Products;
            
            ");
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "ProductOrder",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.Sql(@"ALTER TABLE Products ADD CONSTRAINT PK_Products PRIMARY KEY (Id);");
            migrationBuilder.Sql(@"ALTER TABLE ProductOrder ADD CONSTRAINT PK_ProductOrder PRIMARY KEY(ProductId,OrderId)");
            migrationBuilder.Sql(@"ALTER TABLE ProductOrder ADD CONSTRAINT FK_ProductOrder_Products_ProductId FOREIGN KEY (ProductId) REFERENCES Products(Id);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Products",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductOrder",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
