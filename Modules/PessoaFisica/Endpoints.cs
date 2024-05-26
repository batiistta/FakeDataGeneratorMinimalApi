using Bogus;
using Carter;
using FakeDataGeneratorMinimalApi.FakeData;
using FakeDataGeneratorMinimalApi.RateLimit;

namespace FakeDataGeneratorMinimalApi.Modules.PessoaFisica
{
    public class Endpoints : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var pessoaFisica = app.MapGroup("/api/v1/pessoaFisica");

            pessoaFisica.MapGet("/gerarUsuariosPessoaFisicaFake", [RateLimit(TimeWindowInSeconds = 30, MaxRequests = 10)] async (int? count) =>
            {
                var faker = new Faker();
                var quantity = count.GetValueOrDefault(10);
                if (quantity > 1000) quantity = 1000;

                var people = Enumerable.Range(1, quantity).Select(_ => new
                {
                    id = Guid.NewGuid().ToString(),
                    Name = faker.Name.FullName(),
                    Email = faker.Internet.Email(),
                    Cpf = FakeDataGenerator.GenerateCpf()
                });
                return Results.Json(people);
            });
        }
    }
}
