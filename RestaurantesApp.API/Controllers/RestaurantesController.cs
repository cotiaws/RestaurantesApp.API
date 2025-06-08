using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<RestaurantesDto>), 200)]
        public ActionResult<IEnumerable<RestaurantesDto>> Get()
        {
            var restaurantes = RestaurantesService.GetRestaurantes();
            return Ok(restaurantes);
        }

        [HttpGet("{id}/cardapio")]
        [ProducesResponseType(typeof(List<CardapioDto>), 200)]
        public ActionResult<IEnumerable<CardapioDto>> GetCardapioPorRestaurante(Guid id)
        {
            var cardapio = RestaurantesService.GetCardapioPorRestaurante(id);
            return Ok(cardapio);
        }
    }

    public class RestaurantesDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string TempoDeEntrega { get; set; }
        public string Imagem { get; set; }
        public bool Aberto { get; set; }
        public DateTime DataInclusao { get; set; }
    }

    public class CardapioDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public Guid RestauranteId { get; set; }
    }

    public class RestaurantesService
    {

        public static List<CardapioDto> GetCardapioPorRestaurante(Guid restauranteId)
        {
            var cardapios = new Dictionary<Guid, List<CardapioDto>>
{
    {
        Guid.Parse("3D307FCE-4A2B-4886-A1D3-80C0056492A7"), // Pizza Hut
        new List<CardapioDto>
        {
            new CardapioDto { Id = Guid.Parse("A0D9A1A0-8D1F-42B2-B6C7-0A1F5E4E0F99"), Nome = "Pizza Margherita", Descricao = "Molho de tomate, mussarela e manjericão", Preco = 39.90m, RestauranteId = Guid.Parse("3D307FCE-4A2B-4886-A1D3-80C0056492A7") },
            new CardapioDto { Id = Guid.Parse("B1F2B2B1-9C2F-43C3-A7D8-1B2G6F5F1G00"), Nome = "Pizza Pepperoni", Descricao = "Molho de tomate, mussarela e pepperoni", Preco = 44.90m, RestauranteId = Guid.Parse("3D307FCE-4A2B-4886-A1D3-80C0056492A7") },
            new CardapioDto { Id = Guid.Parse("C2G3C3C2-AD3F-54D4-B8E9-2C3H7G6G2H11"), Nome = "Pizza Quatro Queijos", Descricao = "Mussarela, parmesão, provolone e gorgonzola", Preco = 46.90m, RestauranteId = Guid.Parse("3D307FCE-4A2B-4886-A1D3-80C0056492A7") },
            new CardapioDto { Id = Guid.Parse("D3H4D4D3-BE4F-65E5-C9F0-3D4I8H7H3I22"), Nome = "Pizza Portuguesa", Descricao = "Presunto, ovos, cebola, azeitona e mussarela", Preco = 45.00m, RestauranteId = Guid.Parse("3D307FCE-4A2B-4886-A1D3-80C0056492A7") },
            new CardapioDto { Id = Guid.Parse("E4I5E5E4-CF5F-76F6-D1G1-4E5J9I8I4J33"), Nome = "Pizza Calabresa", Descricao = "Calabresa fatiada, cebola e mussarela", Preco = 42.00m, RestauranteId = Guid.Parse("3D307FCE-4A2B-4886-A1D3-80C0056492A7") },
            new CardapioDto { Id = Guid.Parse("F5J6F6F5-DG6F-87G7-E2H2-5F6K0J9J5K44"), Nome = "Pizza Vegetariana", Descricao = "Abobrinha, berinjela, tomate cereja e rúcula", Preco = 43.90m, RestauranteId = Guid.Parse("3D307FCE-4A2B-4886-A1D3-80C0056492A7") }
        }
    },
    {
        Guid.Parse("70D30D46-CB23-455B-A2E2-101B77F29A46"), // Sushi Now
        new List<CardapioDto>
        {
            new CardapioDto { Id = Guid.Parse("8E2F3F27-1B45-4D45-9BB4-15C95E5A9876"), Nome = "Combo Sushi 20 peças", Descricao = "Combinado com 20 unidades variadas", Preco = 59.90m, RestauranteId = Guid.Parse("70D30D46-CB23-455B-A2E2-101B77F29A46") },
            new CardapioDto { Id = Guid.Parse("9F3G4G38-2C56-5E56-ACC5-26DA6F6B0987"), Nome = "Temaki de Salmão", Descricao = "Temaki com salmão fresco e cream cheese", Preco = 24.90m, RestauranteId = Guid.Parse("70D30D46-CB23-455B-A2E2-101B77F29A46") },
            new CardapioDto { Id = Guid.Parse("AF4H5H49-3D67-6F67-BDD6-37EB7G7C1098"), Nome = "Hot Roll", Descricao = "Sushi empanado com recheio de salmão e cream cheese", Preco = 19.90m, RestauranteId = Guid.Parse("70D30D46-CB23-455B-A2E2-101B77F29A46") },
            new CardapioDto { Id = Guid.Parse("BF5I6I50-4E78-7G78-CEE7-48FC8H8D2109"), Nome = "Sashimi Salmão 8 un", Descricao = "Fatias de salmão fresco", Preco = 28.00m, RestauranteId = Guid.Parse("70D30D46-CB23-455B-A2E2-101B77F29A46") },
            new CardapioDto { Id = Guid.Parse("CF6J7J61-5F89-8H89-DFF8-59GD9I9E3210"), Nome = "Yakissoba Tradicional", Descricao = "Macarrão oriental com legumes e carne", Preco = 32.90m, RestauranteId = Guid.Parse("70D30D46-CB23-455B-A2E2-101B77F29A46") },
            new CardapioDto { Id = Guid.Parse("DF7K8K72-6G90-9I90-EGG9-60HE0J0F4321"), Nome = "Uramaki Califórnia", Descricao = "Arroz, manga, pepino e kani", Preco = 21.90m, RestauranteId = Guid.Parse("70D30D46-CB23-455B-A2E2-101B77F29A46") }
        }
    },
    {
        Guid.Parse("1D95E3F5-AB59-40F4-B715-9B08C358ABC1"), // Burger Town
        new List<CardapioDto>
        {
            new CardapioDto { Id = Guid.Parse("F7B6A6E2-529D-43A1-98AB-B3E0B1A84211"), Nome = "Burger Clássico", Descricao = "Hambúrguer com queijo, alface, tomate e molho especial", Preco = 27.90m, RestauranteId = Guid.Parse("1D95E3F5-AB59-40F4-B715-9B08C358ABC1") },
            new CardapioDto { Id = Guid.Parse("A1C6D3F0-32E1-4B48-8206-0923ABEDFBA3"), Nome = "Cheddar Bacon", Descricao = "Hambúrguer com cheddar cremoso e bacon crocante", Preco = 32.00m, RestauranteId = Guid.Parse("1D95E3F5-AB59-40F4-B715-9B08C358ABC1") },
            new CardapioDto { Id = Guid.Parse("3AB76192-BD47-49F3-BF02-103D8675FEA4"), Nome = "Combo Burger + Fritas", Descricao = "Combo com hambúrguer e fritas médias", Preco = 38.00m, RestauranteId = Guid.Parse("1D95E3F5-AB59-40F4-B715-9B08C358ABC1") }
        }
    },
    {
        Guid.Parse("4E2062EF-8A57-4D63-B1A2-2CB6D9496140"), // Viva Fit
        new List<CardapioDto>
        {
            new CardapioDto { Id = Guid.Parse("6E1ACD90-B3A3-419F-A5CD-B913A9E1E033"), Nome = "Salada Viva", Descricao = "Mix de folhas, grão-de-bico, cenoura e molho leve", Preco = 22.90m, RestauranteId = Guid.Parse("4E2062EF-8A57-4D63-B1A2-2CB6D9496140") },
            new CardapioDto { Id = Guid.Parse("B7EC6E92-4D1E-4F9D-A79A-816A6B46F0AC"), Nome = "Suco Detox", Descricao = "Suco verde com couve, maçã e gengibre", Preco = 9.90m, RestauranteId = Guid.Parse("4E2062EF-8A57-4D63-B1A2-2CB6D9496140") },
            new CardapioDto { Id = Guid.Parse("C3A9393C-2B3B-4979-AB9A-9ACF2E3F6A41"), Nome = "Wrap de Frango", Descricao = "Frango grelhado, alface, tomate e molho iogurte", Preco = 19.90m, RestauranteId = Guid.Parse("4E2062EF-8A57-4D63-B1A2-2CB6D9496140") }
        }
    },
    {
        Guid.Parse("0C3D2BA0-1954-4A78-AE9C-C303FE13956A"), // La Pasta
        new List<CardapioDto>
        {
            new CardapioDto { Id = Guid.Parse("F7A6FCA2-2167-490B-87C6-24644C5E4567"), Nome = "Spaghetti Carbonara", Descricao = "Massa com molho de ovos, bacon e queijo parmesão", Preco = 36.00m, RestauranteId = Guid.Parse("0C3D2BA0-1954-4A78-AE9C-C303FE13956A") },
            new CardapioDto { Id = Guid.Parse("0D1B1F0A-FA4E-4F99-A3F3-7396B2BBE56F"), Nome = "Lasagna à Bolonhesa", Descricao = "Camadas de massa com carne moída e molho de tomate", Preco = 40.00m, RestauranteId = Guid.Parse("0C3D2BA0-1954-4A78-AE9C-C303FE13956A") },
            new CardapioDto { Id = Guid.Parse("1C2E390C-1F4A-4053-99D3-BDE4F96B2D2A"), Nome = "Ravioli de Ricota", Descricao = "Ravioli recheado com ricota e espinafre", Preco = 34.00m, RestauranteId = Guid.Parse("0C3D2BA0-1954-4A78-AE9C-C303FE13956A") }
        }
    } };


            return cardapios.ContainsKey(restauranteId)
                ? cardapios[restauranteId]
                : new List<CardapioDto>();
        }


        public static List<RestaurantesDto> GetRestaurantes() => new()
    {
        new RestaurantesDto
        {
            Id = Guid.Parse("3D307FCE-4A2B-4886-A1D3-80C0056492A7"),
            Nome = "Pizza Hut",
            Categoria = "Pizza • Massas artesanais e borda recheada",
            TempoDeEntrega = "30-40 min",
            Imagem = "/images/pizza.jpg",
            Aberto = true,
            DataInclusao = DateTime.Now
        },
        new RestaurantesDto
        {
            Id = Guid.Parse("70D30D46-CB23-455B-A2E2-101B77F29A46"),
            Nome = "Sushi Now",
            Categoria = "Comida Japonesa • Temakis, sushis e combinados frescos",
            TempoDeEntrega = "45-60 min",
            Imagem = "/images/sushi.jpg",
            Aberto = true
        },
        new RestaurantesDto
        {
            Id = Guid.Parse("29F77ACE-6DCF-4665-9D5F-F206F8323923"),
            Nome = "Burger Town",
            Categoria = "Hambúrguer Gourmet • Smash burgers e batatas crocantes",
            TempoDeEntrega = "25-35 min",
            Imagem = "/images/burger.jpg",
            Aberto = false
        },
        new RestaurantesDto
        {
            Id = Guid.Parse("8CDE68CF-0232-4FDD-963A-BD85F8AE2E62"),
            Nome = "Viva Fit",
            Categoria = "Comida Saudável • Saladas, grelhados e pratos leves",
            TempoDeEntrega = "20-30 min",
            Imagem = "/images/salada.jpg",
            Aberto = true
        },
        new RestaurantesDto
        {
            Id = Guid.Parse("470606CC-1088-4AC0-877D-19E46BF402B4"),
            Nome = "La Pasta",
            Categoria = "Italiana • Massas frescas e molhos caseiros",
            TempoDeEntrega = "30-45 min",
            Imagem = "/images/italian.jpg",
            Aberto = true
        },
        new RestaurantesDto
        {
            Id = Guid.Parse("1F4E38AC-CBC2-4F80-85A0-B53B99D494D3"),
            Nome = "Padoca da Vila",
            Categoria = "Padaria • Pães artesanais, cafés e bolos",
            TempoDeEntrega = "15-25 min",
            Imagem = "/images/padaria.jpg",
            Aberto = true
        },
    };
    }
}
