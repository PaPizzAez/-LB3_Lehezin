using System;
using System.Text;

namespace LABA2
{
  public partial class Screen : Form
  {
    private List<StudioGenerator> _list = new List<StudioGenerator>();

    public Screen()
    {
      InitializeComponent();
    }

    private void СreateStudio_Click(object sender, EventArgs e)
    {
      string name = textBox1.Text;
      string address = textBox2.Text;

      string moneyForTrack = textBox4.Text;
      string timeForTraсk = textBox5.Text;
      string salaryForMonth = textBox6.Text;

      if (name.Length == 0 || address.Length == 0)
      {
        MessageBox.Show("Введіть щось у поля, вони усі обов'язкові!");
        return;
        }
            if (!moneyForTrack.All(char.IsDigit))
            {
                MessageBox.Show("Валідація");
                return;
            }
            if (!timeForTraсk.All(char.IsDigit))
            {
                MessageBox.Show("Валідація!");
                return;
            }
         
            if (!salaryForMonth.All(char.IsDigit))
            {
                MessageBox.Show("Валідація!");
                return;
            }
           
            var newStudio = new StudioGenerator(name, address, Int32.Parse(moneyForTrack), Int32.Parse(timeForTraсk), Int32.Parse(salaryForMonth));
      _list.Add(newStudio);

      comboBox1.Items.Add(name);
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = comboBox1.SelectedIndex;

      textBox1.Text = _list[index].name;
      textBox2.Text = _list[index].address;
      textBox3.Text = _list[index].people.ToString();
      textBox4.Text = _list[index].moneyForTrack.ToString();
      textBox5.Text = _list[index].timeForTraсk.ToString();
      textBox6.Text = _list[index].salaryForMonth.ToString();
      textBox7.Text = _list[index].allSalaryForMonth.ToString();
      textBox8.Text = _list[index].InstNum.ToString();
      textBox9.Text = _list[index].RoomsNum.ToString();
      textBox10.Text = _list[index].money.ToString();
    }

    private void buildNewRoom_Click(object sender, EventArgs e)   
    {
      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      List<Instrument> instrumentList = new List<Instrument>();
      for (int i = 0; i < 5; i++)
      {
        instrumentList.Add(new Instrument(StudioGenerator.GetRandomInstrumentalClass()));
      }

      int index = comboBox1.SelectedIndex;

      _list[index].CreateNewRoom(instrumentList);

      textBox9.Text = _list[index].RoomsList.Count().ToString();
      textBox10.Text = _list[index].money.ToString();

      roomsList.Clear();
      foreach (var item in _list[index].RoomsList)
      {
        roomsList.Text += item.Id.ToString();
        roomsList.Text += "\r\n";
      }
    }
    private void destroyRoom_Click(object sender, EventArgs e)
    {
      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      string RoomId = roomId.Text;

      int index = comboBox1.SelectedIndex;
      _list[index].DestroyRoom(RoomId);

      textBox9.Text = _list[index].RoomsList.Count().ToString();
      roomsList.Clear();

      foreach (var item in _list[index].RoomsList)
      {
        roomsList.Text += item.Id.ToString();
        roomsList.Text += "\r\n";
      }
    }

    private void hireWorker_Click(object sender, EventArgs e)
    {
      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      int index = comboBox1.SelectedIndex;

      _list[index].Hire();

      _list[index].allSalaryForMonth += _list[index].salaryForMonth;
      textBox7.Text = _list[index].allSalaryForMonth.ToString();

      textBox3.Text = _list[index].WorkersList.Count().ToString();

      workersList.Clear();
      foreach (var item in _list[index].WorkersList)
      {
        workersList.Text += (item.Key + "\r\n");
      }
    }
    private void dismissWorker_Click(object sender, EventArgs e)
    {
      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      string idToRemove = workerId.Text;

      int index = comboBox1.SelectedIndex;

      _list[index].Fire(idToRemove);

      textBox3.Text = _list[index].WorkersList.Count().ToString();

      workersList.Clear();
      foreach (var item in _list[index].WorkersList)
      {
        workersList.Text += (item.Key + "\r\n");
      }
    }

