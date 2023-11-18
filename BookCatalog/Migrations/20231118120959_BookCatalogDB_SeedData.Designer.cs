﻿// <auto-generated />
using BookCatalog.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookCatalog.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20231118120959_BookCatalogDB_SeedData")]
    partial class BookCatalogDB_SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookCatalog.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorName = "Martin Kukučín",
                            Description = "Keď báčik z Chochoľova umrie je humoristicko-satirická poviedka od spisovateľa Martina Kukučína z roku 1890. Svojím rozsahom i koncepciou patrí k najvýznamnejším prvkom v slovenskej literatúre",
                            Title = "Keď báčik z Chochoľova umrie"
                        },
                        new
                        {
                            Id = 2,
                            AuthorName = "J. R. R. Tolkien",
                            Description = "Pán prsteňov je epická trilógia v štýle fantasy, ktorú napísal J. R. R. Tolkien. Je to príbeh o priateľstve, svornosti a láske.",
                            Title = "The Lord of the Rings"
                        },
                        new
                        {
                            Id = 3,
                            AuthorName = "Marcus Aurelius",
                            Description = "Rímska ríša sa na vrchole svojho rozmachu dostávala do čoraz búrlivejších pomerov, keď bola napádaná rôznymi kmeňmi spoza vonkajších hraníc ríše a zároveň v jej vnútri vznikali rozpory medzi samotnými Rimanmi. Marcus Aurelius sa stal cisárom práve v takýchto pohnutých časoch. Väčšiu časť svojej vlády bol nútený prežiť medzi vojskom v odľahlých častiach ríše v bojoch za zachovanie jej celistvosti a v snahe usporiadať pomery po často vznikajúcich rozbrojoch.",
                            Title = "Myšlienky k sebe samému"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
