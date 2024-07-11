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
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            // Mengupdate waktu bermain dan sisa customer pada user control 
            BaseForm.Game.OpenDuration.Add(-1);
            label_timeLeft.Text = BaseForm.Game.OpenDuration.DurationToString();

            // Memanggil fungsi untuk mengupdate waktu tunggu seluruh customer, mengeluarkan customer yang durasinya habis,
            // serta memberi jeda antar datangnya customer sesuai aturan yang ada. 
            for (int i = 0; i < BaseForm.Game.Chairs.Length; i++) BaseForm.Game.UpdateAllCustomer(i);

            // Memanggil fungsi untuk mengupdate tampilan ruang
            if (BaseForm.Game.OpenDuration.GetSecond() > 0)
            {
                Console.WriteLine("<" + BaseForm.Game.OpenDuration.DurationToString() + ">");
                UpdateWaitingRoom(); // INI HARUS DIPANGGIL TIAP 1/10 detik
            }

            if (BaseForm.Game.FinishGame())
            {
                //    Menang <GameCompleteView> 
                //    - Tampilkan pencapaian di level
                //    - Simpan data player
                //    - Reset game.
            }
            else
            {
                //    Kalah <GameOverView>
                //    - Reset game
                //    - Kembali ke main menu 
            }
        }

        private void UpdateWaitingRoom()
        {
            Customers[] waitingCustomers = BaseForm.Game.Chairs;
            // Mengupdate tampilan ruang tunggu berdasarkan array of customers (sementara di console)
            for (int i = 0; i < waitingCustomers.Length; i++)
            {
                if (waitingCustomers[i] != null)
                {

                    Console.WriteLine(waitingCustomers[i].Orders[0].Name + " | " + waitingCustomers[i].Orders[1].Name + " | " + waitingCustomers[i].Orders[2].Name);

                    if (i == 0)
                    {
                        msg_bubble1.Show();
                        timerLabel_c1.Text = waitingCustomers[i].WaitingDuration.GetSecond().ToString();
                        pictBox_cust1.BackgroundImage = waitingCustomers[i].Picture;
                        pictBox_cust1.Show();
                        if (waitingCustomers[i].Orders.Count >= 1)
                        {
                            if (waitingCustomers[i].Orders[0] is Foods) 
                            {
                                /*itemBase_1A.BackgroundImage = ;
                                rice_1A.BackgroundImage = ;
                                protein_1A.BackgroundImage = ;
                                veggie_1A.BackgroundImage = ;
                                sideDish_1A.BackgroundImage = ;*/
                            } 
                            else
                            {
                                itemBase_1A.BackgroundImage = waitingCustomers[i].Orders[0].Picture;
                            }
                        }
                        if (waitingCustomers[i].Orders.Count >= 2)
                        {
                            if (waitingCustomers[i].Orders[1] is Foods)
                            {
                                /*itemBase_1B.BackgroundImage = ;
                                rice_1B.BackgroundImage = ;
                                protein_1B.BackgroundImage = ;
                                veggie_1B.BackgroundImage = ;
                                sideDish_1B.BackgroundImage = ;*/
                            }
                            else
                            {
                                itemBase_1B.BackgroundImage = waitingCustomers[i].Orders[1].Picture;
                            }
                        }
                        if (waitingCustomers[i].Orders.Count == 3)
                        {
                            if (waitingCustomers[i].Orders[2] is Foods)
                            {
                                /*itemBase_1C.BackgroundImage = ;
                                rice_1C.BackgroundImage = ;
                                protein_1C.BackgroundImage = ;
                                veggie_1C.BackgroundImage = ;
                                sideDish_1C.BackgroundImage = ;*/
                            }
                            else
                            {
                                itemBase_1C.BackgroundImage = waitingCustomers[i].Orders[2].Picture;
                            }
                        }
                    }
                    else if (i == 1)
                    {
                        msg_bubble2.Show();
                        timerLabel_c2.Text = waitingCustomers[i].WaitingDuration.GetSecond().ToString();
                        pictBox_cust2.BackgroundImage = waitingCustomers[i].Picture;
                        pictBox_cust2.Show();
                        if (waitingCustomers[i].Orders.Count >= 1)
                        {
                            if (waitingCustomers[i].Orders[0] is Foods)
                            {
                                /*itemBase_2A.BackgroundImage = ;
                                rice_2A.BackgroundImage = ;
                                protein_2A.BackgroundImage = ;
                                veggie_2A.BackgroundImage = ;
                                sideDish_2A.BackgroundImage = ;*/
                            }
                            else
                            {
                                itemBase_2A.BackgroundImage = waitingCustomers[i].Orders[0].Picture;
                            }
                        }
                        if (waitingCustomers[i].Orders.Count >= 2)
                        {
                            if (waitingCustomers[i].Orders[1] is Foods)
                            {
                                /*itemBase_2B.BackgroundImage = ;
                                rice_2B.BackgroundImage = ;
                                protein_2B.BackgroundImage = ;
                                veggie_2B.BackgroundImage = ;
                                sideDish_2B.BackgroundImage = ;*/
                            }
                            else
                            {
                                itemBase_2B.BackgroundImage = waitingCustomers[i].Orders[1].Picture;
                            }
                        }
                        if (waitingCustomers[i].Orders.Count == 3)
                        {
                            itemBase_2C.Show();
                            if (waitingCustomers[i].Orders[2] is Foods)
                            {
                                /*itemBase_2C.BackgroundImage = ;
                                rice_2C.BackgroundImage = ;
                                protein_2C.BackgroundImage = ;
                                veggie_2C.BackgroundImage = ;
                                sideDish_2C.BackgroundImage = ;*/
                            }
                            else
                            {
                                itemBase_2C.BackgroundImage = waitingCustomers[i].Orders[2].Picture;
                            }
                        }
                    }
                    else
                    {
                        msg_bubble3.Show();
                        timerLabel_c3.Text = waitingCustomers[i].WaitingDuration.GetSecond().ToString();
                        pictBox_cust3.BackgroundImage = waitingCustomers[i].Picture;
                        pictBox_cust3.Show();
                        if (waitingCustomers[i].Orders.Count >= 1)
                        {
                            if (waitingCustomers[i].Orders[0] is Foods)
                            {
                                /*itemBase_3A.BackgroundImage = ;
                                rice_3A.BackgroundImage = ;
                                protein_3A.BackgroundImage = ;
                                veggie_3A.BackgroundImage = ;
                                sideDish_3A.BackgroundImage = ;*/
                            }
                            else
                            {
                                itemBase_3A.BackgroundImage = waitingCustomers[i].Orders[0].Picture;
                            }
                        }
                        if (waitingCustomers[i].Orders.Count >= 2)
                        {
                            if (waitingCustomers[i].Orders[1] is Foods)
                            {
                                /*itemBase_3B.BackgroundImage = ;
                                rice_3B.BackgroundImage = ;
                                protein_3B.BackgroundImage = ;
                                veggie_3B.BackgroundImage = ;
                                sideDish_3B.BackgroundImage = ;*/
                            }
                            else
                            {
                                itemBase_3B.BackgroundImage = waitingCustomers[i].Orders[1].Picture;
                            }
                        }
                        if (waitingCustomers[i].Orders.Count == 3)
                        {
                            if (waitingCustomers[i].Orders[2] is Foods)
                            {
                                /*itemBase_3C.BackgroundImage = ;
                                rice_3C.BackgroundImage = ;
                                protein_3C.BackgroundImage = ;
                                veggie_3C.BackgroundImage = ;
                                sideDish_3C.BackgroundImage = ;*/
                            }
                            else
                            {
                                itemBase_3C.BackgroundImage = waitingCustomers[i].Orders[2].Picture;
                            }
                        }
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        msg_bubble1.Hide();
                        itemBase_1A.BackgroundImage = null;
                        itemBase_1B.BackgroundImage = null;
                        itemBase_1C.BackgroundImage = null;
                        rice_1A.BackgroundImage = null;
                        rice_1B.BackgroundImage = null;
                        rice_1C.BackgroundImage = null;
                        protein_1A.BackgroundImage = null;
                        protein_1B.BackgroundImage = null;
                        protein_1C.BackgroundImage = null;
                        veggie_1A.BackgroundImage = null;
                        veggie_1B.BackgroundImage = null;
                        veggie_1C.BackgroundImage = null;
                        sideDish_1A.BackgroundImage = null;
                        sideDish_1B.BackgroundImage = null;
                        sideDish_1C.BackgroundImage = null;
                        pictBox_cust1.Hide();
                    }
                    else if (i == 1)
                    {
                        msg_bubble2.Hide();
                        itemBase_2A.BackgroundImage = null;
                        itemBase_2B.BackgroundImage = null;
                        itemBase_2C.BackgroundImage = null;
                        rice_2A.BackgroundImage = null;
                        rice_2B.BackgroundImage = null;
                        rice_2C.BackgroundImage = null;
                        protein_2A.BackgroundImage = null;
                        protein_2B.BackgroundImage = null;
                        protein_2C.BackgroundImage = null;
                        veggie_2A.BackgroundImage = null;
                        veggie_2B.BackgroundImage = null;
                        veggie_2C.BackgroundImage = null;
                        sideDish_2A.BackgroundImage = null;
                        sideDish_2B.BackgroundImage = null;
                        sideDish_2C.BackgroundImage = null;
                        pictBox_cust2.Hide();
                    }
                    else
                    {
                        msg_bubble3.Hide();
                        itemBase_3A.BackgroundImage = null;
                        itemBase_3B.BackgroundImage = null;
                        itemBase_3C.BackgroundImage = null;
                        rice_3A.BackgroundImage = null;
                        rice_3B.BackgroundImage = null;
                        rice_3C.BackgroundImage = null;
                        protein_3A.BackgroundImage = null;
                        protein_3B.BackgroundImage = null;
                        protein_3C.BackgroundImage = null;
                        veggie_3A.BackgroundImage = null;
                        veggie_3B.BackgroundImage = null;
                        veggie_3C.BackgroundImage = null;
                        sideDish_3A.BackgroundImage = null;
                        sideDish_3B.BackgroundImage = null;
                        sideDish_3C.BackgroundImage = null;
                        pictBox_cust3.Hide();
                    }
                }
            }
            Console.WriteLine("");
        }

        private void PictBox_cust1_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.Chairs[0] != null)
            {
                if (BaseForm.Game.CheckOrder(0))
                {
                    // Jangan tampilkan item di message bubble (diupdate saat fungsi update waiting room dipanggil)
                    // Bunyikan SFX 
                    // Kosongkan item yang dipilih
                }
                else
                {
                    // Buat message bubble menjadi merah selama 1 detik 
                    // Bunyikan SFX 
                    // Kosongkan item yang dipilih
                }
            }
        }

        private void PictBox_cust2_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.Chairs[1] != null)
            {
                if (BaseForm.Game.CheckOrder(1))
                {

                }
                else
                {

                }
            }
        }

        private void PictBox_cust3_Click(object sender, EventArgs e)
        {
            if (BaseForm.Game.Chairs[2] != null)
            {
                if (BaseForm.Game.CheckOrder(1))
                {

                }
                else
                {

                }
            }
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