    private void buyInstrument_Click(object sender, EventArgs e)
    {
      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      int index = comboBox1.SelectedIndex;

      _list[index].BuyInstrument();

      textBox8.Text = _list[index].InstrumentsList.Count().ToString();

      instrumentsList.Clear();
      foreach (var item in _list[index].InstrumentsList)
      {
        instrumentsList.Text += item.Id.ToString();
        instrumentsList.Text += "\r\n";
      }
    }
    private void brokeInstrument_Click(object sender, EventArgs e)
    {
      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      int index = comboBox1.SelectedIndex;

      _list[index].DeleteInstrument();

      textBox8.Text = _list[index].InstrumentsList.Count().ToString();

      instrumentsList.Clear();
      foreach (var item in _list[index].InstrumentsList)
      {
        instrumentsList.Text += item.Id.ToString();
        instrumentsList.Text += "\r\n";
      }
    }
    private void copyStudio_Click(object sender, EventArgs e)
    {
      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      int index = comboBox1.SelectedIndex;
      StudioGenerator cloned = (StudioGenerator)_list[index].Clone();

      _list.Add(cloned);
      comboBox1.Items.Add(cloned.name);
    }

    private void addBalance_Click(object sender, EventArgs e)
    {
      string toCheck = textBox11.Text;

      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      if (toCheck != "")
      {
        int index = comboBox1.SelectedIndex;

        _list[index].AddBalance(Int32.Parse(textBox11.Text));
        textBox10.Text = _list[index].money.ToString();
      }
    }

    private void aboutInstr_Click(object sender, EventArgs e)
    {
      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      string InstrumentId = instrumentId.Text;

      if (!string.IsNullOrEmpty(InstrumentId))
      {
        int index = comboBox1.SelectedIndex;

        Instrument instrument = _list[index].getInstrumentById(InstrumentId);
        instrumentType.Text = instrument.InstrumentClass.ToString();
        instrumentPrice.Text = instrument.Price.ToString();
      }
    }
    private void aboutWorker_Click(object sender, EventArgs e)
    {
      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      string WorkerId = workerId.Text;

      if (!string.IsNullOrEmpty(WorkerId))
      {
        int index = comboBox1.SelectedIndex;

          Worker w = _list[index].getWorkerById(WorkerId); ;
          initials.Text = w.Initials.ToString();
          workerSalary.Text = w.Salary.ToString();
          workerTracks.Text = w.TraksCount.ToString();
      }
    }

