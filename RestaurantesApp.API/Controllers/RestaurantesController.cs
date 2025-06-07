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
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
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
                new CardapioDto { Nome = "Pizza Margherita", Descricao = "Molho de tomate, mussarela e manjericão", Preco = 39.90m, Imagem = "/images/cardapio/pizza_margherita.jpg" },
                new CardapioDto { Nome = "Pizza Pepperoni", Descricao = "Molho de tomate, mussarela e pepperoni", Preco = 44.90m, Imagem = "/images/cardapio/pizza_pepperoni.jpg" },
                new CardapioDto { Nome = "Pizza Quatro Queijos", Descricao = "Mussarela, parmesão, provolone e gorgonzola", Preco = 46.90m, Imagem = "/images/cardapio/pizza_4queijos.jpg" },
                new CardapioDto { Nome = "Pizza Portuguesa", Descricao = "Presunto, ovos, cebola, azeitona e mussarela", Preco = 45.00m, Imagem = "/images/cardapio/pizza_portuguesa.jpg" },
                new CardapioDto { Nome = "Pizza Calabresa", Descricao = "Calabresa fatiada, cebola e mussarela", Preco = 42.00m, Imagem = "/images/cardapio/pizza_calabresa.jpg" },
                new CardapioDto { Nome = "Pizza Vegetariana", Descricao = "Abobrinha, berinjela, tomate cereja e rúcula", Preco = 43.90m, Imagem = "/images/cardapio/pizza_veg.jpg" }
            }
        },
        {
            Guid.Parse("70D30D46-CB23-455B-A2E2-101B77F29A46"), // Sushi Now
            new List<CardapioDto>
            {
                new CardapioDto { Nome = "Combo Sushi 20 peças", Descricao = "Combinado com 20 unidades variadas", Preco = 59.90m, Imagem = "/images/cardapio/combo_sushi.jpg" },
                new CardapioDto { Nome = "Temaki de Salmão", Descricao = "Temaki com salmão fresco e cream cheese", Preco = 24.90m, Imagem = "/images/cardapio/temaki_salmao.jpg" },
                new CardapioDto { Nome = "Hot Roll", Descricao = "Sushi empanado com recheio de salmão e cream cheese", Preco = 19.90m, Imagem = "/images/cardapio/hotroll.jpg" },
                new CardapioDto { Nome = "Sashimi Salmão 8 un", Descricao = "Fatias de salmão fresco", Preco = 28.00m, Imagem = "/images/cardapio/sashimi_salmao.jpg" },
                new CardapioDto { Nome = "Yakissoba Tradicional", Descricao = "Macarrão oriental com legumes e carne", Preco = 32.90m, Imagem = "/images/cardapio/yakissoba.jpg" },
                new CardapioDto { Nome = "Uramaki Califórnia", Descricao = "Arroz, manga, pepino e kani", Preco = 21.90m, Imagem = "/images/cardapio/uramaki_california.jpg" }
            }
        },
        {
            Guid.Parse("29F77ACE-6DCF-4665-9D5F-F206F8323923"), // Burger Town
            new List<CardapioDto>
            {
                new CardapioDto { Nome = "Smash Burger Clássico", Descricao = "Hambúrguer com queijo, alface, tomate e molho da casa", Preco = 29.90m, Imagem = "/images/cardapio/smash_burger.jpg" },
                new CardapioDto { Nome = "Cheddar Bacon", Descricao = "Burger com cheddar derretido e bacon crocante", Preco = 34.90m, Imagem = "/images/cardapio/cheddar_bacon.jpg" },
                new CardapioDto { Nome = "Veggie Burger", Descricao = "Burger vegetal com cogumelos e abacate", Preco = 32.00m, Imagem = "/images/cardapio/veggie_burger.jpg" },
                new CardapioDto { Nome = "Batata Rústica", Descricao = "Batatas rústicas com ervas finas", Preco = 14.90m, Imagem = "/images/cardapio/batata_rustica.jpg" },
                new CardapioDto { Nome = "Onion Rings", Descricao = "Anéis de cebola empanados", Preco = 12.90m, Imagem = "/images/cardapio/onion_rings.jpg" },
                new CardapioDto { Nome = "Milkshake Chocolate", Descricao = "Milkshake cremoso de chocolate belga", Preco = 18.90m, Imagem = "/images/cardapio/milkshake.jpg" }
            }
        },
                {
    Guid.Parse("8CDE68CF-0232-4FDD-963A-BD85F8AE2E62"), // Viva Fit
    new List<CardapioDto>
    {
        new CardapioDto { Nome = "Salada Tropical", Descricao = "Folhas verdes, frango grelhado, manga e nozes", Preco = 26.90m, Imagem = "/images/cardapio/salada_tropical.jpg" },
        new CardapioDto { Nome = "Quinoa Bowl", Descricao = "Quinoa, grão de bico, abobrinha e cenoura", Preco = 28.50m, Imagem = "/images/cardapio/quinoa_bowl.jpg" },
        new CardapioDto { Nome = "Frango Grelhado Light", Descricao = "Filé de frango com legumes cozidos", Preco = 29.90m, Imagem = "/images/cardapio/frango_grelhado.jpg" },
        new CardapioDto { Nome = "Wrap de Atum", Descricao = "Atum, alface, cenoura e molho leve", Preco = 22.00m, Imagem = "/images/cardapio/wrap_atum.jpg" },
        new CardapioDto { Nome = "Suco Detox Verde", Descricao = "Couve, maçã, limão e gengibre", Preco = 9.90m, Imagem = "/images/cardapio/suco_verde.jpg" },
        new CardapioDto { Nome = "Iogurte com Granola", Descricao = "Iogurte natural com granola e mel", Preco = 11.50m, Imagem = "/images/cardapio/iogurte_granola.jpg" }
    }
},
{
    Guid.Parse("470606CC-1088-4AC0-877D-19E46BF402B4"), // La Pasta
    new List<CardapioDto>
    {
        new CardapioDto { Nome = "Spaghetti à Bolonhesa", Descricao = "Massa artesanal com molho de carne e tomate", Preco = 34.90m, Imagem = "/images/cardapio/spaghetti_bolonhesa.jpg" },
        new CardapioDto { Nome = "Lasanha Quatro Queijos", Descricao = "Lasanha cremosa com blend de queijos", Preco = 38.00m, Imagem = "/images/cardapio/lasanha_queijos.jpg" },
        new CardapioDto { Nome = "Fettuccine Alfredo", Descricao = "Molho branco com frango grelhado", Preco = 35.90m, Imagem = "/images/cardapio/fettuccine_alfredo.jpg" },
        new CardapioDto { Nome = "Ravioli de Ricota", Descricao = "Recheio de ricota e espinafre ao molho pesto", Preco = 37.00m, Imagem = "/images/cardapio/ravioli.jpg" },
        new CardapioDto { Nome = "Bruschetta Clássica", Descricao = "Pão italiano com tomate, manjericão e azeite", Preco = 16.90m, Imagem = "/images/cardapio/bruschetta.jpg" },
        new CardapioDto { Nome = "Tiramisu", Descricao = "Sobremesa italiana com café e creme mascarpone", Preco = 18.90m, Imagem = "/images/cardapio/tiramisu.jpg" }
    }
},
{
    Guid.Parse("1F4E38AC-CBC2-4F80-85A0-B53B99D494D3"), // Padoca da Vila
    new List<CardapioDto>
    {
        new CardapioDto { Nome = "Pão de Queijo", Descricao = "Tradicional pão de queijo mineiro", Preco = 5.00m, Imagem = "/images/cardapio/paodequeijo.jpg" },
        new CardapioDto { Nome = "Café com Leite", Descricao = "Café cremoso com leite quente", Preco = 6.50m, Imagem = "/images/cardapio/cafecomleite.jpg" },
        new CardapioDto { Nome = "Bolo de Cenoura", Descricao = "Fatia de bolo de cenoura com cobertura de chocolate", Preco = 7.90m, Imagem = "/images/cardapio/bolo_cenoura.jpg" },
        new CardapioDto { Nome = "Croissant de Presunto e Queijo", Descricao = "Massa folhada recheada com presunto e queijo", Preco = 9.90m, Imagem = "/images/cardapio/croissant.jpg" },
        new CardapioDto { Nome = "Torrada Petrópolis", Descricao = "Torrada artesanal com manteiga", Preco = 8.00m, Imagem = "/images/cardapio/torrada.jpg" },
        new CardapioDto { Nome = "Suco Natural de Laranja", Descricao = "Suco espremido na hora", Preco = 6.90m, Imagem = "/images/cardapio/suco_laranja.jpg" }
    }
}

    };

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
