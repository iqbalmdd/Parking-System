public class PlateNumber
{
    private string townId {get;set;}
    private int numberPlate {get;set;}
    private string subTownId {get;set;}

    public PlateNumber(string townId, int numberPlate, string subTownId){
        this.townId = townId;
        this.numberPlate = numberPlate;
        this.subTownId = subTownId;
    }

    public override string ToString()
    {
        return $"{townId}-{numberPlate:D4}-{subTownId}";
    }

}