namespace LABA2
{
  class Room
  {
    //private readonly Random Rnd = new Random();

    public string Id { get => _id; }
    private readonly string _id;

    public List<Instrument> _instrumentsList;
    public List<Worker> _employeesList;

   
    public Room()
    {
      _instrumentsList = new List<Instrument>();
      _employeesList = new List<Worker>();
    }
    public Room(string id)
    {
      _id = id;
      _instrumentsList = new List<Instrument>();
      _employeesList = new List<Worker>();
    }
    public Room(IEnumerable<Instrument> instruments)
    {
      _instrumentsList = new List<Instrument>();
      foreach (Instrument instrument in instruments)
      {
        _instrumentsList.Add(instrument);
      }

      _employeesList = new List<Worker>();
      _id = Guid.NewGuid().ToString();
    }
  }
}
