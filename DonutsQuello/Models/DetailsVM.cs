namespace DonutsQuello.Models;

public class DetailsVM
{
    public Donuts Anterior { get; set; }
    public Donuts Atual { get; set; }
    public Donuts Proximo { get; set; }
    public List<Tipo> Tipos { get; set; }

}