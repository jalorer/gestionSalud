using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.Linq;
using System.Web;

namespace Sistema_Gestion_Salud.Negocio
{
    public class ConsultaAD
    {
        private DirectoryEntry entry;
        private DirectorySearcher dSearch;
        AppSettingsReader conf = new AppSettingsReader();

        public ConsultaAD()
        {
            string dominio = conf.GetValue("LDAP", System.Type.GetType("System.String")).ToString();
            //CAMBIAR PARAMETRO A WEB.CONFIG O XML
            entry = new DirectoryEntry(dominio);
            dSearch = new DirectorySearcher(entry);
        }

        //OBTENER LOS USUARIOS QUE CONTENGAN "BUSCADO"
        public IList<string> buscarUsuarios(string buscado)
        {
            try
            {
                //   dSearch.Filter = "(CN=*" + buscado + "*)";
                dSearch.Filter = "(CN=" + buscado + "*)";
                dSearch.PropertiesToLoad.Add("cn");

                SearchResultCollection collection = dSearch.FindAll();

                IList<string> lista = new List<string>();
                foreach (SearchResult sr in collection)
                    lista.Add(GetProperty(sr, "cn"));

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<string> buscarID(string buscado)
        {
            try
            {
                //   dSearch.Filter = "(CN=*" + buscado + "*)";
                dSearch.Filter = "(CN=" + buscado + ")";
                dSearch.PropertiesToLoad.Add("SAMAccountName");
                dSearch.PropertiesToLoad.Add("mail");

                SearchResultCollection collection = dSearch.FindAll();

                IList<string> lista = new List<string>();
                foreach (SearchResult sr in collection)
                    lista.Add(GetProperty(sr, "SAMAccountName"));


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<string> buscarDatos(string buscado)
        {
            try
            {
                //   dSearch.Filter = "(CN=*" + buscado + "*)";
                dSearch.Filter = "(CN=" + buscado + ")";
                dSearch.PropertiesToLoad.Add("SAMAccountName");
                dSearch.PropertiesToLoad.Add("mail");
                dSearch.PropertiesToLoad.Add("telephoneNumber");
                dSearch.PropertiesToLoad.Add("mobile");
                dSearch.PropertiesToLoad.Add("department");
                dSearch.PropertiesToLoad.Add("title");



                SearchResultCollection collection = dSearch.FindAll();

                IList<string> lista = new List<string>();
                foreach (SearchResult sr in collection)
                {
                    lista.Add(GetProperty(sr, "SAMAccountName"));
                    lista.Add(GetProperty(sr, "mail"));
                    lista.Add(GetProperty(sr, "telephoneNumber"));
                    lista.Add(GetProperty(sr, "mobile"));
                    lista.Add(GetProperty(sr, "department"));
                    lista.Add(GetProperty(sr, "title"));



                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// se indica cuenta de dominio y devuelve nombre
        /// </summary>
        /// <param name="buscado"></param>
        /// <returns></returns>
        public IList<string> buscarUsuario(string buscado)
        {
            try
            {
                //   dSearch.Filter = "(CN=*" + buscado + "*)";
                dSearch.Filter = "(SAMAccountName=" + buscado + "*)";
                dSearch.PropertiesToLoad.Add("cn");

                SearchResultCollection collection = dSearch.FindAll();

                IList<string> lista = new List<string>();
                foreach (SearchResult sr in collection)
                    lista.Add(GetProperty(sr, "cn"));

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetProperty(SearchResult searchResult, string PropertyName)
        {
            if (searchResult.Properties.Contains(PropertyName))
            {
                return searchResult.Properties[PropertyName][0].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
