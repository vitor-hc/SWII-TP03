using System;
using System.Collections.Generic;

namespace WebApi2_Produtos.Models
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private List<Produto> livros = new List<Produto>();
        private int _nextId = 1;

        public ProdutoRepositorio()
        {
            Add(new Produto { Titulo = "A Arte da Procrastinacao", Subtitulo = "Procrastinacao", Resumo = "Filosofia ", Autor = "John Perry" });
            Add(new Produto { Titulo = "It, a coisa", Subtitulo = "It", Resumo = "Terror", Autor = "Stephen King" });
            Add(new Produto { Titulo = "Carrie, a estranha", Subtitulo = "Carrie", Resumo = "Suspense", Autor = "Stephen King" });
            Add(new Produto { Titulo = "Sob a Redoma", Subtitulo = "Redoma", Resumo = "Suspense", Autor = "Stephen King" });
            Add(new Produto { Titulo = "Cemiterio Maldito", Subtitulo = "Cemiterio Maldito", Resumo = "Terror", Autor = "Stephen King" });
            Add(new Produto { Titulo = "A Escolha dos Tres - Torre Negra 2", Subtitulo = "Torre Negra 2", Resumo = "Fantasia sombria", Autor = "Stephen King" });
            Add(new Produto { Titulo = "O Pistoleiro - Torre Negra 1", Subtitulo = "Torre Negra 1", Resumo = "Fantasia sombria", Autor = "Stephen King" });
            Add(new Produto { Titulo = "Terras Devastadas - Torre Negra 3", Subtitulo = "Torre Negra 3", Resumo = "Fantasia sombria", Autor = "Stephen King" });
            Add(new Produto { Titulo = "O Mago e o Vidro - Torre Negra 4", Subtitulo = "Torre Negra 4", Resumo = "Fantasia sombria", Autor = "Stephen King" });
            Add(new Produto { Titulo = "Lobos de Calla - Torre Negra 5", Subtitulo = "Torre Negra 5", Resumo = "Fantasia sombria", Autor = "Stephen King" });
        }

        public Produto Add(Produto item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            livros.Add(item);
            return item;
        }

        public Produto Get(int id)
        {
            return livros.Find(p => p.Id == id);
        }

        public IEnumerable<Produto> GetAll()
        {
            return livros;
        }

        public void Remove(int id)
        {
            livros.RemoveAll(p => p.Id == id);
        }

        public bool Update(Produto item)
        {
            if( item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = livros.FindIndex(p => p.Id == item.Id);

            if(index == -1)
            {
                return false;
            }
            livros.RemoveAt(index);
            livros.Add(item);
            return true;
        }
    }
}