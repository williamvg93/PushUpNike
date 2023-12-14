using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /* migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "addresstype",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contacttype",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "gendertype",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orderstatus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "paymenttype",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "prodcategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "prodcolor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userrol",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    number = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fkIdContactType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_contConType",
                        column: x => x.fkIdContactType,
                        principalTable: "contacttype",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fkIdCountry = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_counDepar",
                        column: x => x.fkIdCountry,
                        principalTable: "country",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fkIdProdCategory = table.Column<int>(type: "int", nullable: false),
                    fkIdColor = table.Column<int>(type: "int", nullable: false),
                    fkIdtGenderType = table.Column<int>(type: "int", nullable: false),
                    fkIdOrderDetail = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_pordColor",
                        column: x => x.fkIdColor,
                        principalTable: "prodcolor",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_prodCate",
                        column: x => x.fkIdProdCategory,
                        principalTable: "prodcategory",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_prodGenderType",
                        column: x => x.fkIdtGenderType,
                        principalTable: "gendertype",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fkIdDepartment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_deparCity",
                        column: x => x.fkIdDepartment,
                        principalTable: "department",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    complement = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fkIdAddressType = table.Column<int>(type: "int", nullable: false),
                    IkIdCity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_addressAddreType",
                        column: x => x.fkIdAddressType,
                        principalTable: "addresstype",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_addressCity",
                        column: x => x.IkIdCity,
                        principalTable: "city",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    age = table.Column<short>(type: "smallint", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fkIdContact = table.Column<int>(type: "int", nullable: false),
                    fkIdAddress = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_clientAddress",
                        column: x => x.fkIdAddress,
                        principalTable: "address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_clientContact",
                        column: x => x.fkIdContact,
                        principalTable: "contact",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fkIdClient = table.Column<int>(type: "int", nullable: false),
                    fkIdStatus = table.Column<int>(type: "int", nullable: false),
                    fkIdPaymentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_orderClient",
                        column: x => x.fkIdClient,
                        principalTable: "client",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_orderPayType",
                        column: x => x.fkIdPaymentType,
                        principalTable: "paymenttype",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_orderStatus",
                        column: x => x.fkIdStatus,
                        principalTable: "orderstatus",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fkIdRol = table.Column<int>(type: "int", nullable: false),
                    fkIdClient = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_userClient",
                        column: x => x.fkIdClient,
                        principalTable: "client",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_userRol",
                        column: x => x.fkIdRol,
                        principalTable: "userrol",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orderdetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fkIdOrder = table.Column<int>(type: "int", nullable: false),
                    fkIdProduct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_ordeDetOrder",
                        column: x => x.fkIdOrder,
                        principalTable: "order",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ordeDetProd",
                        column: x => x.fkIdProduct,
                        principalTable: "product",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "token",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fkIdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_tokenUser",
                        column: x => x.fkIdUser,
                        principalTable: "user",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "FK_addressAddreType",
                table: "address",
                column: "fkIdAddressType");

            migrationBuilder.CreateIndex(
                name: "FK_addressCity",
                table: "address",
                column: "IkIdCity");

            migrationBuilder.CreateIndex(
                name: "name",
                table: "addresstype",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_deparCity",
                table: "city",
                column: "fkIdDepartment");

            migrationBuilder.CreateIndex(
                name: "FK_clientContact",
                table: "client",
                column: "fkIdContact");

            migrationBuilder.CreateIndex(
                name: "code",
                table: "client",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fkIdAddress",
                table: "client",
                column: "fkIdAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_contConType",
                table: "contact",
                column: "fkIdContactType");

            migrationBuilder.CreateIndex(
                name: "Name3",
                table: "contacttype",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Name2",
                table: "country",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_counDepar",
                table: "department",
                column: "fkIdCountry");

            migrationBuilder.CreateIndex(
                name: "FK_orderClient",
                table: "order",
                column: "fkIdClient");

            migrationBuilder.CreateIndex(
                name: "FK_orderPayType",
                table: "order",
                column: "fkIdPaymentType");

            migrationBuilder.CreateIndex(
                name: "FK_orderStatus",
                table: "order",
                column: "fkIdStatus");

            migrationBuilder.CreateIndex(
                name: "FK_ordeDetOrder",
                table: "orderdetail",
                column: "fkIdOrder");

            migrationBuilder.CreateIndex(
                name: "FK_ordeDetProd",
                table: "orderdetail",
                column: "fkIdProduct");

            migrationBuilder.CreateIndex(
                name: "Name",
                table: "orderstatus",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Name1",
                table: "paymenttype",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_pordColor",
                table: "product",
                column: "fkIdColor");

            migrationBuilder.CreateIndex(
                name: "FK_prodCate",
                table: "product",
                column: "fkIdProdCategory");

            migrationBuilder.CreateIndex(
                name: "FK_prodGenderType",
                table: "product",
                column: "fkIdtGenderType");

            migrationBuilder.CreateIndex(
                name: "FK_tokenUser",
                table: "token",
                column: "fkIdUser");

            migrationBuilder.CreateIndex(
                name: "code1",
                table: "token",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_userClient",
                table: "user",
                column: "fkIdClient");

            migrationBuilder.CreateIndex(
                name: "FK_userRol",
                table: "user",
                column: "fkIdRol");

            migrationBuilder.CreateIndex(
                name: "Name4",
                table: "userrol",
                column: "Name",
                unique: true); */
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /* migrationBuilder.DropTable(
                name: "orderdetail");

            migrationBuilder.DropTable(
                name: "token");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "paymenttype");

            migrationBuilder.DropTable(
                name: "orderstatus");

            migrationBuilder.DropTable(
                name: "prodcolor");

            migrationBuilder.DropTable(
                name: "prodcategory");

            migrationBuilder.DropTable(
                name: "gendertype");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "userrol");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "addresstype");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "contacttype");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "country"); */
        }
    }
}
