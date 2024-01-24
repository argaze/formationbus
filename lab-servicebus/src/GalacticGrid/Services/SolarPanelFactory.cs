using System.Collections.Generic;
using System.Linq;

namespace GalacticGrid.Service;

public class SolarPanelFactory : ISolarPanelFactory
{
    private readonly Random random = new Random();
    private readonly string[] models = { "SunHarvester 3000", "PhotonCatcher X", "RadiantReaper Pro", "LuminaryLifter Z", "SolsticeSaver Ultra" };
    private readonly int[] capacities = { 100, 200, 300 };
    private readonly string manufacturers = "GalacticGrid";
    private List<string> unusedModels;
    private List<string> usedModels;

    public SolarPanelFactory()
    {
        unusedModels = models.ToList();
        usedModels = new List<string>();
    }

    public SolarPanel GenerateSolarPanel()
    {
        if (!unusedModels.Any())
        {
            unusedModels = usedModels;
            usedModels = new List<string>();
        }

        var modelIndex = random.Next(unusedModels.Count);
        var model = unusedModels[modelIndex];
        unusedModels.RemoveAt(modelIndex);
        usedModels.Add(model);

        SolarPanel solarPanel = new SolarPanel
        {
            Model = model,
            Capacity = capacities[random.Next(capacities.Length)],
            Manufacturer = manufacturers
        };

        return solarPanel;
    }
}