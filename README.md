### Minimal API de Dados Fakes
## 📋 Descrição
Esta é uma aplicação Minimal API que fornece endpoints para geração de dados falsos de pessoas físicas e jurídicas. Os dados gerados incluem nomes, endereços, números de telefone, CPFs/CNPJs e outros dados relevantes.

## 🎯 Endpoints
- GET /api/v1/pessoaFisica/gerarUsuariosPessoaFisicaFake?count={count}: Gera dados falsos de pessoas físicas. O parâmetro count especifica a quantidade de dados a serem gerados (máximo de 1000 por requisição).
- GET /api/v1/pessoaJuridica/gerarUsuariosPessoaJuridicaFake?count={count}: Gera dados falsos de pessoas jurídicas. O parâmetro count especifica a quantidade de dados a serem gerados (máximo de 1000 por requisição).

## ⚙️ Configuração
Certifique-se de ter o SDK do .NET 8.0 ou superior instalado em sua máquina.

1. Clone este repositório:

   ```bash
   git clone https://github.com/seu-usuario/minimal-api-dados-fakes.git

2. Navegue até o diretório do projeto

3. Execute a aplicação:
   
dotnet run

🧪 Tecnologias Utilizadas
- Bogus (para geração de dados falsos)
- Carter (para roteamento de endpoints)
- Entity Framework Core (para persistência de dados em memória)
- AspNetCoreRateLimit (para controle de taxa de requisições)

## 💡 Contribuição
Agradecemos a todos os contribuidores que ajudaram a tornar este projeto possível! ✨

Se você também deseja contribuir, por favor, veja as [diretrizes de contribuição](CONTRIBUTING.md).
