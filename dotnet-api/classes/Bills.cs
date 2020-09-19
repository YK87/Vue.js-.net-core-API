public class Bills
{
    public int Id {get; set; }
    public int Year {get; set; }
    public int Month {get; set; }
    public int RegionId {get; set; }
    public string RegionName {get; set; }
    public int CompanyId {get; set; }
    public string CompanyName {get; set; }
    public string CodeMo {get; set; }
    public string MoName {get; set; }
    public decimal AccountSum {get; set; }
    public decimal AccountDeduction {get; set; }
}