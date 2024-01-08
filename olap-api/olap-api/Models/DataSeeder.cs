using olap_api.Data;

namespace olap_api.Models
{
    public class DataSeeder
    {
        private readonly ApiDbContext context;

        public DataSeeder(ApiDbContext context)
        {
            this.context = context;
        }

        public void Seed()
        {
            var indicators = new List<Indicator>() 
            { 
                  new Indicator()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nominal GDP in US Dollars",
                    Code = "NGDP_USD",
                },
                  new Indicator()
                {
                    Id = Guid.NewGuid(),
                    Name = "Average CPI inflation, percent change",
                    Code = "PCPI_PCH",
                },
                  new Indicator()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nominal GDP in US Dollars",
                    Code = "NGDP_USD",
                },
                  new Indicator()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nominal GDP in US Dollars",
                    Code = "NGDP_USD",
                }
            };

            context.Indicators.AddRange(indicators);
            context.SaveChanges();

            var countries = new List<Country>()
            {
                new Country()
                {
                    Id = Guid.NewGuid(),
                    Name = "Afghanistan",
                    Code = "512",
                },
                  new Country()
                {
                    Id = Guid.NewGuid(),
                    Name = "Albania",
                    Code = "914",
                },
                  new Country()
                {
                    Id = Guid.NewGuid(),
                    Name = "Canada",
                    Code = "156",
                },
                  new Country()
                {
                    Id = Guid.NewGuid(),
                    Name = "China",
                    Code = "924",
                },
                  new Country()
                {
                    Id = Guid.NewGuid(),
                    Name = "Germany",
                    Code = "134",
                }
            };

            context.Countries.AddRange(countries);
            context.SaveChanges();

            var dataPoints = new List<DataPoint>()
            {
                new DataPoint()
                {
                    Id = Guid.NewGuid(),
                    Countries = countries[0],
                    Indicators = indicators[0],
                    Frequency = "Q",
                    Date = DateTime.Parse("2002-01-01"),
                    Value = 3.500M,
                },
                new DataPoint()
                {
                    Id = Guid.NewGuid(),
                    Countries = countries[0],
                    Indicators = indicators[0],
                    Frequency = "Q",
                    Date = DateTime.Parse("2002-01-01"),
                    Value = 22.500M,
                },
                new DataPoint()
                {
                    Id = Guid.NewGuid(),
                    Countries = countries[0],
                    Indicators = indicators[0],
                    Frequency = "Q",
                    Date = DateTime.Parse("2002-01-01"),
                    Value = 44.500M,
                },
                  new DataPoint()
                {
                    Id = Guid.NewGuid(),
                    Countries = countries[1],
                    Indicators = indicators[1],
                    Frequency = "A",
                    Date = DateTime.Parse("2003-01-01"),
                    Value = 5.500M,
                },
                  new DataPoint()
                {
                    Id = Guid.NewGuid(),
                    Countries = countries[2],
                    Indicators = indicators[2],
                    Frequency = "A",
                    Date = DateTime.Parse("2005-01-01"),
                    Value = 12.500M,
                },
                  new DataPoint()
                {
                    Id = Guid.NewGuid(),
                    Countries = countries[2],
                    Indicators = indicators[2],
                    Frequency = "A",
                    Date = DateTime.Parse("2005-01-01"),
                    Value = 14.500M,
                },
                  new DataPoint()
                {
                    Id = Guid.NewGuid(),
                    Countries = countries[3],
                    Indicators = indicators[3],
                    Frequency = "A",
                    Date = DateTime.Parse("2006-01-01"),
                    Value = 14.500M,
                },
                  new DataPoint()
                {
                    Id = Guid.NewGuid(),
                    Countries = countries[3],
                    Indicators = indicators[3],
                    Frequency = "A",
                    Date = DateTime.Parse("2006-01-01"),
                    Value = 45.500M,
                },
                  new DataPoint()
                {
                    Id = Guid.NewGuid(),
                    Countries = countries[4],
                    Indicators = indicators[3],
                    Frequency = "Q",
                    Date = DateTime.Parse("2007-01-01"),
                    Value = 16.500M,
                },
                  new DataPoint()
                {
                    Id = Guid.NewGuid(),
                    Countries = countries[4],
                    Indicators = indicators[3],
                    Frequency = "Q",
                    Date = DateTime.Parse("2007-01-01"),
                    Value = 19.500M,
                },
                  new DataPoint()
                {
                    Id = Guid.NewGuid(),
                    Countries = countries[4],
                    Indicators = indicators[1],
                    Frequency = "A",
                    Date = DateTime.Parse("2008-01-01"),
                    Value = 17.500M,
                },
            };

            context.DataPoints.AddRange(dataPoints);
            context.SaveChanges();
        }
    }
}
