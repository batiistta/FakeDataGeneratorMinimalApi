using Bogus;
using Carter;
using FakeDataGeneratorMinimalApi.FakeData;
using FakeDataGeneratorMinimalApi.RateLimit;

namespace FakeDataGeneratorMinimalApi.Modules.PessoaJuridica
{
    public class Endpoints : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var pessoaJuridica = app.MapGroup("/api/v1/pessoaJuridica");

            pessoaJuridica.MapGet("/gerarUsuariosPessoaJuridicaFake", [RateLimit(TimeWindowInSeconds = 30, MaxRequests = 10)] async (int? count) =>
            {
                var faker = new Faker();
                var quantity = count.GetValueOrDefault(10);
                if (quantity > 1000) quantity = 1000;

                var companies = Enumerable.Range(1, quantity).Select(_ => new
                {
                    id = Guid.NewGuid().ToString(),
                    CompanyName = faker.Company.CompanyName(),
                    Address = faker.Address.FullAddress(),
                    Phone = faker.Phone.PhoneNumber("###########"),
                    CNPJ = FakeDataGenerator.GenerateCnpj()
                });
                return Results.Json(companies);
            });            
        }
    }
}
