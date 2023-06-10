using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace TimersAndDate
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer countDownTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer clickCountTimer = new System.Windows.Forms.Timer();
        private int clickCount;
        private int maxClickCount;
        private int seconds;

        public Form1()
        {
            InitializeComponent();
            InitializeCountdownTimer();
        }

        private void InitializeCountdownTimer()
        {
            countDownTimer.Interval = 1000; // Интервал таймера 1 секунда
            countDownTimer.Tick += CountTimerTick;
            countDownTimer.Start();
            clickCountTimer.Interval = 1000; // Интервал таймера 1 секунда
            clickCountTimer.Tick += ClickCountTimerTick;
        }

        private void CountTimerTick(object? sender, EventArgs e)
        {
            DateTime newYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // Дата нового года следующего года
            TimeSpan remainTime = newYear - DateTime.Now;
            string str = $"{remainTime.Days} дней, {remainTime.Hours} часов, {remainTime.Minutes} минут";
            label1.Text = $"До Нового года осталось: {str}";
            button1.Text = $"Прошло сек: {this.seconds} \nКол-во нажатий: {clickCount}";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!clickCountTimer.Enabled)
            {
                clickCount = 0; // Сбросить счетчик нажатий
                clickCountTimer.Start(); // Запустить таймер счетчика нажатий
                clickCount++;
                seconds = 0;
            }
            else
            {
                clickCount++;
            }
        }

        private void ClickCountTimerTick(object? sender, EventArgs e)
        {
            seconds++;
            if (seconds >= 20)
            {
                clickCountTimer.Stop(); // Остановить таймер после достижения 20 нажатий
                if (clickCount > maxClickCount)
                {
                    maxClickCount = clickCount;
                }
                ShowResult(); // Вывод  окна сообщения
            }
        }

        private void ShowResult()
        {
            string message = $"Итоговое количество кликов: {clickCount}\n Максимальный результат: {maxClickCount}";
            string caption = "Результат";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            MessageBox.Show(message, caption, buttons, icon);
        }
    }
}