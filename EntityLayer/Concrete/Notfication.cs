using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class Notfication
{
    [Key]
    public int NotficationId { get; set; }
    public string NotficationType { get; set; }
    public string NotficationTypeSymbol { get; set; }
    public string NotficationDetails { get; set; }
    public DateTime NotficationDate { get; set; }
    public bool NotficationStatus { get; set; }
    public string NotficationColor { get; set; }
}