using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArmoryPet.Core.Models;

public class Character
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Realm { get; set; }
    public int Level { get; set; }
    public string Faction { get; set; }
    public string Gender { get; set; }
    public string Race { get; set; }
    public string Class { get; set; }
    public int HonorableKills { get; set; }
    public string Guild { get; set; }
    public int AchievementPoints { get; set; }
    
    public string[] PvpTeams { get; set; }
    //public Profession Professions { get; set; }
    
    


}