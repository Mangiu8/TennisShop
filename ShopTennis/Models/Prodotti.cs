namespace ShopTennis.Models
{
    public class Prodotti
    {
        public int IdProdotto { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public decimal Prezzo { get; set; }
        public string Immagine { get; set; }
        public string Immagine2 { get; set; }
        public string Immagine3 { get; set; }
        public bool Disponibile { get; set; }
    }
}