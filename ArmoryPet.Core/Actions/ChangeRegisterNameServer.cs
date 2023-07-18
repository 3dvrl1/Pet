namespace ArmoryPet.Core.Actions;

public class ChangeRegisterNameServer
{

    public Tuple<string, string> Convert(string characterName, string serverName)
    {
        if (!string.IsNullOrEmpty(characterName) && !string.IsNullOrEmpty(serverName))
        {
            characterName = characterName.ToLower();
            serverName = serverName.ToLower();
            return Tuple.Create((characterName[0]).ToString().ToUpper() + characterName.Substring(1), (serverName[0]).ToString().ToUpper() + serverName.Substring(1));
        }
        else
        {
            return Tuple.Create(characterName, serverName);
        }
        
    }
}