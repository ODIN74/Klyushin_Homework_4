namespace Task_5
{
    class Doubler
    {
        //инициализируем поля класса
        private int current = 1;
        private int finish = 0;

        //определяем конструктор
        public Doubler(int n)
        {
            finish = n;
        }

        //свойство возвращающее текущее значение
        public int Current
        {
            get { return current;}
        }

        //свойство возвращающее текущее значение
        public int Finish
        {
            get { return finish; }
        }

        //метод увеличения числа на 1
        public void Incremention()
        {
            current++;
        }

        //метод удвоения числа
        public void Redouble()
        {
            current *= 2;
        }

        //метод сброса на 1
        public void Reset()
        {
            current = 1;
        }
    }
}
