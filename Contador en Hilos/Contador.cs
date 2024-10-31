using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contador_en_Hilos
{
    internal class Contador
    {
        private int _value;
        private int _range;
        private Thread _thread;
        private bool _active;

        public Contador(int range)
        {
            _value = 0;
            _range = range;
            _active = false;
        }

        public void start()
        {
            _active = true;
            _thread = new Thread(execute);
            _thread.Start();
        }
        public void stop()
        {
            _active = false;
            _thread.Join();
        }

        public void execute()
        {
            while (_active)
            {
                _value++;
                Console.WriteLine($"Contador en {_value}");
                Thread.Sleep(_range);
            }
        }

        public int GetValue()
        {
            return _value;
        }
    }
}
