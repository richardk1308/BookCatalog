using BookCatalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.DbContexts
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;

        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book("Martin Kukučín", "Keď báčik z Chochoľova umrie")
                {
                    Id = 1,
                    Description = "Keď báčik z Chochoľova umrie je humoristicko-satirická poviedka od spisovateľa Martina Kukučína z roku 1890. Svojím rozsahom i koncepciou patrí k najvýznamnejším prvkom v slovenskej literatúre",
                },
                new Book("J. R. R. Tolkien", "The Lord of the Rings")
                {
                    Id = 2,
                    Description = "Pán prsteňov je epická trilógia v štýle fantasy, ktorú napísal J. R. R. Tolkien. Je to príbeh o priateľstve, svornosti a láske.",
                },
                new Book("Marcus Aurelius", "Myšlienky k sebe samému")
                {
                    Id = 3,
                    Description = "Rímska ríša sa na vrchole svojho rozmachu dostávala do čoraz búrlivejších pomerov, keď bola napádaná rôznymi kmeňmi spoza vonkajších hraníc ríše a zároveň v jej vnútri vznikali rozpory medzi samotnými Rimanmi. Marcus Aurelius sa stal cisárom práve v takýchto pohnutých časoch. Väčšiu časť svojej vlády bol nútený prežiť medzi vojskom v odľahlých častiach ríše v bojoch za zachovanie jej celistvosti a v snahe usporiadať pomery po často vznikajúcich rozbrojoch.",
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
