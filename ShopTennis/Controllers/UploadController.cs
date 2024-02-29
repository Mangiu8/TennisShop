using ShopTennis.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ShopTennis.Controllers
{
    public class UploadController : Controller
    {
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Prodotti prodotto, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Scarpe"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    if (file1 != null && file1.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file1.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Content/img/"), _FileName);
                        file1.SaveAs(_path);
                        prodotto.FilePath1 = _path;
                    }
                    if (file2 != null && file2.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file2.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Content/img/"), _FileName);
                        file2.SaveAs(_path);
                        prodotto.FilePath2 = _path;
                    }
                    if (file3 != null && file3.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file3.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Content/img/"), _FileName);
                        file3.SaveAs(_path);
                        prodotto.FilePath3 = _path;
                    }

                    string query = "INSERT INTO ScarpeTennis (Nome, Descrizione, Prezzo, Immagine, Immagine2, Immagine3, Disponibile)" +
                        "VALUES (@Nome, @Descrizione, @Prezzo, @Immagine, @Immagine2, @Immagine3, @Disponibile)";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Nome", prodotto.Nome);
                    cmd.Parameters.AddWithValue("@Descrizione", prodotto.Descrizione);
                    cmd.Parameters.AddWithValue("@Prezzo", prodotto.Prezzo);
                    cmd.Parameters.AddWithValue("@Immagine", prodotto.FilePath1);
                    cmd.Parameters.AddWithValue("@Immagine2", prodotto.FilePath2);
                    cmd.Parameters.AddWithValue("@Immagine3", prodotto.FilePath3);
                    cmd.Parameters.AddWithValue("@Disponibile", prodotto.Disponibile);

                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }
    }
}