using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Web;

namespace Mvc.Models
{
    public class ladoCliente
    {

        private string url="http://localhost:6847/api/";

        public List<cliente> listarcliente() {

            try {

                HttpClient cli = new HttpClient();
                cli.BaseAddress = new Uri(url);
                cli.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mes = cli.GetAsync("Getcliente").Result;
                if (mes.IsSuccessStatusCode)
                    return mes.Content.ReadAsAsync<List<cliente>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public cliente listarclientexuno(int id)
        {

            try
            {

                HttpClient cli = new HttpClient();
                cli.BaseAddress = new Uri(url);
                cli.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mes = cli.GetAsync("clientes/"+id).Result;
                if (mes.IsSuccessStatusCode)
                    return mes.Content.ReadAsAsync<cliente>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public List<departamento> listardepartamento()
        {

            try
            {

                HttpClient cli = new HttpClient();
                cli.BaseAddress = new Uri(url);
                cli.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mes = cli.GetAsync("GetDepartamento").Result;
                if (mes.IsSuccessStatusCode)
                    return mes.Content.ReadAsAsync<List<departamento>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool agregar(cliente cliente)
        {

            try
            {

                HttpClient cli = new HttpClient();
                cli.BaseAddress = new Uri(url);
                cli.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mes = cli.PostAsJsonAsync("clientes",cliente).Result;
               
                    return mes.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool modificar(cliente cliente)
        {

            try
            {

                HttpClient cli = new HttpClient();
                cli.BaseAddress = new Uri(url);
                cli.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mes = cli.PutAsJsonAsync("clientes/"+cliente.id_cliente, cliente).Result;

                return mes.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool eliminar(int id)
        {

            try
            {

                HttpClient cli = new HttpClient();
                cli.BaseAddress = new Uri(url);
                cli.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage mes = cli.DeleteAsync("clientes/" + id).Result;

                return mes.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}