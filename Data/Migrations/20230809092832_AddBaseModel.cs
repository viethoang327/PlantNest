using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantNestApp.Data.Migrations
{
    public partial class AddBaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "slides",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "slides",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "slides",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "products",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "products",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "products",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "ordersDetail",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "ordersDetail",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "ordersDetail",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "orders",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "orders",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "orders",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "newsInCategories",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "newsInCategories",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "newsInCategories",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "newsCategories",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "newsCategories",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "newsCategories",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "news",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "news",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "news",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "conFigs",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "conFigs",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "conFigs",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "categoryInProducts",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "categoryInProducts",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "categoryInProducts",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "categoriesType",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "categoriesType",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "categoriesType",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "categories",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "categories",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "categories",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "carts",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "carts",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "carts",
                newName: "UpdatedBy");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "slides",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "slides",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "slides",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ordersDetail",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ordersDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "ordersDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "newsInCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "newsInCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "newsInCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "newsCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "newsCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "newsCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "news",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "news",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "news",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "conFigs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "conFigs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "conFigs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "categoryInProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "categoryInProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "categoryInProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "categoriesType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "categoriesType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "categoriesType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "carts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "carts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "slides");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "slides");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "slides");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "products");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "products");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "products");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ordersDetail");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ordersDetail");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "ordersDetail");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "newsInCategories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "newsInCategories");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "newsInCategories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "newsCategories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "newsCategories");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "newsCategories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "news");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "news");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "news");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "conFigs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "conFigs");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "conFigs");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "categoryInProducts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "categoryInProducts");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "categoryInProducts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "categoriesType");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "categoriesType");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "categoriesType");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "carts");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "slides",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "slides",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "slides",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "products",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "products",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "products",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ordersDetail",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ordersDetail",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "ordersDetail",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "orders",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "orders",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "orders",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "newsInCategories",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "newsInCategories",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "newsInCategories",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "newsCategories",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "newsCategories",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "newsCategories",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "news",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "news",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "news",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "conFigs",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "conFigs",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "conFigs",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "categoryInProducts",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "categoryInProducts",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "categoryInProducts",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "categoriesType",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "categoriesType",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "categoriesType",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "categories",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "categories",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "categories",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "carts",
                newName: "CreateBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "carts",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "carts",
                newName: "CreateDate");
        }
    }
}
