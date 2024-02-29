using ShopTennis.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace ShopTennis.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Scarpe"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(connectionString);
            List<Prodotti> prodotti = new List<Prodotti>();
            try
            {
                con.Open();
                string query = "SELECT * FROM ScarpeTennis";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Prodotti prodotto = new Prodotti();
                    prodotto.IdProdotto = reader.GetInt32(0);
                    prodotto.Nome = reader.GetString(1);
                    prodotto.Descrizione = reader.GetString(2);
                    prodotto.Prezzo = reader.GetDecimal(3);
                    prodotto.Immagine = reader.GetString(4);
                    prodotto.Disponibile = reader.GetBoolean(7);
                    prodotti.Add(prodotto);
                }
            }
            catch (SqlException ex)
            {
                ViewBag.Message = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return View(prodotti);
        }

        [HttpGet]
        public ActionResult Dettagli(int? id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Scarpe"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(connectionString);
            Prodotti prodotto = new Prodotti();
            try
            {
                con.Open();
                string query = "SELECT * FROM ScarpeTennis WHERE IdProdotto = " + id;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    prodotto.IdProdotto = reader.GetInt32(0);
                    prodotto.Nome = reader.GetString(1);
                    prodotto.Descrizione = reader.GetString(2);
                    prodotto.Prezzo = reader.GetDecimal(3);
                    prodotto.Immagine = reader.GetString(4);
                    prodotto.Immagine2 = reader.GetString(5);
                    prodotto.Immagine3 = reader.GetString(6);
                    prodotto.Disponibile = reader.GetBoolean(7);
                }
            }
            catch (SqlException ex)
            {
                ViewBag.Message = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return View(prodotto);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Scarpe"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(connectionString);
            Prodotti prodotto = new Prodotti();
            try
            {
                con.Open();
                string query = "SELECT * FROM ScarpeTennis WHERE IdProdotto = " + id;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    prodotto.IdProdotto = reader.GetInt32(0);
                    prodotto.Nome = reader.GetString(1);
                    prodotto.Descrizione = reader.GetString(2);
                    prodotto.Prezzo = reader.GetDecimal(3);
                    prodotto.Immagine = reader.GetString(4);
                    prodotto.Immagine2 = reader.GetString(5);
                    prodotto.Immagine3 = reader.GetString(6);
                    prodotto.Disponibile = reader.GetBoolean(7);
                }
            }
            catch (SqlException ex)
            {
                ViewBag.Message = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return View(prodotto);
        }
        [HttpPost]
        public ActionResult Edit(Prodotti prodotto)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Scarpe"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                string query = "UPDATE ScarpeTennis SET Nome = @Nome, Descrizione = @Descrizione, Prezzo = @Prezzo, Immagine = @Immagine, Immagine2 = @Immagine2, Immagine3 = @Immagine3, Disponibile = @Disponibile WHERE IdProdotto = @IdProdotto";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdProdotto", prodotto.IdProdotto);
                cmd.Parameters.AddWithValue("@Nome", prodotto.Nome);
                cmd.Parameters.AddWithValue("@Descrizione", prodotto.Descrizione);
                cmd.Parameters.AddWithValue("@Prezzo", prodotto.Prezzo);
                cmd.Parameters.AddWithValue("@Immagine", prodotto.Immagine);
                cmd.Parameters.AddWithValue("@Immagine2", prodotto.Immagine2);
                cmd.Parameters.AddWithValue("@Immagine3", prodotto.Immagine3);
                cmd.Parameters.AddWithValue("@Disponibile", prodotto.Disponibile);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ViewBag.Message = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Prodotti prodotto)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Scarpe"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                string query = "INSERT INTO ScarpeTennis (Nome, Descrizione, Prezzo, Immagine, Immagine2, Immagine3, Disponibile) VALUES (@Nome, @Descrizione, @Prezzo, @Immagine, @Immagine2, @Immagine3, @Disponibile)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", prodotto.Nome);
                cmd.Parameters.AddWithValue("@Descrizione", prodotto.Descrizione);
                cmd.Parameters.AddWithValue("@Prezzo", prodotto.Prezzo);
                cmd.Parameters.AddWithValue("@Immagine", prodotto.Immagine);
                cmd.Parameters.AddWithValue("@Immagine2", prodotto.Immagine2);
                cmd.Parameters.AddWithValue("@Immagine3", prodotto.Immagine3);
                cmd.Parameters.AddWithValue("@Disponibile", prodotto.Disponibile);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ViewBag.Message = ex.Message;
            }
            finally
            {
                con.Close();
            }

            return RedirectToAction("Index");
        }

        //public ActionResult Delete(int? id)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["Scarpe"].ToString();
        //    SqlConnection conn = new SqlConnection(connectionString);

        //    try
        //    {
        //        conn.Open();
        //        string query = "UPDATE ScarpeTennis SET IsVisible = 0 WHERE IDProdotto = " + id;
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}