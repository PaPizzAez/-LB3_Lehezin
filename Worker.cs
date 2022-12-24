namespace LABA2
{
  class Worker
  {
    readonly Random rnd = new Random();
    public string Id { get => _id; }
    private readonly string _id;
    public string Initials { get => _initials; }
    private readonly string _initials;
    public int Salary { get => _salary; }
    private readonly int _salary;
    public int TraksCount { get => _traksCount; }
    private readonly int _traksCount;

    public Worker(string initials)
    {
      _id = generateIdNumber();
      _initials = initials;
      _salary = rnd.Next(100, 10000);
      _traksCount = 0;
    }
    public Worker(string initials, int salery, int tc, string id)
    {
      _id = id;
      _salary = salery;
      _traksCount = tc;
      _initials = initials;
    }
    private string generateIdNumber()
    {
      string[] elements = new string[12];
      Random newRnd = new Random();

      for (int i = 0; i < 12; i++)
      {
        elements[i] = newRnd.Next(0, 9).ToString();
      }

      string number = String.Concat(
        elements[0], elements[1],
        elements[2], elements[3],
        elements[4], elements[5],
        elements[6], elements[7],
        elements[8], elements[9],
        elements[10], elements[11]
      );

      return number;
    }
  }
}
