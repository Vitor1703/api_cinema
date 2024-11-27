using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTicketForMultipleSeatsAndPriceReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Passo 1: Adicionar a nova coluna TicketPriceId como nullable
            migrationBuilder.AddColumn<int>(
                name: "TicketPriceId",
                table: "Tickets",
                type: "int",
                nullable: true);

            // Passo 2: Criar uma entrada padrão na tabela TicketPrices
            migrationBuilder.Sql(
                "INSERT INTO \"TicketPrices\" (\"Price\", \"CreatedAt\", \"UpdatedAt\", \"IsActive\") " +
                "VALUES (0.0, NOW(), NOW(), true);");

            // Passo 3: Atualizar os registros existentes na tabela Tickets para usar o ID do preço padrão
            migrationBuilder.Sql(
                "UPDATE \"Tickets\" SET \"TicketPriceId\" = 1 WHERE \"TicketPriceId\" IS NULL;");

            // Passo 4: Tornar a coluna TicketPriceId não-nullable
            migrationBuilder.AlterColumn<int>(
                name: "TicketPriceId",
                table: "Tickets",
                type: "int",
                nullable: false);

            // Passo 5: Criar a coluna SeatNumbers (para múltiplos assentos)
            migrationBuilder.AddColumn<string>(
                name: "SeatNumbers",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            // Passo 6: Criar o índice para TicketPriceId
            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketPriceId",
                table: "Tickets",
                column: "TicketPriceId");

            // Passo 7: Adicionar a chave estrangeira para TicketPriceId
            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketPrices_TicketPriceId",
                table: "Tickets",
                column: "TicketPriceId",
                principalTable: "TicketPrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketPrices_TicketPriceId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketPriceId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SeatNumbers",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TicketPriceId",
                table: "Tickets",
                newName: "SeatNumber");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Tickets",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
