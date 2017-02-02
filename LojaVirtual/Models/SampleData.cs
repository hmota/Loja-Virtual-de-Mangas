using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LojaVirtual.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<LojaVirtualEntities>
    {
        protected override void Seed(LojaVirtualEntities context)
        {
            var generos = new List<Genero>
            {
                new Genero { Nome = "Açao" },
                new Genero { Nome = "Artes Marciais" },
                new Genero { Nome = "Aventura" },
                new Genero { Nome = "Comédia" },
                new Genero { Nome = "Drama" },
                new Genero { Nome = "Ficção" },
                new Genero { Nome = "Terror" },
                new Genero { Nome = "Mecha" },
                new Genero { Nome = "Psicologico" },
                new Genero { Nome = "Esporte" },
                new Genero { Nome = "Seinen" },
                new Genero { Nome = "Shōjo" },
                new Genero { Nome = "Shōnen" },
                new Genero { Nome = "Kodomo" }
            };

            var autores = new List<Autor>
            {
                new Autor { Nome = "Eiichiro Oda" },
                new Autor { Nome = "Takao Saito" },
                new Autor { Nome = "Akira Toriyama" },
                new Autor { Nome = "Masashi Kishimoto" },
                new Autor { Nome = "Osamu Tezuka" },
                new Autor { Nome = "Osamu Akimoto" },
                new Autor { Nome = "Gosho Aoyama"  },
                new Autor { Nome = "Tetsu Kariya " },
                new Autor { Nome = "Takehiko Inoue"  },
                new Autor { Nome = "Fujiko Fujio" },
                new Autor { Nome = "Buronson" },
                new Autor { Nome = "Mitsuru Adachi" },
            };

            new List<Manga>
            {
                new Manga { Titulo = "One Piece", Genero = generos.Single(g => g.Nome == "Shōnen"), Preco = 8.2M, Autor = autores.Single(a => a.Nome == "Eiichiro Oda"), CapaMangaUrl = "https://pt.wikipedia.org/wiki/Ficheiro:One_Piece_vol._01.jpg" },
                new Manga { Titulo = "Golgo 13", Genero = generos.Single(g => g.Nome == "Seinen"), Preco = 17.7M, Autor = autores.Single(a => a.Nome == "Takao Saito"), CapaMangaUrl = "http://img1.ak.crunchyroll.com/i/spire1/f8deb672c1dbc33c0bb432323e35ced11451914181_full.jpg" },
                new Manga { Titulo = "Dragon Ball", Genero = generos.Single(g => g.Nome == "Shōnen"), Preco = 4.2M, Autor = autores.Single(a => a.Nome == "Akira Toriyama"), CapaMangaUrl = "http://leitorcabuloso.com.br/wp-content/uploads/2012/08/dball01_capinha.jpg" },
                new Manga { Titulo = "Naruto", Genero = generos.Single(g => g.Nome == "Shōnen"), Preco = 7.2M, Autor = autores.Single(a => a.Nome == "Masashi Kishimoto"), CapaMangaUrl = "https://pt.wikipedia.org/wiki/Naruto#/media/File:Naruto_vol._01.jpg" },
                new Manga { Titulo = "Black Jack", Genero = generos.Single(g => g.Nome == "Shōnen"), Preco = 1.7M, Autor = autores.Single(a => a.Nome == "Osamu Tezuka"), CapaMangaUrl = "http://img1.ak.crunchyroll.com/i/spire1/5c9a1380bd7066bb9f66b1ef69ec3e791430414827_full.jpg" },
                new Manga { Titulo = "KochiKame ", Genero = generos.Single(g => g.Nome == "Shōnen"), Preco = 20.0M, Autor = autores.Single(a => a.Nome == "Osamu Akimoto"), CapaMangaUrl = "http://img1.ak.crunchyroll.com/i/spire3/07acd170753a8e8f6747814fcfe0ca591474518123_full.jpg" },
                new Manga { Titulo = "Case Closed", Genero = generos.Single(g => g.Nome == "Shōnen"), Preco = 8.9M, Autor = autores.Single(a => a.Nome == "Gosho Aoyama"), CapaMangaUrl = "http://www.detectiveconanworld.com/wiki/images/thumb/b/b1/Volume_1.jpg/200px-Volume_1.jpg" },
                new Manga { Titulo = "Oishinbo", Genero = generos.Single(g => g.Nome == "Seinen"), Preco = 11.1M, Autor = autores.Single(a => a.Nome == "Tetsu Kariya "), CapaMangaUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/1/1a/Oishinbo.jpg/200px-Oishinbo.jpg" },
                new Manga { Titulo = "Slam Dunk", Genero = generos.Single(g => g.Nome == "Shōnen"), Preco = 3.1M, Autor = autores.Single(a => a.Nome == "Takehiko Inoue"), CapaMangaUrl = "https://bibliotecabrasileirademangas.files.wordpress.com/2015/10/slam-dunk-01.jpg" },
                new Manga { Titulo = "Astro Boy", Genero = generos.Single(g => g.Nome == "Shōnen"), Preco = 2.3M, Autor = autores.Single(a => a.Nome == "Osamu Tezuka"), CapaMangaUrl = "http://www.rightstufanime.com/images/productImages/9781616558604_books-Astro-Boy-GN-Omnibus-01.jpg" },
                new Manga { Titulo = "Doraemon", Genero = generos.Single(g => g.Nome == "Kodomo"), Preco = 4.5M, Autor = autores.Single(a => a.Nome == "Fujiko Fujio"), CapaMangaUrl = "http://images.gr-assets.com/books/1182703676l/1315744.jpg" },
                new Manga { Titulo = "Hokuto no Ken", Genero = generos.Single(g => g.Nome == "Shōnen"), Preco = 2.7M, Autor = autores.Single(a => a.Nome == "Buronson"), CapaMangaUrl = "https://upload.wikimedia.org/wikipedia/en/9/92/Hokuto_no_Ken_tankobon.jpg" },
                new Manga { Titulo = "Touch", Genero = generos.Single(g => g.Nome == "Shōnen"), Preco = 2.6M, Autor = autores.Single(a => a.Nome == "Mitsuru Adachi"), CapaMangaUrl = "https://en.wikipedia.org/wiki/Touch_(manga)#/media/File:Touch-vol14-AdachiMitsuru.jpg" }
            }.ForEach(m => context.Mangas.Add(m));
            

            context.SaveChanges();
        }
    }
}