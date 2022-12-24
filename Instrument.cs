namespace LABA2
{
  class Instrument
  {
    private readonly Random _rnd = new Random();
    public string Id { 
            get => _id; 
        }
    private readonly string _id;
    public InstrumentsTypes InstrumentClass { get => _instrumentClass; }
    private readonly InstrumentsTypes _instrumentClass;
    public int Price { get => _price; }
    private readonly int _price;
    public Instrument(InstrumentsTypes insClass)
    {
      _instrumentClass = insClass;
      _id = Guid.NewGuid().ToString();
      _price = _rnd.Next(100, 10000);
    }
    public Instrument(string id, InstrumentsTypes insClass, int price)
    {
      _id = id;
      _price = price;
      _instrumentClass = insClass;
      _id = Guid.NewGuid().ToString();
      _price = _rnd.Next(100, 10000);
    }
  }
}
