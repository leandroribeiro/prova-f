using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using ProvaF.API.ViewModels;
using Xunit;

namespace ProvaF.API.Tests.IntegrationTests
{
    public class ContasTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public ContasTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }
        
        [Fact]
        public async Task Dado_uma_ContaValida_Quando_ConsultarSaldo_Entao_deve_retornar_o_saldo_atual()
        {
            // Arrange
            var numero = 1;
            var request = $"/contas/{numero}/saldo";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();

            var saldo = JsonConvert.DeserializeObject<decimal>(jsonFromPostResponse);

            saldo.Should().BeGreaterThan(0);
        }
        
        [Fact]
        public async Task Dado_uma_ContaValida_e_ValorValido_Quando_EfetuarSaque_Entao_Deve_Diminuir_Valor_da_Conta()
        {
            // Arrange
            var numero = 2;
            var request = new
            {
                Url = $"/contas/{numero}/sacar",
                Body = new
                {
                    Valor = 25.00m,
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            
            var sacar = JsonConvert.DeserializeObject<SacarResponse>(value);
            
            sacar.Conta.Should().Be(numero);
            sacar.Saldo.Should().Be(175);
        }
        
        [Fact]
        public async Task Dado_uma_ContaValida_e_ValorValido_Quando_EfetuarDeposito_Entao_deve_Aumentar_Saldo()
        {
            // Arrange
            var numero = 3;
            var request = new
            {
                Url = $"/contas/{numero}/depositar",
                Body = new
                {
                    Valor = 25.00m,
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            
            var sacar = JsonConvert.DeserializeObject<SacarResponse>(value);
            
            sacar.Conta.Should().Be(numero);
            sacar.Saldo.Should().Be(325);
        }
        
    }
}