using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookCatalog.Migrations
{
    public partial class BookCatalogDB_SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorName", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Martin Kukučín", "Keď báčik z Chochoľova umrie je humoristicko-satirická poviedka od spisovateľa Martina Kukučína z roku 1890. Svojím rozsahom i koncepciou patrí k najvýznamnejším prvkom v slovenskej literatúre", "Keď báčik z Chochoľova umrie" },
                    { 2, "J. R. R. Tolkien", "Pán prsteňov je epická trilógia v štýle fantasy, ktorú napísal J. R. R. Tolkien. Je to príbeh o priateľstve, svornosti a láske.", "The Lord of the Rings" },
                    { 3, "Marcus Aurelius", "Rímska ríša sa na vrchole svojho rozmachu dostávala do čoraz búrlivejších pomerov, keď bola napádaná rôznymi kmeňmi spoza vonkajších hraníc ríše a zároveň v jej vnútri vznikali rozpory medzi samotnými Rimanmi. Marcus Aurelius sa stal cisárom práve v takýchto pohnutých časoch. Väčšiu časť svojej vlády bol nútený prežiť medzi vojskom v odľahlých častiach ríše v bojoch za zachovanie jej celistvosti a v snahe usporiadať pomery po často vznikajúcich rozbrojoch.", "Myšlienky k sebe samému" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
