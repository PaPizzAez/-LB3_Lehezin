namespace LABA2
{
  class StudioGenerator : ICloneable
  {
    public List<Room> RoomsList { get => _roomsList; }
    private readonly List<Room> _roomsList = new List<Room>();

    public List<Instrument> InstrumentsList { get => _instrumentsList; }
    private readonly List<Instrument> _instrumentsList = new List<Instrument>();
    public const int InstrumentsPerRoom = 3;

    public Dictionary<string, Worker> WorkersList { get => _workersList; }
    private readonly Dictionary<string, Worker> _workersList = new Dictionary<string, Worker>();
        
    public string name { get => _name; set { _name = value; } }
    private string _name;
    public int money { get => _money; }
    private int _money;
    public string address { get => _address; }
    private string _address;
    public int people { get => _people; set { _people = value; } }
    private int _people;
    public int moneyForTrack { get => _moneyForTrack; }
    private int _moneyForTrack;
    public int timeForTraсk { get => _timeForTraсk; }
    private int _timeForTraсk;
    public int salaryForMonth { get => _salaryForMonth; }
    private int _salaryForMonth;
    public int allSalaryForMonth { get => _allSalaryForMonth; set { _allSalaryForMonth = value; } }
    private int _allSalaryForMonth;
    public int InstNum { get => _instNum; set { _instNum = value; } }
    private int _instNum;
    public int RoomsNum { get => _roomsNum; set { _roomsNum = value; } }
    private int _roomsNum;

    public const int instPerRoom = 2;
    public const int peoplePerRoom = 2;

    public StudioGenerator(string name, string address, int moneyForTrack, int timeForTraсk, int salaryForMonth)
    {
      _money = 99999999;
      _name = name;
      _address = address;
      _people = 10;
      _moneyForTrack = moneyForTrack;
      _timeForTraсk = timeForTraсk;
      _salaryForMonth = salaryForMonth;

      _allSalaryForMonth = _salaryForMonth * _people;
      _instNum = 10;
      _roomsNum = 5;
    }
    public StudioGenerator(string studioName, int studioMoneyBalance, string studioAdress,
      int cenaZaTraсk, int timeForTraсk, int emploeeMonthSalery, int allEmploeesMonthSalery,
      IEnumerable<Room> rooms, IEnumerable<Worker> employees, IEnumerable<Instrument> instruments)
    {
      _name = studioName;
      _money = studioMoneyBalance;
      _address = studioAdress;
      _moneyForTrack = cenaZaTraсk;
      _timeForTraсk = timeForTraсk;
      _salaryForMonth = emploeeMonthSalery;
      _allSalaryForMonth = allEmploeesMonthSalery;

      _roomsList.AddRange(rooms);
      _instrumentsList.AddRange(instruments);

      foreach (Worker employee in employees)
      {
        if (!_workersList.ContainsKey(employee.Id))
        {
          _workersList.Add(employee.Id, employee);
        }
      }
    }
    public static InstrumentsTypes GetRandomInstrumentalClass()
    {
      Array values = Enum.GetValues(typeof(InstrumentsTypes));
      Random random = new Random();
      InstrumentsTypes randomValue = (InstrumentsTypes)values.GetValue(random.Next(values.Length));

      return randomValue;
    }

    public int this[int i]
    {
      get
      {
        switch (i)
        {
          case 0: return _salaryForMonth;
          case 1: return _money;

          default: throw new ArgumentException("i");
        }
      }
    }
    public object Clone()
    {
      return new StudioGenerator(_name, _address, _moneyForTrack, _timeForTraсk, _salaryForMonth);
    }
    public void Hire()
    {
      Worker someWorker = new Worker("найняв робочего");
      _workersList.Add(someWorker.Id, someWorker);
    }
    public void Fire(string id)
    {
      if (_workersList.Count() - 1 < _roomsList.Count() * peoplePerRoom)
      {
        MessageBox.Show("Немає працівників " + _roomsList.Count() + " для кімнати");
        return;
      }

      _workersList.Remove(id);
    }
    public void Dismiss()
    {
      if (_people == 0)
      {
        MessageBox.Show("Немає працівників щоб їх звільнювати");
        return;
      }

      if (_people - 1 < _roomsNum * instPerRoom)
      {
        MessageBox.Show("Недостатньо працівників!");
        return;
      }

      _people--;
    }
    public void BuyInstrument()
    {
      Instrument rndInstument = new Instrument(GetRandomInstrumentalClass());
      _instrumentsList.Add(rndInstument);
    }
    public void DeleteInstrument()
    {
      if (_instrumentsList.Count() == 0) return;

      if (_instrumentsList.Count() - 1 < _roomsList.Count() * InstrumentsPerRoom)
      {
        MessageBox.Show("Недостатньо інструментів для обслуговування " + _roomsList.Count() + " кімнат! 2 інструмент = 1 кімната");
        return;
      }

      _instrumentsList.RemoveAt(0);
    }
    public void CreateNewRoom(IEnumerable<Instrument> instruments)
    {
      if (
        (
          _instrumentsList.Count() - _roomsList.Count() * InstrumentsPerRoom > 1 &&
          _workersList.Count() - _roomsList.Count() * peoplePerRoom > 1
        )
        || _roomsList.Count() == 0
      )
      {
        Room newRoom = new Room(instruments);
        _roomsList.Add(newRoom);

        _money -= 10000;
        MessageBox.Show("New room created!");
        return;
      }
      else
      {
        if (_instrumentsList.Count() - _roomsList.Count() * InstrumentsPerRoom <= 1)
        {
          MessageBox.Show("Неможливо збудувати кімнату, бо немає інструментів для неї!");
        }
        if (_workersList.Count() - _roomsList.Count() * peoplePerRoom <= 1)
        {
          MessageBox.Show("Неможливо збудувати кімнату, бо немає працівників для неї!");
        }
      }
    }
    public void DestroyRoom(string idToRemove)
    {
      if (_roomsList.Count() == 0)
      {
        MessageBox.Show("Немає кімнат!");
        return;
      }
      else
      {
        for (int i = 0; i <= _roomsList.Count(); i++)
        {
          if (_roomsList.ElementAt(i).Id.Equals(idToRemove))
          {
            _roomsList.RemoveAt(i);
            break;
          }
        }
      }
    }
    public void AddBalance(int moneyAmount)
    {
      _money += moneyAmount;
    }

    public Instrument? getInstrumentById(string id)
    {
      for (int i = 0; i <= _instrumentsList.Count; i++)
      {
        if (_instrumentsList.ElementAt(i).Id.Equals(id))
        {
          return _instrumentsList.ElementAt(i);
        }
      }

      return null;
    }
    public Worker? getWorkerById(string id)
    {
      if (_workersList.ContainsKey(id)) return _workersList[id];

      return null;
    }
  }
}
