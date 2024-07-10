using FoodWars.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FoodWars.View
{
    public partial class InGameUserControl : UserControl
    {
        #region Data Members
        private BaseForm baseForm;
        #endregion

        #region Constructors
        public InGameUserControl(BaseForm baseForm)
        {
            InitializeComponent();
            this.BaseForm = baseForm;
        }
        #endregion

        #region Properties
        private BaseForm BaseForm
        {
            get => baseForm;
            set
            {
                if (value == null) throw new Exception("No base form specified!");
                else this.baseForm = value;
            }
        }
        #endregion

        #region Event Handlers
        private void InGameUserControl_Load(object sender, EventArgs e)
        {
            msg_bubble1.Hide();
            msg_bubble2.Hide();
            msg_bubble3.Hide();
            BaseForm.Game.StartGame();
            label_timeLeft.Text = BaseForm.Game.OpenDuration.DurationToString();
            label_customerLeft.Text = BaseForm.Game.CustomersLeft().ToString();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            // Mengupdate waktu bermain dan sisa customer pada user control 
            BaseForm.Game.OpenDuration.Add(-1);
            label_timeLeft.Text = BaseForm.Game.OpenDuration.DurationToString();
            label_customerLeft.Text = BaseForm.Game.CustomersLeft().ToString();

            // Memanggil fungsi untuk mengupdate waktu tunggu seluruh customer, mengeluarkan customer yang durasinya habis,
            // serta memberi jeda antar datangnya customer sesuai aturan yang ada. 
            for (int i = 0; i < BaseForm.Game.Chairs.Length; i++) BaseForm.Game.UpdateAllCustomer(i);

            // Memanggil fungsi untuk mengupdate tampilan ruang
            if (BaseForm.Game.OpenDuration.GetSecond() > 0)
            {
                Console.WriteLine("<" + BaseForm.Game.OpenDuration.DurationToString() + ">");
                UpdateWaitingRoom();
            }
        }

        private void UpdateWaitingRoom()
        {
            string ListToString(List<Items> orders)
            {
                string result = "";

                foreach(Items order in orders)
                {
                    result += order.Name;
                } 

                return result;
            }
            Customers[] waitingCustomers = BaseForm.Game.Chairs;
            // Mengupdate tampilan ruang tunggu berdasarkan array of customers (sementara di console)
            for (int i = 0; i < waitingCustomers.Length; i++)
            {
                if (waitingCustomers[i] != null)
                {
                    Console.WriteLine((i + 1) + " - " + ListToString(waitingCustomers[i].Orders) + " | Time left: " + waitingCustomers[i].WaitingDuration.GetSecond());
                    if (i == 0)
                    {
                        msg_bubble1.Show();
                        timerLabel_c1.Text = waitingCustomers[i].WaitingDuration.GetSecond().ToString();
                    }
                    else if (i == 1)
                    {
                        msg_bubble2.Show();
                        timerLabel_c2.Text = waitingCustomers[i].WaitingDuration.GetSecond().ToString();
                    }
                    else
                    {
                        msg_bubble3.Show();
                        timerLabel_c3.Text = waitingCustomers[i].WaitingDuration.GetSecond().ToString();
                    }
                }
                else
                {
                    Console.WriteLine((i + 1) + " - Empty");
                    if (i == 0) msg_bubble1.Hide();
                    else if (i == 1) msg_bubble2.Hide();
                    else msg_bubble3.Hide();
                }
            }
            Console.WriteLine("");
        }

        private void Button_Pause_MouseEnter(object sender, EventArgs e)
        {
            pictBox_buttonPause.BackgroundImage = Resources.button_pause_stroke;
        }

        private void Button_Pause_MouseLeave(object sender, EventArgs e)
        {
            pictBox_buttonPause.BackgroundImage = Resources.button_pause;
        }

        private void Button_Pause_Click(object sender, EventArgs e)
        {
            PauseUserControl pauseUc = new PauseUserControl(BaseForm, this);
            this.timer.Stop();

            BaseForm.mainPanel.Controls.Add(pauseUc);
            BaseForm.mainPanel.Controls.Remove(this);
            pauseUc.Dock = DockStyle.Fill;
        }
        #endregion
    }
}