    private void save_Click(object sender, EventArgs e)
    {
      if (_list.Count == 0)
      {
        MessageBox.Show("Немає студії, щоб зберігти", "Error", MessageBoxButtons.OK);
        return;
      }
      StringBuilder sb = new StringBuilder();
      foreach (StudioGenerator studio in _list)
      {
        string dir = $"C:\\StudioSave\\{studio.name}";
        string dir2 = $"C:\\StudioSave\\{studio.name}\\data";
        if (!Directory.Exists(dir))
        {
          Directory.CreateDirectory(dir);
          Directory.CreateDirectory(dir2);
        }
        if (!Directory.Exists(dir2))
          Directory.CreateDirectory(dir2);
        string path = $"C:\\StudioSave\\{studio.name}\\{studio.name}.txt";
        string pathInstrument = $"C:\\StudioSave\\{studio.name}\\data\\Instruments.txt";
        string pathWorker = $"C:\\StudioSave\\{studio.name}\\data\\Workers.txt";
        using (FileStream file = new FileStream(path, FileMode.Create))
        {
          using (StreamWriter stream = new StreamWriter(file))
          {
            sb.Clear();
            sb.AppendLine(studio.name.ToString());
            sb.AppendLine(studio.money.ToString());
            sb.AppendLine(studio.address);
            sb.AppendLine(studio.moneyForTrack.ToString());
            sb.AppendLine(studio.timeForTraсk.ToString());
            sb.AppendLine(studio.salaryForMonth.ToString());
            sb.AppendLine(studio.allSalaryForMonth.ToString());
            foreach (var item in studio.RoomsList)
            {
              sb.AppendLine(item.Id);
            }
            stream.WriteLine(sb.ToString());
          }
        }
        using (FileStream file = new FileStream(pathInstrument, FileMode.Create))
        {
          using (StreamWriter stream = new StreamWriter(file))
          {
            sb.Clear();
            foreach (var item in studio.InstrumentsList)
            {
              sb.AppendLine(item.Id);
              sb.AppendLine(item.InstrumentClass.ToString());
              sb.AppendLine(item.Price.ToString());
            }
            stream.WriteLine(sb.ToString());
          }
        }
        using (FileStream file = new FileStream(pathWorker, FileMode.Create))
        {
          using (StreamWriter stream = new StreamWriter(file))
          {
            sb.Clear();
            foreach (var item in studio.WorkersList)
            {
              sb.AppendLine(item.Value.Id);
              sb.AppendLine(item.Value.Initials);
              sb.AppendLine(item.Value.Salary.ToString());
              sb.AppendLine(item.Value.TraksCount.ToString());
            }
            stream.WriteLine(sb.ToString());
          }
        }
      }
      MessageBox.Show("Студія збережена!", "Error", MessageBoxButtons.OK);
    }
    private void load_Click(object sender, EventArgs e)
    {
      List<Worker> workers = new List<Worker>();
      List<Instrument> instruments = new List<Instrument>();
      List<Room> rooms = new List<Room>();
      if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
        return;
      string filename = openFileDialog1.FileName;
      if ((Path.GetFileName(filename) == "Workers.txt") | (Path.GetFileName(filename) == "Instruments.txt"))
      {
        MessageBox.Show("Не правильний файл!", "Error", MessageBoxButtons.OK);
        return;
      }
      string path = Path.GetDirectoryName(filename);
      string pathInstument = Path.Combine(path, "data", "Instruments.txt");
      string pathWorker = Path.Combine(path, "data", "Workers.txt");
      if (!File.Exists(pathInstument) | !File.Exists(pathWorker))
      {
        MessageBox.Show("Не правильний файл!", "Error", MessageBoxButtons.OK);
        return;
      }
      using (StreamReader stream = new StreamReader(pathInstument, Encoding.Default))
      {
        string id;
        while ((id = stream.ReadLine()) != "")
        {
          try
          {
            InstrumentsTypes iClass = (InstrumentsTypes)Enum.Parse(typeof(InstrumentsTypes), stream.ReadLine());
            int price = Convert.ToInt32(stream.ReadLine());
            Instrument ins = new Instrument(id, iClass, price);
            instruments.Add(ins);
          }
          catch
          {
            MessageBox.Show("Не правильний файл!", "Error", MessageBoxButtons.OK);
            return;
          }
        }
      }
      using (StreamReader stream = new StreamReader(pathWorker, Encoding.Default))
      {
        string id;
        while ((id = stream.ReadLine()) != "")
        {
          try
          {
            string initials = stream.ReadLine();
            int salery = Convert.ToInt32(stream.ReadLine());
            int traksCount = Convert.ToInt32(stream.ReadLine());
            workers.Add(new Worker(initials, salery, traksCount, id));
          }
          catch
          {
            MessageBox.Show("Файл порожній", "Error", MessageBoxButtons.OK);
            return;
          }
        }
      }
      using (StreamReader stream = new StreamReader(filename, Encoding.Default))
      {
        string studioName;
        if ((studioName = stream.ReadLine()) != "")
        {
          //try
          //{
          int studioMoneyBalance = Convert.ToInt32(stream.ReadLine());
          string studioAdress = stream.ReadLine();
          int cenaZaTraсk = Convert.ToInt32(stream.ReadLine());
          int timeForTraсk = Convert.ToInt32(stream.ReadLine());
          int emploeeMonthSalery = Convert.ToInt32(stream.ReadLine());
          int allEmploeesMonthSalery = Convert.ToInt32(stream.ReadLine());
          foreach (StudioGenerator item in _list)
          {
            if (studioName == item.name)
            {
              MessageBox.Show("Студія вже існує", "Error", MessageBoxButtons.OK);
              return;
            }
          }
          try
          {
            string id;
            while ((id = stream.ReadLine()) != "")
            {
              rooms.Add(new Room(id));
            }
          }
          catch
          {
            MessageBox.Show("Помилка!", "Error", MessageBoxButtons.OK);
          }
          StudioGenerator resultStudio = new StudioGenerator(studioName, studioMoneyBalance, studioAdress, cenaZaTraсk, timeForTraсk, emploeeMonthSalery, allEmploeesMonthSalery, rooms, workers, instruments);
          _list.Add(resultStudio);
          comboBox1.Items.Add(resultStudio);
          MessageBox.Show("Успішно пройдено", "Error", MessageBoxButtons.OK);
       
        }
      }
    }
  }
}
