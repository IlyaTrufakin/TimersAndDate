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
            countDownTimer.Interval = 1000; // �������� ������� 1 �������
            countDownTimer.Tick += CountTimerTick;
            countDownTimer.Start();
            clickCountTimer.Interval = 1000; // �������� ������� 1 �������
            clickCountTimer.Tick += ClickCountTimerTick;
        }

        private void CountTimerTick(object? sender, EventArgs e)
        {
            DateTime newYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // ���� ������ ���� ���������� ����
            TimeSpan remainTime = newYear - DateTime.Now;
            string str = $"{remainTime.Days} ����, {remainTime.Hours} �����, {remainTime.Minutes} �����";
            label1.Text = $"�� ������ ���� ��������: {str}";
            button1.Text = $"������ ���: {this.seconds} \n���-�� �������: {clickCount}";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!clickCountTimer.Enabled)
            {
                clickCount = 0; // �������� ������� �������
                clickCountTimer.Start(); // ��������� ������ �������� �������
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
                clickCountTimer.Stop(); // ���������� ������ ����� ���������� 20 �������
                if (clickCount > maxClickCount)
                {
                    maxClickCount = clickCount;
                }
                ShowResult(); // �����  ���� ���������
            }
        }

        private void ShowResult()
        {
            string message = $"�������� ���������� ������: {clickCount}\n ������������ ���������: {maxClickCount}";
            string caption = "���������";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            MessageBox.Show(message, caption, buttons, icon);
        }
    }
}