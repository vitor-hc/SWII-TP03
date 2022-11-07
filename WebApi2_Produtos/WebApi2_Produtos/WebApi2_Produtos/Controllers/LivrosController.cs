using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2_Produtos.Models;

namespace WebApi2_Produtos.Controllers
{
    public class LivrosController : ApiController
    {
        static readonly IProdutoRepositorio repositorio = new ProdutoRepositorio();

        public IEnumerable<Produto> GetAllLivros()
        {
            return repositorio.GetAll();
        }

        public Produto GetProduto(int id)
        {
            Produto item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Produto> GetProdutosPorCategoria(string subtitulo)
        {
            return repositorio.GetAll().Where(
                p => string.Equals(p.Subtitulo, subtitulo, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostProduto(Produto item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<Produto>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutProduto(int id, Produto produto)
        {
            produto.Id = id;
            if (!repositorio.Update(produto))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteProduto(int id)
        {
            Produto item = repositorio.Get(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repositorio.Remove(id);
        }
    }
}
